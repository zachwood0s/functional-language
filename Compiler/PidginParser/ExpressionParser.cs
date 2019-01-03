using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Parser.Basics;
using Compiler.AST;
using Compiler.AST.Nodes;

using Pidgin;
using Pidgin.Expression;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace Compiler.PidginParser.Expressions
{
    public static class ExpressionParser
    {
        private static Parser<char, T> _Parenthesised<T>(Parser<char, T> parser)
            => parser.Between(Utils.Token("("), Utils.Token(")"));

        private static readonly Parser<char, ExprAST> _identifier 
            = IdentifierParser.LowerIdentifierNode
                .Labelled("identifier");

        private static readonly Parser<char, ExprAST> _literal 
            = Utils.Token(DecimalNum)
                .Select<ExprAST>(value => new ConstantDoubleNode(value))
                .Labelled("decimal literal");

        private static readonly Parser<char, ExprAST> _ifExpression
            = Map(
                (cond, then, _else) => new IfExpressionNode(cond, then, null),
                Utils.Token("if").Then(Rec(() => Expression)),
                Utils.Token("then").Then(Rec(() => Expression)),
                Utils.Token("else").Then(Rec(() => Expression)).Optional())
            .Select<ExprAST>(x => x);

        private static readonly Parser<char, ExprAST> _letExpression
            = Map(
                (assignments, expression) => new LetExpressionNode(assignments.ToList(), expression),
                Utils.Token("let").Then(Rec(() => _assignment).SeparatedAndOptionallyTerminated(Utils.Token(";"))),
                Utils.Token("in").Then(Rec(() => Expression)))
            .Select<ExprAST>(x => x);

        private static readonly Parser<char, LetAssignment> _assignment
            = Map(
                (ident, expr) => new LetAssignment { Identifier = ident, Expression = expr },
                IdentifierParser.LowerIdentifier.Labelled("identifier"),
                Utils.Token("=").Then(Rec(() => Expression)));

        private static Parser<char, ExprAST> _BuildExpressionParser()
        {
            Parser<char, ExprAST> expr = null;

            var term = OneOf(
                _letExpression,
                _ifExpression,
                _identifier,
                _literal,
                _Parenthesised(Rec(() => expr)).Labelled("parenthesised expression")
                );

            var call = Utils.Parenthesised(Rec(() => expr).Separated(Utils.Token(",")))
                .Select<Func<ExprAST, ExprAST>>(args => method => new FunctionCallNode("fake", args.ToList()))
                .Labelled("function call");

            var opTable = OperatorParser.GenerateOperatorTable();
            opTable = opTable.Prepend(Operator.PostfixChainable(call));

            expr = Pidgin.Expression.ExpressionParser.Build(
                term,
                opTable
            ).Labelled("expression");

            return expr;
        }

        public static readonly Parser<char, ExprAST> Expression = _BuildExpressionParser();
    }
}
