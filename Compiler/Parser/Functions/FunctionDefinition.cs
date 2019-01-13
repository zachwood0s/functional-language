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
    public static class FunctionDefinitionParser
    {
        public static readonly Parser<string> Parameter =
            from ident in IdentifierParser.LowerIdentifier
            from comma in Parse.Char(',').Token().Optional()
            select ident;

        public static Parser<IEnumerable<string>> ParameterList(int count) =>
            from lparen in Parse.Char('(').Token()
            from identifier in Parameter.Named("parameter").Repeat(count)
            from rparen in Parse.Char(')').Token()
            select identifier;

        public static readonly Parser<FunctionNode> FunctionDefinition =
            from wspace in Parse.WhiteSpace.Many()
            from proto in FunctionDeclarationParser.FunctionDeclaration
            from newline in WhiteSpace.NewLine
            from identifier in Parse.String(proto.Name)
                                    .Named($"function identifier (e.g. {proto.Name})")
            from args in ParameterList(proto.Type.ParameterTypes.Count)
            from equal in OperatorParser.Assign
            from body in ExpressionParser.Expression
            select new FunctionNode(proto, args.ToList(), body);

    }
}
