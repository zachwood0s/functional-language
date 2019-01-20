using ZAntlr.AST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST
{
    public abstract class ASTNode
    {
        public abstract void Accept(IASTVisitor visitor);
    }

    public abstract class ExprAST: ASTNode
    {
        public INodeType Type { get; set; }
    }
}
