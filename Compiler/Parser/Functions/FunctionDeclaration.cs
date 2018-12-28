using Compiler.AST.Nodes;
using Compiler.Parser.Basics;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Parser.Functions
{
    public static class FunctionDeclarationParser
    {
        public static readonly Parser<char> ParameterListDelimeter =
            Parse.Char(',').Token();

        public static readonly Parser<char> FunctionIdentifierSeparator =
            Parse.Char(':').Token();

        public static readonly Parser<string> FunctionReturnSeparator =
            from op in Parse.String("->").Token()
            select new string(op.ToArray());

        public static readonly Parser<PrototypeNode> FunctionDeclaration =
            from ident in IdentifierParser.LowerIdentifier
            from colon in FunctionIdentifierSeparator
            from parameters in ParameterList
            from returnSeparator in FunctionReturnSeparator
            from returnType in ReturnType
            select new PrototypeNode(ident, parameters.ToList(), returnType);

        public static readonly Parser<IEnumerable<string>> ParameterList =
            from types in Parse.DelimitedBy(TypeParser.TypeUsage, ParameterListDelimeter)
            select types;

        public static readonly Parser<string> ReturnType =
            from typeName in TypeParser.TypeUsage
            select typeName;

    }
}
