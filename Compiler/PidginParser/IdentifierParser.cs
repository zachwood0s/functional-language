using Compiler.AST;
using Compiler.AST.Nodes;
using Compiler.AST.Types;
using Pidgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace Compiler.PidginParser
{
    public static class IdentifierParser
    {

        public static readonly Parser<char, string> IdentifierCharacter =
            LetterOrDigit.Or(Char('_')).ManyString();

        public static readonly Parser<char, string> LowerIdentifier =
            Lookahead(Not(OneOf(Reserved.Keywords.Select(x => String(x)))))
            .Then(Utils.Token(Lowercase.Then(IdentifierCharacter, (h, t) => h + t)));

        public static readonly Parser<char, ExprAST> LowerIdentifierNode =
            LowerIdentifier.Then(CurrentPos, (ident, pos) => new IdentifierNode(ident, pos)).Cast<ExprAST>();

        public static readonly Parser<char, string> UpperIdentifier =
            Utils.Token(Uppercase.Then(IdentifierCharacter, (h, t) => h + t));

    }
}
