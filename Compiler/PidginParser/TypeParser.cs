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

        public static readonly Parser<char, FunctionType> ParamFunctionType
            = Map((param, ret) => new FunctionType(param.ToList(), ret),
                Rec(() => _functionPartType).SeparatedAtLeastOnce(Utils.Token(",")),
                Utils.Token("->").Then(Rec(() => _functionPartType)));

        public static readonly Parser<char, FunctionType> VoidFunctionType
            = Utils.Token("Void").Then(Utils.Token("->"))
            .Then(Rec(() => _functionPartType), (_, ret) => new FunctionType(ret));

        public static readonly Parser<char, FunctionType> FunctionType
            = Try(VoidFunctionType).Or(ParamFunctionType);

        private static readonly Parser<char, INodeType> _functionPartType
            = VariableType.Cast<INodeType>()
            .Or(Utils.Parenthesised(FunctionType).Cast<INodeType>());

        public static readonly Parser<char, INodeType> AnyType
            = Try(FunctionType.Cast<INodeType>())
            .Or(VariableType.Cast<INodeType>());



    }
}
