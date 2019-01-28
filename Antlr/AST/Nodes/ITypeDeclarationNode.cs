using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr.AST.Types;

namespace ZAntlr.AST.Nodes
{
    public interface ITypeDeclarationNode<out T> where T : INodeType
    {
        string Name { get; }
        T Type { get; }
        SourcePosition SourcePosition {get;}
    }
}
