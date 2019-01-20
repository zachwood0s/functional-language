using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class ProgramNode : ASTNode
    {
        private List<ASTNode> _declarations;
        private List<ASTNode> _definitions;

        public List<ASTNode> Declarations => _declarations;
        public List<ASTNode> Definitions => _definitions;

        public ProgramNode(List<ASTNode> defs, List<ASTNode> decls)
        {
            _declarations = decls;
            _definitions = defs;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
