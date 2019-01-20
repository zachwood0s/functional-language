using ZAntlr.AST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class BinaryOperatorNode: ExprAST
    {
        private ASTNode _left;
        private ASTNode _right;
        private string _operator;

        public ASTNode Left => _left;
        public ASTNode Right => _right;
        public string Operator => _operator;

        public INodeType ReturnType { get; set; }

        public BinaryOperatorNode(ASTNode left, ASTNode right, string op)
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
