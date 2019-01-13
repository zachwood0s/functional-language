using Compiler.AST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class IdentifierTypeNode: ASTNode
    {
        private VariableType _type;
        private string _name;

        public VariableType Type => _type;
        public string Name => _name;

        public IdentifierTypeNode(string name, VariableType type)
        {
            _name = name;
            _type = type;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
