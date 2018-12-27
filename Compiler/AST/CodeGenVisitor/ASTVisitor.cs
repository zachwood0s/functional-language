using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.AST.Nodes;

namespace Compiler.AST.CodeGenVisitor
{
    public partial class ASTCodeGenVisitor : IASTVisitor
    {
        public void Visit(ASTNode node)
        {
        }

        public void Visit(BinaryOperator node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ConstantDouble node)
        {
            throw new NotImplementedException();
        }

        public void Visit(UnaryOperator node)
        {
            throw new NotImplementedException();
        }
    }
}
