using Compiler.AST.Nodes;
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
    public static class FunctionaDeclarationParser
    {
        public static readonly Parser<char, PrototypeNode> FunctionDeclaration
            = Map(
                (ident, type) => new PrototypeNode(ident, type),
                IdentifierParser.LowerIdentifier,
                Utils.Token(":").Then(TypeParser.FunctionType));
    }
}
