using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class FunctionCallNode : ExprAST
    {
        private string _callee;
        private List<ExprAST> _args;

        public string Callee => _callee;
        public IReadOnlyList<ExprAST> Args => _args;

        public FunctionCallNode(string callee, List<ExprAST> args)
        {
            _callee = callee;
            _args = args;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
