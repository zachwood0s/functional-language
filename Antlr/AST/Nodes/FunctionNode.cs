using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class FunctionNode : ASTNode
    {
        private string _name;
        private List<string> _args;
        private ExprAST _body;

        public string Name => _name;
        public IReadOnlyList<string> Args => _args;
        public ExprAST Body => _body;

        public FunctionNode(string name, List<string> args, ExprAST body)
        {
            _name = name;
            _args = args;
            _body = body;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
