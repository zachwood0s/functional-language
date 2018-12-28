using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class PrototypeNode : ASTNode
    {
        private string _name;
        private List<string> _argTypes;
        private string _return;

        public string Name => _name;
        public IReadOnlyList<string> ArgTypes => _argTypes;
        public string Return => _return;

        public PrototypeNode(string name, List<string> argTypes, string ret)
        {
            _name = name;
            _argTypes = argTypes;
            _return = ret;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
