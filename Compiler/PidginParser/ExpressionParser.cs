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
using Compiler.AST.Types;
using System.Text.RegularExpressions;

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
                .Select<ExprAST>(value => new ConstantIntegerNode(value))
                .Labelled("integer literal");

        private static readonly Parser<char, ExprAST> _literalFloat
            = Utils.Token(Utils.UnsignedReal())
            .Select<ExprAST>(value => new ConstantDoubleNode(value))
            .Labelled("float literal");

        private static readonly Parser<char, char> _charContent
            = Try(AnyCharExcept('\'', '\\')).Or(Char('\\').Then(Any, (escape, following) => Regex.Unescape(@"\" + following)[0]));

        private static readonly Parser<char, ExprAST> _literalChar
            = Utils.Token(_charContent.Between(Char('\''))
                .Select<ExprAST>(x => new ConstantCharNode(x)));

        private static readonly Parser<char, ExprAST> _ifExpression
            = Map(
                (cond, then, _else) => new IfExpressionNode(cond, then, _else),
                Utils.Token("if").Then(Rec(() => Expression)),
                Utils.Token("then").Then(Rec(() => Expression)),
                Utils.Token("else").Then(Rec(() => Expression)))
            .Cast<ExprAST>();

        private static readonly Parser<char, ExprAST> _letExpression
            = Map(
                (assignments, expression) => new LetExpressionNode(assignments.ToList(), expression),
                Rec(() => _letPart),
                Rec(() => Expression))
            .Cast<ExprAST>();

        private static readonly Parser<char, IEnumerable<LetAssignment>> _letPart
            = Rec(() => Try(_assignment)).SeparatedAndOptionallyTerminatedAtLeastOnce(Utils.Token(";"))
                .Between(Utils.Token("let"), Utils.Token("in"));

        private static readonly Parser<char, ExprAST> _inPart
            = Utils.Token("in").Then(Rec(() => Expression)).Labelled("let expression");


        private static readonly Parser<char, LetAssignment> _assignment
            = Map(
                (type, ident, expr) => new LetAssignment { Identifier = ident, Expression = expr, Type = type },
                Rec(() => _assignmentType).Before(Utils.Token(";")).Labelled("type declaration"),
                IdentifierParser.LowerIdentifier.Labelled("identifier"),
                Utils.Token("=").Then(Rec(() => Expression))).Labelled("assignment");

        private static readonly Parser<char, INodeType> _assignmentType
            = IdentifierParser.LowerIdentifier.Labelled("identifier")
            .Then(Utils.Token(":"))
            .Then(TypeParser.AnyType);

        private static Parser<char, ExprAST> _BuildExpressionParser()
        {
            Parser<char, ExprAST> expr = null;
            var term = OneOf(
                _letExpression.Labelled("let expression"),
                _ifExpression.Labelled("if expression"),
                _identifier,
                Try(_literalFloat).Or(Try(_literal)).Or(Try(_literalChar)),
                _Parenthesised(Rec(() => expr)).Labelled("parenthesised expression")
                );

            var call = Utils.Parenthesised(Rec(() => expr).Separated(Utils.Token(",")))
                .Select<Func<ExprAST, ExprAST>>(args => method => new FunctionCallNode(method, args.ToList()))
                .Labelled("function call");

            var cast = Utils.Token("::").Then(TypeParser.AnyType)
                .Select<Func<ExprAST, ExprAST>>(nodeType => method => new TypeCastNode(nodeType, method))
                .Labelled("type cast");

            var opTable = OperatorParser.GenerateOperatorTable();
            opTable = opTable.Prepend(Operator.PostfixChainable(call));
            opTable = opTable.Append(Operator.Postfix(cast));

            expr = Pidgin.Expression.ExpressionParser.Build(
                term,
                opTable
            );
            return expr;
        }



        public static readonly Parser<char, ExprAST> Expression = _BuildExpressionParser();
    }
}
