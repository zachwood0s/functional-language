﻿using LLVMSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr.AST.Nodes;
using ZAntlr.AST.Types;

namespace Compiler.AST.CodeGenVisitor
{
    public partial class ASTCodeGenVisitor
    {
        public void Visit(FunctionCallNode node)
        {
            var callee = LLVM.GetNamedFunction(_module, (node.Callee as IdentifierNode).Name);
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
            //node.Prototype.Accept(this);
            var function = _valueStack.Pop();

            var entry = LLVM.AppendBasicBlock(function, "entry");
            LLVM.PositionBuilderAtEnd(_builder, entry);

            for(int i = 0; i<node.Args.Count; i++)
            {
                /*
                var argName = node.Args[i];
                //var type = node.Prototype.Type.ParameterTypes[i];

                var param = LLVM.GetParam(function, (uint)i);
                LLVM.SetValueName(param, argName);

                var alloca = _CreateEntryBlockAlloca(function, argName, _GetLLVMType(type, new Pidgin.SourcePos()));
                LLVM.BuildStore(_builder, param, alloca);

                _namedValues[argName] = alloca;
                */
            }

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
            if(OPTIMIZE) LLVM.RunFunctionPassManager(_functionPassManager, function);
            _valueStack.Push(function);
        }

        public void Visit(PrototypeNode node)
        {
            var argCount = (uint)node.Type.ParameterTypes.Count;
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
                    var type = node.Type.ParameterTypes[i];
                    arguments[i] = _GetLLVMType(type, new Pidgin.SourcePos());
                }
                var returnType = _GetLLVMType(node.Type.ReturnType, new Pidgin.SourcePos());
                function = LLVM.AddFunction(
                    _module,
                    node.Name,
                    LLVM.FunctionType(returnType, arguments, false));
                LLVM.SetLinkage(function, LLVMLinkage.LLVMExternalLinkage);
            }

            _valueStack.Push(function);
        }

        private void _CreateBuiltInFunctions()
        {
            var type = LLVM.FunctionType(LLVM.Int32Type(), new[] { LLVM.Int32Type() }, false);
            var putChar = LLVM.AddFunction(_module, "putchar", type);
            putChar.SetLinkage(LLVMLinkage.LLVMExternalLinkage);
            var param = new List<(INodeType type, string name)>()
            {
                (DefaultTypes.Char, "in")
            };
            _CreateFunction(
                param,            
                DefaultTypes.Int,
                "printChar",
                false,
                vals =>
                {
                    var val = LLVM.BuildIntCast(_builder, vals[0], LLVM.Int32Type(), "charcast");
                    return LLVM.BuildCall(_builder, putChar, new[] { val }, "printCall");
                }
            );
        }

        private LLVMValueRef _CreateFunction(
            List<(INodeType type, string name)> paramTypes, 
            INodeType returnType, 
            string name, 
            bool isVarArg, 
            Func<List<LLVMValueRef>, LLVMValueRef> action)
        {
            var llvmReturnType = _llvmTypes[returnType];
            var llvmParamTypes = paramTypes.Select(x => _llvmTypes[x.type]).ToArray();
            var type = LLVM.FunctionType(llvmReturnType, llvmParamTypes, isVarArg);
            var func = LLVM.AddFunction(_module, name, type);
            func.SetLinkage(LLVMLinkage.LLVMExternalLinkage);

            var entry = LLVM.AppendBasicBlock(func, "entry");
            LLVM.PositionBuilderAtEnd(_builder, entry);

            var vals = new List<LLVMValueRef>();
            for(int i = 0; i<paramTypes.Count; i++)
            {
                var paramName = paramTypes[i].name;
                var val = LLVM.GetParam(func, (uint)i);
                LLVM.SetValueName(val, paramName);

                var alloca = _CreateEntryBlockAlloca(func, paramName, llvmParamTypes[i]);
                LLVM.BuildStore(_builder, val, alloca);
                var loaded = LLVM.BuildLoad(_builder, alloca, paramName);
                vals.Add(loaded);
            }

            LLVM.BuildRet(_builder, action(vals));
            LLVM.VerifyFunction(func, LLVMVerifierFailureAction.LLVMPrintMessageAction);
            if (OPTIMIZE) LLVM.RunFunctionPassManager(_functionPassManager, func);

            return func;
        }
    }
}
