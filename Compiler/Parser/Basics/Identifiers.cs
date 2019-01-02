using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Parser.Basics
{
    public static class IdentifierParser
    {

        public static readonly Parser<char> IdentifierCharacter =
            from _char in Parse.LetterOrDigit.XOr(Parse.Char('_'))
            select _char;

        public static readonly Parser<string> UpperIdentifier =
            from ident in Parse.Identifier(Parse.Upper, IdentifierCharacter)
            select ident;

        public static readonly Parser<string> LowerIdentifier =
            from ident in Parse.Identifier(Parse.Lower, IdentifierCharacter)
                .Where(x => !Reserved.Keywords.Contains(x))
            select ident;
            


    }
}
