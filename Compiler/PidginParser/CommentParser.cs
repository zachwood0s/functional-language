﻿using Pidgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace Compiler.PidginParser
{
    public static class CommentParser
    {
        public static readonly Parser<char, Unit> LineComment =
            Pidgin.Comment.CommentParser.SkipLineComment(String("//"));

        public static readonly Parser<char, Unit> BlockComment =
            Pidgin.Comment.CommentParser.SkipNestedBlockComment(String("/*"), Try(String("*/")));

        public static readonly Parser<char, Unit> Comments =
            Try(LineComment.SkipMany()).Or(BlockComment.SkipMany());

    }
}