using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class FunctionNode : ASTNode
    {
        private PrototypeNode _prototype;
        private List<string> _args;
        private ExprAST _body;

        public PrototypeNode Prototype => _prototype;
        public IReadOnlyList<string> Args => _args;
        public ExprAST Body => _body;

        public FunctionNode(PrototypeNode prototype, List<string> args, ExprAST body)
        {
            _prototype = prototype;
            _args = args;
            _body = body;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
