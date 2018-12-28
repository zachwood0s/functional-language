using Compiler.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class UnaryOperatorNode: ExprAST
    {
        private ASTNode _node;
        private UnaryOperatorType _operator;

        public ASTNode Node => _node;
        public UnaryOperatorType Operator;

        public UnaryOperatorNode(ASTNode node, UnaryOperatorType op)
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
