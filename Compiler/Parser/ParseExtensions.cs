using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parser
{
    public static class ParseExtensions
    {
        /*
        public static Parser<IEnumerable<T>> DelimitedBy<T, U>(this Parser<T> parser, Parser<U> delimiter, int minimumCount)
        {
            if(parser == null) throw new ArgumentNullException(nameof(parser));
            if(delimiter == null) throw new ArgumentNullException(nameof(delimiter));

            /*return from head in parser.Once()
                   from tail in
                       (from separator in delimiter
                        from item in parser
                        select item).M
        }
        */
    }
}
