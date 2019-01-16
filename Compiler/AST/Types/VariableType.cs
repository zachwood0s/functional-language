using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Types
{
    public class VariableType : INodeType
    {
        private string _typeName;
        public string TypeName => _typeName;

        public VariableType(string typename)
        {
            _typeName = typename;
        }

        public bool IsMatch(INodeType node)
            => (node is VariableType n) 
            ? n.TypeName == _typeName 
            : false;

        public override int GetHashCode()
            => ToString().GetHashCode();

        public override bool Equals(object obj)
            => obj is VariableType n ? IsMatch(n) : false;

        public override string ToString() => _typeName;
    }

    public static class DefaultTypes
    {
        public static readonly VariableType Float = new VariableType("Float");
        public static readonly VariableType Int = new VariableType("Int");
        public static readonly VariableType Char = new VariableType("Char");
        public static readonly VariableType Bool = new VariableType("Bool");
        public static readonly VariableType Void = new VariableType("Void");
    }

}
