using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.CodeGenVisitor
{
    public class CodeGenException<T>: Exception
    {
        public CodeGenException(string message, ITextSpan<T> span): base($"Code generation error at {span.Start}: {message}")
        {
        }
    }
}
