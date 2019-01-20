using ZAntlr.AST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr.AST.Nodes
{
    public class LetExpressionNode : ExprAST
    {
        private List<LetAssignment> _assignments;
        private ExprAST _inExpression;

        public IReadOnlyList<LetAssignment> Assignments => _assignments;
        public ExprAST InExpression => _inExpression;

        public LetExpressionNode(List<LetAssignment> assignments, ExprAST expression)
        {
            _assignments = assignments;
            _inExpression = expression;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public struct LetAssignment
    {
        public string Identifier { get; set; }
        public INodeType Type { get; set; }
        public ExprAST Expression { get; set; }
    }
}
