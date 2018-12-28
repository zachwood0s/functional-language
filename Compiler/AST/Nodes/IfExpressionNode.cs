using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class IfExpressionNode: ExprAST
    {
        private ExprAST _ifCondition;
        private ExprAST _then;
        private IOption<ExprAST> _elseExpresson;

        public ExprAST IfCondition => _ifCondition;
        public ExprAST Then => _then;
        public IOption<ExprAST> ElseExpression => _elseExpresson;

        public IfExpressionNode(ExprAST _if, ExprAST then, IOption<ExprAST> _else)
        {
            _ifCondition = _if;
            _then = then;
            _elseExpresson = _else;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
