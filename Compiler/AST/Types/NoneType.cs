using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Types
{
    public class NoneType : INodeType
    {
        public bool IsMatch(INodeType node)
            => node is NoneType;
    }
}
