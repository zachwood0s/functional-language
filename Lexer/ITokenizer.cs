using System;
using System.Collections.Generic;
using System.Text;

namespace Lexer
{
    public interface ITokenizer<T>
    {
        IEnumerable<T> Tokenize(string text);
    }
}
