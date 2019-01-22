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
        private List<AssignmentNode> _assignments;
        private List<ASTNode> _declarations;
        private ExprAST _inExpression;

        public IReadOnlyList<AssignmentNode> Assignments => _assignments;
        public IReadOnlyList<ASTNode> Declarations => _declarations;
        public ExprAST InExpression => _inExpression;

        public LetExpressionNode(List<AssignmentNode> assignments, List<ASTNode> declarations, ExprAST expression)
        {
            _assignments = assignments;
            _declarations = declarations;
            _inExpression = expression;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
