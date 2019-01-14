using Compiler.AST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class TypeCastNode : ExprAST
    {
        private INodeType _toType;
        private ExprAST _expression;

        public ExprAST Expression => _expression;
        public INodeType FromType { get; set; }
        public INodeType ToType => _toType;

        public TypeCastNode(INodeType toType, ExprAST expression)
        {
            _toType = toType;
            _expression = expression;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
