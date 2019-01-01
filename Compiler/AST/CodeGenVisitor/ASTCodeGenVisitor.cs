﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.AST.Nodes;
using Compiler.Parser;
using LLVMSharp;

namespace Compiler.AST.CodeGenVisitor
{
    public partial class ASTCodeGenVisitor : IASTVisitor
    {
        private readonly LLVMModuleRef _module;
        private readonly LLVMBuilderRef _builder;
        private readonly LLVMPassManagerRef _passManager;
        private readonly Dictionary<string, LLVMValueRef> _namedValues;
        private readonly Stack<LLVMValueRef> _valueStack;

        public ASTCodeGenVisitor(string moduleName)
        {
            _namedValues = new Dictionary<string, LLVMValueRef>();
            _valueStack = new Stack<LLVMValueRef>();
            _module = LLVM.ModuleCreateWithName(moduleName);
            _builder = LLVM.CreateBuilder();

            _passManager = LLVM.CreateFunctionPassManagerForModule(_module);
            LLVM.AddInstructionCombiningPass(_passManager);
            LLVM.AddReassociatePass(_passManager);
            LLVM.AddGVNPass(_passManager);
            LLVM.AddCFGSimplificationPass(_passManager);
            LLVM.InitializeFunctionPassManager(_passManager);
        }

        public void PrintIR()
        {
            LLVM.DumpModule(_module);
        }

        public void Visit(ASTNode node)
        {
        }

        public void Visit(BinaryOperatorNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);

            var right = _valueStack.Pop();
            var left = _valueStack.Pop();

            LLVMValueRef res;
            switch (node.Operator)
            {
                case BinaryOperatorType.Addition:
                    res = LLVM.BuildFAdd(_builder, left, right, "addtmp");
                    break;
                case BinaryOperatorType.Subtraction:
                    res = LLVM.BuildFSub(_builder, left, right, "subtmp");
                    break;
                case BinaryOperatorType.Multiplication:
                    res = LLVM.BuildFMul(_builder, left, right, "multmp");
                    break;
                default:
                    throw new Exception("invalid binary operator");
            }
            _valueStack.Push(res);
        }

        public void Visit(ConstantDoubleNode node)
        {
            _valueStack.Push(LLVM.ConstReal(LLVM.DoubleType(), node.Value));
        }

        public void Visit(UnaryOperatorNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(FunctionCallNode node)
        {
            var callee = LLVM.GetNamedFunction(_module, node.Callee);
            if(callee.Pointer == IntPtr.Zero)
            {
                throw new Exception("Unknown function referenced");
            }

            if(LLVM.CountParams(callee) != node.Args.Count)
            {
                throw new Exception("Incorrect # arguments passed");
            }

            var argCount = (uint) node.Args.Count;
            var argsV = new LLVMValueRef[argCount];

            for(int i = 0; i<argCount; i++)
            {
                node.Args[i].Accept(this);
                argsV[i] = _valueStack.Pop();
            }

            _valueStack.Push(LLVM.BuildCall(_builder, callee, argsV, "calltmp"));
        }

        public void Visit(FunctionNode node)
        {
            _namedValues.Clear();
            node.Prototype.Accept(this);
            var function = _valueStack.Pop();

            for(int i = 0; i<node.Args.Count; i++)
            {
                var argName = node.Args[i];

                var param = LLVM.GetParam(function, (uint)i);
                LLVM.SetValueName(param, argName);

                _namedValues[argName] = param;
            }

            LLVM.PositionBuilderAtEnd(_builder, LLVM.AppendBasicBlock(function, "entry"));

            try
            {
                node.Body.Accept(this);
            }
            catch (Exception)
            {
                LLVM.DeleteFunction(function);
                throw;
            }
            LLVM.BuildRet(_builder, _valueStack.Pop());

            LLVM.VerifyFunction(function, LLVMVerifierFailureAction.LLVMPrintMessageAction);
            LLVM.RunFunctionPassManager(_passManager, function);
            _valueStack.Push(function);
        }

        public void Visit(PrototypeNode node)
        {
            var argCount = (uint)node.ArgTypes.Count;
            var arguments = new LLVMTypeRef[argCount];

            var function = LLVM.GetNamedFunction(_module, node.Name);


            if(function.Pointer != IntPtr.Zero)
            {
                if(LLVM.CountBasicBlocks(function) != 0)
                {
                    throw new Exception("redefinition of function.");
                }
                if(LLVM.CountParams(function) != argCount)
                {
                    throw new Exception("redefinition of function with different # args");
                }
            }
            else
            {
                for(int i = 0; i<argCount; i++)
                {
                    arguments[i] = LLVM.DoubleType();
                }
                function = LLVM.AddFunction(
                    _module,
                    node.Name,
                    LLVM.FunctionType(LLVM.DoubleType(), arguments, false));
                LLVM.SetLinkage(function, LLVMLinkage.LLVMExternalLinkage);
            }

            _valueStack.Push(function);

        }

        public void Visit(IdentifierNode node)
        {
            if(_namedValues.TryGetValue(node.Name, out var value))
            {
                _valueStack.Push(value);
            }
            else
            {
                throw new CodeGenException<string>($"Unknown variable name '{node.Name}'", node.Span);
            }
        }

        public void Visit(IfExpressionNode node)
        {
            node.IfCondition.Accept(this);
            var condV = _valueStack.Pop();

            condV = LLVM.BuildFCmp(
                _builder,
                LLVMRealPredicate.LLVMRealONE,
                condV,
                LLVM.ConstReal(LLVM.DoubleType(), 0.0),
                "ifcond");

            var function = LLVM.GetInsertBlock(_builder).GetBasicBlockParent();

            var thenBB = function.AppendBasicBlock("then");
            var elseBB = function.AppendBasicBlock("else");
            var mergeBB = function.AppendBasicBlock("ifcont");

            LLVM.BuildCondBr(_builder, condV, thenBB, elseBB);

            LLVM.PositionBuilderAtEnd(_builder, thenBB);
            node.Then.Accept(this);
            var thenV = _valueStack.Pop();
            LLVM.BuildBr(_builder, mergeBB);
            thenBB = LLVM.GetInsertBlock(_builder);

            LLVM.PositionBuilderAtEnd(_builder, elseBB);
            node.ElseExpression.Get().Accept(this);
            var elseV = _valueStack.Pop();
            LLVM.BuildBr(_builder, mergeBB);
            elseBB = LLVM.GetInsertBlock(_builder);

            LLVM.PositionBuilderAtEnd(_builder, mergeBB);
            var phiNode = LLVM.BuildPhi(_builder, LLVM.DoubleType(), "iftmp");

            phiNode.AddIncoming(new[] {thenV, elseV}, new[] { thenBB, elseBB }, 2);
            _valueStack.Push(phiNode);
        }
    }
}
