using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Parser.Basics
{
    public static class IdentifierParser
    {

        public static readonly Parser<string> IdentifierCharacter =
            from letters in Parse.LetterOrDigit.XOr(Parse.Char('_')).Many()
            select new string(letters.ToArray());

        public static readonly Parser<string> UpperIdentifier =
            from first in Parse.Upper.Once()
            from rest in IdentifierCharacter
            select new string(first.Concat(rest).ToArray());

        public static readonly Parser<string> LowerIdentifier =
            from first in Parse.Lower.Once()
            from rest in IdentifierCharacter
            select new string(first.Concat(rest).ToArray());


    }
}
