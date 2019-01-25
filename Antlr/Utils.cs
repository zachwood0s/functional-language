using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr
{
    public static class Utils
    {
        public static string GetLineTextForToken(IToken token, ITokenStream stream) => GetLineTextForTokens(token, token, stream);

        public static string GetLineTextForTokens(IToken start, IToken stop, ITokenStream stream)
        {
            var startIndex = start.StartIndex;
            var stopIndex = stop.StopIndex;
            var endIndex = FindEndOfLine(stop.TokenIndex, stream);
            var sourceText = start.InputStream.GetText(new Interval(startIndex - start.Column, endIndex));
            return sourceText;
        }

        public static int FindEndOfLine(int startIndex, ITokenStream stream)
        {
            int line = stream.Get(startIndex).Line;
            int endIndex = startIndex+1;

            while(endIndex < stream.Size && stream.Get(endIndex).Line == line)
            {
                endIndex++;
            }

            return stream.Get(endIndex - 1).StopIndex;
        }
    }
}
