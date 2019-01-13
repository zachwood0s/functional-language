using Compiler.AST;
using Compiler.AST.Nodes;
using Pidgin;
using Pidgin.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.PidginParser
{
    public static class OperatorParser
    {

        public static Parser<char, Func<ExprAST, ExprAST, ExprAST>> MakeBinary(Parser<char, string> op)
            => op.Select<Func<ExprAST, ExprAST, ExprAST>>(type => (l, r) => new BinaryOperatorNode(l, r, type));

        public static Parser<char, Func<ExprAST, ExprAST, ExprAST>> BinaryOp(string op)
            => MakeBinary(Utils.Token(op)).Labelled("operator");


        public static readonly List<BinaryOperator> Operators = new List<BinaryOperator>()
        {
            new BinaryOperator(BinaryOperatorOpCode.Addition, 6, BinaryOperatorType.LeftAssociative),
            new BinaryOperator(BinaryOperatorOpCode.Subtraction, 6, BinaryOperatorType.LeftAssociative),
            new BinaryOperator(BinaryOperatorOpCode.Multiplication, 7, BinaryOperatorType.LeftAssociative),
            new BinaryOperator(BinaryOperatorOpCode.Division, 7, BinaryOperatorType.LeftAssociative),

            new BinaryOperator(BinaryOperatorOpCode.LessThan, 4, BinaryOperatorType.NonAssociative),
            new BinaryOperator(BinaryOperatorOpCode.LessThanEq, 4, BinaryOperatorType.NonAssociative),
            new BinaryOperator(BinaryOperatorOpCode.GreaterThan, 4, BinaryOperatorType.NonAssociative),
            new BinaryOperator(BinaryOperatorOpCode.GreaterThanEq, 4, BinaryOperatorType.NonAssociative),
            new BinaryOperator(BinaryOperatorOpCode.Equality, 4, BinaryOperatorType.NonAssociative),

            new BinaryOperator(BinaryOperatorOpCode.LogicalAnd, 3, BinaryOperatorType.RightAssociative),
            new BinaryOperator(BinaryOperatorOpCode.LogicalOr, 2, BinaryOperatorType.RightAssociative),
        };

        public static IEnumerable<OperatorTableRow<char, ExprAST>> GenerateOperatorTable()
            => from op in Operators
               orderby op.Precedence descending
               group op.GetRow() by op.Precedence into grouping
               select grouping.Aggregate((prod, next) => prod.And(next));


        public static class BinaryOperatorOpCode
        {
            public const string Addition = "+";
            public const string Subtraction = "-";
            public const string Multiplication = "*";
            public const string Division = "/";
            public const string Modulo = "%";
            public const string Assign = "=";

            public const string LessThan = "<";
            public const string LessThanEq = "<=";
            public const string GreaterThan = ">";
            public const string GreaterThanEq = ">=";
            public const string Equality = "==";

            public const string LogicalAnd = "&&";
            public const string LogicalOr = "||";
        }


        public class BinaryOperator
        {
            public string Op { get; set; }
            public int Precedence { get; set; }
            public BinaryOperatorType Mode { get; set; }

            public BinaryOperator(string op, int prec, BinaryOperatorType mode)
            {
                Op = op;
                Precedence = prec;
                Mode = mode;
            }

            public OperatorTableRow<char, ExprAST> GetRow() => Operator.Binary(Mode, BinaryOp(Op));
        }
    }
}
