﻿using Compiler.AST.Types;
using Pidgin;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class IdentifierNode : ExprAST
    {
        private string _name;
        private SourcePos _span;

        public string Name => _name;
        public SourcePos Span => _span;

        public IdentifierNode(string name, SourcePos span)
        {
            _name = name;
            _span = span;
        }
        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
