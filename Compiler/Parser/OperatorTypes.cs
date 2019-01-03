using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parser
{
    public static class BinaryOperator
    {
        public const string Addition = "+";
        public const string Subtraction = "-";
        public const string Multiplication = "*";
        public const string Division = "/";
        public const string Modulo = "%";
        public const string Assign = "=";
        public const string LessThan = "<";
    }

    public enum UnaryOperatorType
    {
        Negate,
        Positive,
        LogicalCompliment
    }
}
