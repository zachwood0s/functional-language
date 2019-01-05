using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class FunctionCallNode : ExprAST
    {
        private ExprAST _callee;
        private List<ExprAST> _args;

        public ExprAST Callee => _callee;
        public IReadOnlyList<ExprAST> Args => _args;

        public FunctionCallNode(ExprAST expr, List<ExprAST> args)
        {
            _callee = expr;
            _args = args;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
