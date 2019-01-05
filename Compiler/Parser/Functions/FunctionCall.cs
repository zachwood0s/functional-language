using Compiler.AST.Nodes;
using Compiler.Parser.Basics;
using Compiler.Parser.Expressions;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parser.Functions
{
    public class FunctionCallParser
    {
        public static readonly Parser<FunctionCallNode> FunctionCall =
            from ident in IdentifierParser.LowerIdentifier.Named("identifier")
            from lparen in Parse.Char('(').Token()
            from arguments in Parse.XDelimitedBy(ExpressionParser.Expression, Parse.Char(',').Token())
            from rparen in Parse.Char(')').Token()
            select new FunctionCallNode(null, arguments.ToList());
    }
}
