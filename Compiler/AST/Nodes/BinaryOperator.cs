using Compiler.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class BinaryOperator: ASTNode
    {
        private ASTNode _left;
        private ASTNode _right;
        private BinaryOperatorType _operator;

        public ASTNode Left => _left;
        public ASTNode Right => _right;
        public BinaryOperatorType Operator => _operator;

        public BinaryOperator(ASTNode left, ASTNode right, BinaryOperatorType op)
        {
            _left = left;
            _right = right;
            _operator = op;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
