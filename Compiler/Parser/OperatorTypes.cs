using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parser
{
    public enum BinaryOperatorType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Modulo
    }

    public enum UnaryOperatorType
    {
        Negate,
        Positive,
        LogicalCompliment
    }
}
