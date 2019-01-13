using Pidgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.TypeCheckVisitor
{
    public class TypeCheckException: Exception
    {
        public TypeCheckException(string message) : base($"Type check exception: {message}") { }
    }
}
