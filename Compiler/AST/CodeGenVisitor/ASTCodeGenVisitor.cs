using System;
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
        public static readonly bool OPTIMIZE = true;

        private readonly LLVMModuleRef _module;
        private readonly LLVMBuilderRef _builder;
        private readonly LLVMPassManagerRef _functionPassManager;
        private readonly LLVMPassManagerRef _modulePassManager;
        private readonly Dictionary<string, LLVMValueRef> _namedValues;
        private readonly Stack<LLVMValueRef> _valueStack;

        public ASTCodeGenVisitor(string moduleName)
        {
            _namedValues = new Dictionary<string, LLVMValueRef>();
            _valueStack = new Stack<LLVMValueRef>();
            _module = LLVM.ModuleCreateWithName(moduleName);
            _builder = LLVM.CreateBuilder();

            _functionPassManager = LLVM.CreateFunctionPassManagerForModule(_module);
            _modulePassManager = LLVM.CreatePassManager();

            _SetupPasses();
        }

        private void _SetupPasses()
        {
            LLVM.AddPromoteMemoryToRegisterPass(_functionPassManager);
            LLVM.AddInstructionCombiningPass(_functionPassManager);
            LLVM.AddReassociatePass(_functionPassManager);
            LLVM.AddGVNPass(_functionPassManager);
            LLVM.AddCFGSimplificationPass(_functionPassManager);
            LLVM.AddTailCallEliminationPass(_functionPassManager);
            LLVM.InitializeFunctionPassManager(_functionPassManager);

            LLVM.AddFunctionInliningPass(_modulePassManager);
            LLVM.AddGlobalDCEPass(_modulePassManager);
        }

        public void PrintIR()
        {
            if(OPTIMIZE) LLVM.RunPassManager(_modulePassManager, _module);
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
                case BinaryOperator.Addition: 
                    res = LLVM.BuildFAdd(_builder, left, right, "addtmp");
                    break;
                case BinaryOperator.Subtraction:
                    res = LLVM.BuildFSub(_builder, left, right, "subtmp");
                    break;
                case BinaryOperator.Multiplication:
                    res = LLVM.BuildFMul(_builder, left, right, "multmp");
                    break;
                case BinaryOperator.LessThan:
                    left = LLVM.BuildFCmp(_builder, LLVMRealPredicate.LLVMRealULT, left, right, "cmptmp");
                    res = LLVM.BuildUIToFP(_builder, left, LLVM.DoubleType(), "booltmp");
                    break;
                default:
                    //Handle predefined operator
                    var function = LLVM.GetNamedFunction(_module, $"binary{node.Operator}");
                    var ops = new[] { left, right };
                    res = LLVM.BuildCall(_builder, function, ops, "binop");
                    break;
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
            node.Prototype.Accept(this);
            var function = _valueStack.Pop();

            var entry = LLVM.AppendBasicBlock(function, "entry");
            LLVM.PositionBuilderAtEnd(_builder, entry);

            for(int i = 0; i<node.Args.Count; i++)
            {
                var argName = node.Args[i];

                var param = LLVM.GetParam(function, (uint)i);
                LLVM.SetValueName(param, argName);

                var alloca = _CreateEntryBlockAlloca(function, argName);
                LLVM.BuildStore(_builder, param, alloca); 

                _namedValues[argName] = alloca;
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
                var loaded = LLVM.BuildLoad(_builder, value, node.Name);
                _valueStack.Push(loaded);
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
            node.ElseExpression.Value.Accept(this);
            var elseV = _valueStack.Pop();
            LLVM.BuildBr(_builder, mergeBB);
            elseBB = LLVM.GetInsertBlock(_builder);

            LLVM.PositionBuilderAtEnd(_builder, mergeBB);
            var phiNode = LLVM.BuildPhi(_builder, LLVM.DoubleType(), "iftmp");

            phiNode.AddIncoming(new[] {thenV, elseV}, new[] { thenBB, elseBB }, 2);
            _valueStack.Push(phiNode);
        }

        public void Visit(LetExpressionNode node)
        {
            var oldBindings = new List<LLVMValueRef>();

            foreach(var assignment in node.Assignments)
            {
                assignment.Expression.Accept(this);
                var calculated = _valueStack.Pop();
                var value = LLVM.BuildAlloca(_builder, LLVM.DoubleType(), assignment.Identifier);
                LLVM.BuildStore(_builder, calculated, value);
                _namedValues.TryGetValue(assignment.Identifier, out var oldValue);
                oldBindings.Add(oldValue);
                _namedValues.Add(assignment.Identifier, value);
            }

            node.InExpression.Accept(this);

            for(int i = 0; i<node.Assignments.Count; i++)
            {
                _namedValues[node.Assignments[i].Identifier] = oldBindings[i];
            }
        }

        private LLVMValueRef _CreateEntryBlockAlloca(LLVMValueRef function, string varName)
        {
            var tempB = LLVM.CreateBuilder();
            var entry = function.GetEntryBasicBlock();
            LLVM.PositionBuilder(tempB, entry, entry.GetFirstInstruction());

            return LLVM.BuildAlloca(tempB, LLVM.DoubleType(), varName);
        }

    }
}
