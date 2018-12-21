using Sprache;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Basics
{
    public static class TypeParser
    {
        public static readonly Parser<string> TypeUsage =
            from identifier in IdentifierParser.UpperIdentifier.XOr(Parse.Ref(() => BracketType))
            select identifier;

        public static readonly Parser<string> BracketType =
            from lbracket in Parse.Char('[')
            from type in TypeUsage
            from rbracket in Parse.Char(']')
            select $"[{type}]";
    }
}
