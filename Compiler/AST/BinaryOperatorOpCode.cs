using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST
{
    public static class BinaryOperatorOpCode
    {
        public static readonly string Addition = "+";
        public static readonly string Subtraction = "-";
        public static readonly string Multiplication = "*";
        public static readonly string Division = "/";
        public static readonly string Modulo = "%";
        public static readonly string LessThan = "<";
        public static readonly string LessThanEq = "<=";
        public static readonly string GreaterThan = ">";
        public static readonly string GreaterThanEq = ">=";
        public static readonly string Equality = "==";
        public static readonly string NotEquality = "!=";
    }
}
