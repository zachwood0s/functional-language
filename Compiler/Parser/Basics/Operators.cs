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
        public static Parser<BinaryOperatorType> Operator(string op, BinaryOperatorType opType) =>
            Parse.String(op).Token().Return(opType);

        public static readonly Parser<BinaryOperatorType> Addition =
            Operator("+", BinaryOperatorType.Addition);

        public static readonly Parser<BinaryOperatorType> Subtraction =
            Operator("-", BinaryOperatorType.Subtraction);

        public static readonly Parser<BinaryOperatorType> Multiplication =
            Operator("*", BinaryOperatorType.Multiplication);

        public static readonly Parser<BinaryOperatorType> Division =
            Operator("/", BinaryOperatorType.Division);

        public static readonly Parser<BinaryOperatorType> Modulo =
            Operator("%", BinaryOperatorType.Modulo);

        public static readonly Parser<BinaryOperatorType> Assign =
            Operator("=", BinaryOperatorType.Assign);
    }
}
