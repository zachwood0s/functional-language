﻿using ZAntlr.AST.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST
{
    public interface IASTVisitor
    {
        void Visit(ASTNode node);
        void Visit(ProgramNode node);
        void Visit(ImportNode node);
        void Visit(ModuleNode node);
        void Visit(BinaryOperatorNode node);
        void Visit(ConstantDoubleNode node);
        void Visit(ConstantIntegerNode node);
        void Visit(ConstantCharNode node);
        void Visit(UnaryOperatorNode node);
        void Visit(FunctionCallNode node);
        void Visit(FunctionNode node);
        void Visit(PrototypeNode node);
        void Visit(IdentifierNode node);
        void Visit(IdentifierTypeNode node);
        void Visit(VariableTypeDeclarationNode node);
        void Visit(IfExpressionNode node);
        void Visit(LetExpressionNode node);
        void Visit(TypeCastNode node);
    }
}
