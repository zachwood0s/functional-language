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
            = from ident in IdentifierParser.LowerIdentifier.Labelled("function identifier")
              from colon in Utils.Token(":").Labelled("colon")
              from parameters in IdentifierParser.UpperIdentifier.Separated(Utils.Token(","))
              from returnSeparator in Utils.Token("->")
              from returnType in IdentifierParser.UpperIdentifier
              select new PrototypeNode(ident, parameters.ToList(), returnType);
            
    }
}
