using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class ModuleNode: ASTNode
    {
        private string _name;
        private List<string> _exports;

        public string Name => _name;
        public List<string> Exports => _exports;

        public ModuleNode(string name, List<string> exports)
        {
            _name = name;
            _exports = exports;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
