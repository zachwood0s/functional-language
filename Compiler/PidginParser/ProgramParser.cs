using Compiler.AST;
using Compiler.AST.Nodes;
using Pidgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace Compiler.PidginParser
{
    public static class ProgramParser
    {
        public static readonly Parser<char, IEnumerable<FunctionNode>> Program
            = FunctionDefinitionParser.FunctionDefinition
            .Many().Then(x => End().WithResult(x));
    }
}
