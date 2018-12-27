using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Parser.Basics;
using Compiler.AST;
using Compiler.AST.Nodes;

namespace Compiler.Parser.Expressions
{
    public static class ExpressionParser
    {
        public static readonly Parser<ASTNode> Factor =
            (from lparen in Parse.Char('(')
             from expr in Parse.Ref(() => Expression)
             from rparen in Parse.Char(')')
             select expr).Named("expression")
            .XOr(ConstantParser.Constant);

        public static readonly Parser<ASTNode> Operand =
            ((from sign in Parse.Char('-')
              from factor in Factor
              select new UnaryOperator(factor, UnaryOperatorType.Negate)
              ).XOr(Factor)).Token();

        public static readonly Parser<ASTNode> Term = 
            Parse.ChainOperator(
                OperatorParser.Multiplication
                    .Or(OperatorParser.Division)
                    .Or(OperatorParser.Modulo),
                Operand,
                MakeBinary);

        public static readonly Parser<ASTNode> Expression =
            Parse.ChainOperator(
                OperatorParser.Addition.Or(OperatorParser.Subtraction), 
                Term, 
                MakeBinary);

        public static ASTNode MakeBinary(BinaryOperatorType op, ASTNode left, ASTNode right) =>
            new BinaryOperator(left, right, op);
    }
}
