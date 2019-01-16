using Compiler.AST.Nodes;
using Compiler.AST.Types;
using LLVMSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compiler.PidginParser.OperatorParser;

namespace Compiler.AST.CodeGenVisitor
{
    public partial class ASTCodeGenVisitor
    {
        //private Dictionary<string, Dictionary<INodeType, LLVMValueRef>> _LLVMoperators;

        public void Visit(BinaryOperatorNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);

            var right = _valueStack.Pop();
            var left = _valueStack.Pop();

            var nodeType = _GetLLVMType(node.Type, new Pidgin.SourcePos());
            LLVMValueRef res;

            var opName = _GetBinaryOpName(node);
            var function = LLVM.GetNamedFunction(_module, opName);
            var ops = new[] { left, right };
            res = LLVM.BuildCall(_builder, function, ops, "binop");

            _valueStack.Push(res);
        }

        private void _CreateDefaultOperators()
        {
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Float, BinaryOperatorOpCode.Addition,
                (lhs, rhs) => LLVM.BuildFAdd(_builder, lhs, rhs, "addtmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Float, BinaryOperatorOpCode.Subtraction,
                (lhs, rhs) => LLVM.BuildFSub(_builder, lhs, rhs, "subtmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Float, BinaryOperatorOpCode.Multiplication,
                (lhs, rhs) => LLVM.BuildFMul(_builder, lhs, rhs, "multmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Float, BinaryOperatorOpCode.Division,
                (lhs, rhs) => LLVM.BuildFDiv(_builder, lhs, rhs, "divtmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Float, BinaryOperatorOpCode.Modulo,
                (lhs, rhs) => LLVM.BuildFRem(_builder, lhs, rhs, "modtmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Bool, BinaryOperatorOpCode.LessThan,
                (lhs, rhs) => LLVM.BuildFCmp(_builder, LLVMRealPredicate.LLVMRealULT, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Bool, BinaryOperatorOpCode.LessThanEq,
                (lhs, rhs) => LLVM.BuildFCmp(_builder, LLVMRealPredicate.LLVMRealULE, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Bool, BinaryOperatorOpCode.GreaterThan,
                (lhs, rhs) => LLVM.BuildFCmp(_builder, LLVMRealPredicate.LLVMRealUGT, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Bool, BinaryOperatorOpCode.GreaterThanEq,
                (lhs, rhs) => LLVM.BuildFCmp(_builder, LLVMRealPredicate.LLVMRealUGE, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Bool, BinaryOperatorOpCode.Equality,
                (lhs, rhs) => LLVM.BuildFCmp(_builder, LLVMRealPredicate.LLVMRealUEQ, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Float, DefaultTypes.Bool, BinaryOperatorOpCode.NotEquality,
                (lhs, rhs) => LLVM.BuildFCmp(_builder, LLVMRealPredicate.LLVMRealUNE, lhs, rhs, "cmptmp"));

            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Int, BinaryOperatorOpCode.Addition,
                (lhs, rhs) => LLVM.BuildAdd(_builder, lhs, rhs, "addtmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Int, BinaryOperatorOpCode.Subtraction,
                (lhs, rhs) => LLVM.BuildSub(_builder, lhs, rhs, "subtmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Int, BinaryOperatorOpCode.Multiplication,
                (lhs, rhs) => LLVM.BuildMul(_builder, lhs, rhs, "multmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Int, BinaryOperatorOpCode.Division,
                (lhs, rhs) => LLVM.BuildSDiv(_builder, lhs, rhs, "divtmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Int, BinaryOperatorOpCode.Modulo,
                (lhs, rhs) => LLVM.BuildSRem(_builder, lhs, rhs, "modtmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Bool, BinaryOperatorOpCode.LessThan,
                (lhs, rhs) => LLVM.BuildICmp(_builder, LLVMIntPredicate.LLVMIntSLT, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Bool, BinaryOperatorOpCode.LessThanEq,
                (lhs, rhs) => LLVM.BuildICmp(_builder, LLVMIntPredicate.LLVMIntSLE, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Bool, BinaryOperatorOpCode.GreaterThan,
                (lhs, rhs) => LLVM.BuildICmp(_builder, LLVMIntPredicate.LLVMIntSGT, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Bool, BinaryOperatorOpCode.GreaterThanEq,
                (lhs, rhs) => LLVM.BuildICmp(_builder, LLVMIntPredicate.LLVMIntSGE, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Bool, BinaryOperatorOpCode.Equality,
                (lhs, rhs) => LLVM.BuildICmp(_builder, LLVMIntPredicate.LLVMIntEQ, lhs, rhs, "cmptmp"));
            _CreateBinaryOpFunction(DefaultTypes.Int, DefaultTypes.Bool, BinaryOperatorOpCode.NotEquality,
                (lhs, rhs) => LLVM.BuildICmp(_builder, LLVMIntPredicate.LLVMIntNE, lhs, rhs, "cmptmp"));
        }

        private LLVMValueRef _CreateBoolCast(LLVMValueRef incoming)
            => incoming;//LLVM.BuildICmp(_builder, LLVMIntPredicate.LLVMIntNE, incoming, LLVM.ConstInt(LLVM.Int32Type(), 0, true), "boolcast");

        private delegate LLVMValueRef BinaryAction(LLVMValueRef left, LLVMValueRef right);
        private void _CreateBinaryOpFunction(INodeType paramTypes, INodeType returnType, string op, BinaryAction action)
        {
            var llvmParamType = _llvmTypes[paramTypes];
            var llvmReturnType = _llvmTypes[returnType];
            var name = _GetBinaryOpName(op, paramTypes, returnType);

            var type = LLVM.FunctionType(llvmReturnType, new[] { llvmParamType, llvmParamType }, false);
            var func = LLVM.AddFunction(_module, name, type);
            func.SetLinkage(LLVMLinkage.LLVMInternalLinkage);
            var entry = LLVM.AppendBasicBlock(func, "entry");
            LLVM.PositionBuilderAtEnd(_builder, entry);

            var lhs = LLVM.GetParam(func, 0);
            LLVM.SetValueName(lhs, "lhs");
            var rhs = LLVM.GetParam(func, 1);
            LLVM.SetValueName(rhs, "rhs");

            var allocaL = _CreateEntryBlockAlloca(func, "inLhs", llvmParamType);
            LLVM.BuildStore(_builder, lhs, allocaL);
            var loadedL = LLVM.BuildLoad(_builder, allocaL, "inLhs");

            var allocaR = _CreateEntryBlockAlloca(func, "inRhs", llvmParamType);
            LLVM.BuildStore(_builder, rhs, allocaR);
            var loadedR = LLVM.BuildLoad(_builder, allocaR, "inRhs");

            LLVM.BuildRet(_builder, action(loadedL, loadedR));
            LLVM.VerifyFunction(func, LLVMVerifierFailureAction.LLVMPrintMessageAction);
            if(OPTIMIZE) LLVM.RunFunctionPassManager(_functionPassManager, func);
        }

        private string _GetBinaryOpName(BinaryOperatorNode node)
            => _GetBinaryOpName(node.Operator, node.Type, node.ReturnType);

        private string _GetBinaryOpName(string op, INodeType type, INodeType returnType)
        {
            return $"__binary{op}{type}TO{returnType}__";
        }
    }
}
