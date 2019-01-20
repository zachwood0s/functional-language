using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Types
{
    public interface INodeType
    {
        bool IsMatch(INodeType node);
    }
    /*
    public class NodeType
    {
        private string _typeName;

        public string TypeName => _typeName;
    }
    */
}
