using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class ImportNode: ASTNode
    {
        private string _moduleName;
        private string _asName;

        public string ModuleName => _moduleName;
        public string AsName => _asName;

        public ImportNode(string module, string asName)
        {
            _moduleName = module;
            _asName = asName;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
