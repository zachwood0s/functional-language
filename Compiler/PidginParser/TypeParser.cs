using Compiler.AST.Types;
using Pidgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pidgin.Parser;

namespace Compiler.PidginParser
{
    public class TypeParser
    {
        public static readonly Parser<char, VariableType> VariableType
            = Map(ident => new VariableType(ident), IdentifierParser.UpperIdentifier);

        public static readonly Parser<char, FunctionType> FunctionType
            = Map((param, ret) => new FunctionType(param.ToList(), ret),
                Rec(() => _functionPartType).SeparatedAtLeastOnce(Utils.Token(",")),
                Utils.Token("->").Then(Rec(() => _functionPartType)));

        private static readonly Parser<char, INodeType> _functionPartType
            = VariableType.Cast<INodeType>()
            .Or(Utils.Parenthesised(FunctionType).Cast<INodeType>());

        public static readonly Parser<char, INodeType> AnyType
            = Try(FunctionType.Cast<INodeType>())
            .Or(VariableType.Cast<INodeType>());



    }
}
