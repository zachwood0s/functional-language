using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parser.Basics
{
    public static class WhiteSpace
    {
        public static readonly Parser<string> NewLine =
            Parse.String(Environment.NewLine).Text().Named("new line");
    }
}
