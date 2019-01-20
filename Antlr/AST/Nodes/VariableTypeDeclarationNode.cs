using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr.AST.Types;

namespace ZAntlr.AST.Nodes
{
    public class VariableTypeDeclarationNode : ASTNode
    {
        private VariableType _type;
        private string _name;

        public string Name => _name;
        public VariableType Type => _type;

        public VariableTypeDeclarationNode(string name, VariableType type)
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
