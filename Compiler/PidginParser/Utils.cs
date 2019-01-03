﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pidgin;
using static Pidgin.Parser;
namespace Compiler.PidginParser
{
    public static class Utils
    {
        public static Parser<char, T> Token<T>(Parser<char, T> token)
            => Try(token).Before(SkipWhitespaces);

        public static Parser<char, string> Token(string token)
            => Token(String(token));

        public static Parser<char, T> Parenthesised<T>(Parser<char, T> parser)
            => parser.Between(Token("("), Token(")"));
    }
}
