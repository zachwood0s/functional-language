using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class AssignmentNode : ASTNode
    {
        private string _identifier;
        private ASTNode _expression;

        public string Identifier => _identifier;
        public ASTNode Expression => _expression;

        public AssignmentNode(string identifier, ASTNode expression)
        {
            _identifier = identifier;
            _expression = expression;
        }
        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
