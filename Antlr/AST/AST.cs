using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST
{
    public class AST
    {
        private ASTNode _root;
        public ASTNode Root => _root;

        public AST(ASTNode root)
        {
            _root = root;
        }
    }
}
