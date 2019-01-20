using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class UnaryOperatorNode: ExprAST
    {
        private ASTNode _node;
        private string _operator;

        public ASTNode Node => _node;
        public string Operator => _operator;

        public UnaryOperatorNode(ASTNode node, string op)
        {
            _node = node;
            _operator = op;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
