using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class IdentifierNode : ExprAST
    {
        private string _name;
        public string Name => _name;

        public IdentifierNode(string name)
        {
            _name = name;
        }
        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
