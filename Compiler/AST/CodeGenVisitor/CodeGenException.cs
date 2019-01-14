using Pidgin;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.CodeGenVisitor
{
    public class CodeGenException: Exception
    {
        public CodeGenException(string message, SourcePos span): base($"Code generation error at line {span.Line}, col {span.Col}: {message}")
        {
        }
    }
}
