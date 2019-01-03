using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parser.Basics
{
    public static class OperatorParser
    {
        public static Parser<string> Operator(string op) =>
            Parse.String(op).Text().Token();

        public static readonly Parser<string> Addition =
            Operator(BinaryOperator.Addition);

        public static readonly Parser<string> Subtraction =
            Operator(BinaryOperator.Subtraction);

        public static readonly Parser<string> Multiplication =
            Operator(BinaryOperator.Multiplication);

        public static readonly Parser<string> Division =
            Operator(BinaryOperator.Division);

        public static readonly Parser<string> Modulo =
            Operator(BinaryOperator.Modulo);

        public static readonly Parser<string> Assign =
            Operator(BinaryOperator.Assign);

        public static readonly Dictionary<string, int> BinopPrecedence = new Dictionary<string, int>()
        {
            [BinaryOperator.LessThan] = 10,
            [BinaryOperator.Addition] = 20,
            [BinaryOperator.Subtraction] = 20,
            [BinaryOperator.Multiplication] = 40
        };
    
        public static int GetOpPrecedence(string op) => 
            BinopPrecedence.TryGetValue(op, out var val) ? val : -1;
    }
}
