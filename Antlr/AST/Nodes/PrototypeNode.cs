﻿using ZAntlr.AST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class PrototypeNode : ASTNode, ITypeDeclarationNode<FunctionType>
    {
        private string _name;
        private FunctionType _type;

        public string Name => _name;
        public FunctionType Type => _type;

        public PrototypeNode(string name, FunctionType type) 
        {
            _name = name;
            _type = type;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
