using Parser.Basics;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Functions
{
    public static class FunctionDefinitionParser
    {

        public static readonly Parser<string> FunctionDefinition =
            from ident in IdentifierParser.LowerIdentifier
            from colon in FunctionIdentifierSeparator
            from parameters in ParameterList
            from returnSeparator in FunctionReturnSeparator 
            from returnType in ReturnType
            select $"Function: {ident} with params {parameters} and return {returnType}";

        public static readonly Parser<string> ParameterList =
            from typeName in TypeParser.TypeUsage
            from restTypes in Parse.Ref(() => ParameterListDelimeter).Then(_ => TypeParser.TypeUsage).Many()
            select typeName +","+ string.Join(", ", restTypes);

        public static readonly Parser<string> ReturnType =
            from typeName in TypeParser.TypeUsage
            select typeName;

        public static readonly Parser<char> ParameterListDelimeter =
            Parse.Char(',').Token();

        public static readonly Parser<char> FunctionIdentifierSeparator =
            Parse.Char(':').Token();

        public static readonly Parser<string> FunctionReturnSeparator =
            from op in Parse.String("->").Token()
            select new string(op.ToArray());
    }
}
