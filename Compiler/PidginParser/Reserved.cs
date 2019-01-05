using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.PidginParser
{
    public static class Reserved
    {
        public static readonly string[] Keywords =
        {
            "let",
            "in",
            "if",
            "else",
            "then"
        };

        public static string Keyword(string word) => $"keyword '{word}'";
    }
}
