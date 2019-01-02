using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Parser.Basics;
using Compiler.AST;
using Compiler.AST.Nodes;
using Compiler.Parser.Functions;

namespace Compiler.Parser.Expressions
{
    public static class ExpressionParser
    {
        public static readonly Parser<ExprAST> IfExpression =
            from _if in Parse.String("if").Token().Named(Reserved.Keyword("if"))
            from ifcond in Expression
            from _then in Parse.String("then").Token().Named(Reserved.Keyword("then"))
            from then in Expression
            from elseExpression in Parse.String("else").Token().Named(Reserved.Keyword("else"))
                .Then(_ => Expression).Optional()
            select new IfExpressionNode(ifcond, then, elseExpression);

        public static readonly Parser<ExprAST> LetExpression =
            from _let in Parse.String("let").Token().Named(Reserved.Keyword("let"))
            from assignments in Parse.DelimitedBy(Assignment, Parse.Char(';').Token().Named("delimiter"))
            from _in in Parse.String("in").Token().Named(Reserved.Keyword("in"))
            from expression in Expression.Named("expression")
            select new LetExpressionNode(assignments.ToList(), expression);


        public static readonly Parser<LetAssignment> Assignment =
            from ident in IdentifierParser.LowerIdentifier.Named("identifier")
            from _equal in Parse.Char('=').Token()
            from expr in Expression
            select new LetAssignment { Identifier = ident, Expression = expr };


        public static readonly Parser<ExprAST> Factor =
            (from lparen in Parse.Char('(')
             from expr in Parse.Ref(() => Expression)
             from rparen in Parse.Char(')')
             select expr).Named("expression")
            .XOr(ConstantParser.Constant)
            .XOr(IfExpression)
            .XOr(LetExpression)
            .XOr(FunctionCallParser.FunctionCall
                .Or<ExprAST>(IdentifierParser.LowerIdentifier.Span()
                    .Select(x => new IdentifierNode(x.Value, x)).Named("identifier")));

        public static readonly Parser<ExprAST> Operand =
            ((from sign in Parse.Char('-')
              from factor in Factor
              select new UnaryOperatorNode(factor, UnaryOperatorType.Negate)
              ).XOr(Factor)).Token();

        public static readonly Parser<ExprAST> Term = 
            Parse.ChainOperator(
                OperatorParser.Multiplication
                    .Or(OperatorParser.Division)
                    .Or(OperatorParser.Modulo),
                Operand,
                MakeBinary);

        public static readonly Parser<ExprAST> Expression =
            Parse.ChainOperator(
                OperatorParser.Addition.Or(OperatorParser.Subtraction), 
                Term, 
                MakeBinary).Named("expression");

        public static ExprAST MakeBinary(BinaryOperatorType op, ExprAST left, ExprAST right) =>
            new BinaryOperatorNode(left, right, op);
    }
}
