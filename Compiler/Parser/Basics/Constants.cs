﻿using Compiler.AST;
using Compiler.AST.Nodes;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Parser.Basics
{
    public static class ConstantParser
    {
        public static readonly Parser<ASTNode> Constant =
            Parse.Decimal
            .Select(x => new ConstantDouble(double.Parse(x)))
            .Named("number");
    }
}