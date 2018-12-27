using Compiler.AST.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST
{
    public interface IASTVisitor
    {
        void Visit(ASTNode node);
        void Visit(BinaryOperator node);
        void Visit(ConstantDouble node);
        void Visit(UnaryOperator node);
    }
}
