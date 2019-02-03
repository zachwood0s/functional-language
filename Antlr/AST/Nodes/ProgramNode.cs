using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr.AST.Types;

namespace ZAntlr.AST.Nodes
{
    public class ProgramNode : ASTNode
    {
        private List<ASTNode> _declarations;
        private List<ASTNode> _definitions;
        private ASTNode _module;
        private List<ImportNode> _imports;

        public List<ASTNode> Declarations => _declarations;
        public List<ASTNode> Definitions => _definitions;
        public ASTNode Module => _module;
        public List<ImportNode> Imports => _imports;

        public string FileLocation { get; set; }
        public string ParentDirectory { get; set; }

        public ProgramNode(ASTNode module, List<ASTNode> defs, List<ASTNode> decls, List<ImportNode> imports)
        {
            _module = module;
            _declarations = decls;
            _definitions = defs;
            _imports = imports;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
