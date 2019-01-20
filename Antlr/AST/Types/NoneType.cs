using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Types
{
    public class NoneType : ASTNode, INodeType
    {
        public override void Accept(IASTVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public bool IsMatch(INodeType node)
            => node is NoneType;
    }
}
