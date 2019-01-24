using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Errors
{
    public static class ErrorIndex
    {
        public static readonly CompilerMessage AbortError = new CompilerMessage("aborting due to previous error", MessageType.Error);
        public static readonly Dictionary<string, CompilerMessage> Errors = new Dictionary<string, CompilerMessage>()
        {

        };

        public static CompilerMessage GetCompilerMessage(string errorCode)
        {
            return Errors[errorCode];
        }
    }
}
