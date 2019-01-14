using Compiler.AST.Nodes;
using Compiler.AST.Types;
using LLVMSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.CodeGenVisitor
{
    public partial class ASTCodeGenVisitor
    {
        private List<TypeCast> _typeCasts;
        private class TypeCast
        {
            public INodeType To { get; set; }
            public INodeType From { get; set; }
            public LLVMValueRef Function { get; set; }

            public override bool Equals(object obj)
                => obj is TypeCast a
                ? a.From.IsMatch(From) && a.To.IsMatch(To)
                : false;
        }

        public void Visit(TypeCastNode node)
        {
            node.Expression.Accept(this);
            var exprVal = _valueStack.Pop();
            if (node.FromType == null) throw new CodeGenException("It appears that a cast has no 'from' type. Did the type checker run?", new Pidgin.SourcePos());
            if (node.FromType.IsMatch(node.ToType))
            {
                _valueStack.Push(exprVal);
                return;
            }

            var typeCast = _typeCasts.Find(x => x.Equals(new TypeCast() { From = node.FromType, To = node.ToType }));
            if (typeCast != null)
            {
                var call = LLVM.BuildCall(_builder, typeCast.Function, new[] { exprVal }, "convCall");
                _valueStack.Push(call);
            }

            else throw new CodeGenException($"No valid type cast for {node.FromType} to {node.ToType}", new Pidgin.SourcePos());
        }

        private void _SetupDefaultCasts()
        {
            var iToF = _CreateInlineFunction(LLVM.Int32Type(), LLVM.FloatType(),
                (alloca, type) => LLVM.BuildSIToFP(_builder, alloca, type, "conv"));

            var fToI = _CreateInlineFunction(LLVM.FloatType(), LLVM.Int32Type(),
                (alloca, type) => LLVM.BuildFPToSI(_builder, alloca, type, "conv"));

            _typeCasts = new List<TypeCast>()
            {
                new TypeCast(){From = DefaultTypes.Int, To = DefaultTypes.Float, Function = iToF},
                new TypeCast(){From = DefaultTypes.Float, To = DefaultTypes.Int, Function = fToI}
            };
        }

        private LLVMValueRef _CreateInlineFunction(LLVMTypeRef from, LLVMTypeRef to, Func<LLVMValueRef, LLVMTypeRef, LLVMValueRef> action)
        {
            var type = LLVM.FunctionType(to, new[] { from }, false);
            var func = LLVM.AddFunction(_module, "", type);
            func.SetLinkage(LLVMLinkage.LLVMExternalLinkage);
            var entry = LLVM.AppendBasicBlock(func, "entry");
            LLVM.PositionBuilderAtEnd(_builder, entry);

            var param = LLVM.GetParam(func, 0);
            LLVM.SetValueName(param, "in");

            var alloca = _CreateEntryBlockAlloca(func, "in", from);
            LLVM.BuildStore(_builder, param, alloca);
            var loaded = LLVM.BuildLoad(_builder, alloca, "in");

            LLVM.BuildRet(_builder, action(loaded, to));
            LLVM.VerifyFunction(func, LLVMVerifierFailureAction.LLVMPrintMessageAction);
            if(OPTIMIZE) LLVM.RunFunctionPassManager(_functionPassManager, func);
            return func;
        }
    }
}
