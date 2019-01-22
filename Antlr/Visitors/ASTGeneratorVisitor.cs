using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using ZAntlr.AST;
using ZAntlr.AST.Nodes;
using ZAntlr.AST.Types;

namespace ZAntlr.Visitors
{
    public class ASTGeneratorVisitor: ZParserBaseVisitor<ASTNode>
    {
        public override ASTNode VisitProgram([NotNull] ZParser.ProgramContext context)
        {
            var defs = context.definition();
            var declarations = context.typeDeclaration();

            var visitedDefs = defs?.Select(Visit).ToList();
            var visitedDecls = declarations?.Select(Visit).ToList();

            return new ProgramNode(visitedDefs, visitedDecls);
        }

        public override ASTNode VisitIdentifier([NotNull] ZParser.IdentifierContext context)
        {
            var idName = context.LOWERCASE_ID().GetText();
            return new IdentifierNode(idName);
        }

        public override ASTNode VisitLiteralFloat([NotNull] ZParser.LiteralFloatContext context)
        {
            var front = context.INT(0).GetText();
            var back = context.INT(1).GetText();
            var val = double.Parse($"{front}.{back}");
            return new ConstantDoubleNode(val);
        }

        public override ASTNode VisitLiteralInt([NotNull] ZParser.LiteralIntContext context)
        {
            var val = int.Parse(context.INT().GetText());
            return new ConstantIntegerNode(val);
        }

        public override ASTNode VisitFunctionDefinition([NotNull] ZParser.FunctionDefinitionContext context)
        {
            var ident = context.identifier();
            var pars = context.parameterList();
            var body = context.functionBody();

            if (ident == null || body == null) return null;
            var visitedIdent = Visit(ident) as IdentifierNode;

            var visitedPars = pars?.identifier()?.Select(Visit);
            var parNames = visitedPars?.Select(x => x is IdentifierNode i ? i.Name : "").ToList() ?? new List<string>();

            var name = visitedIdent.Name;
            var visitedBody = Visit(body) as ExprAST;

            return new FunctionNode(name, parNames, visitedBody);
        }

        public override ASTNode VisitFunctionTypeDeclaration([NotNull] ZParser.FunctionTypeDeclarationContext context)
        {
            var ident = context.identifier();
            var type = context.functionType();
            if (ident == null || type == null) return null;

            var visitedIdent = Visit(ident) as IdentifierNode;
            var visitedTypes = Visit(type) as FunctionType;

            return new PrototypeNode(visitedIdent.Name, visitedTypes);
        }

        public override ASTNode VisitFunctionType([NotNull] ZParser.FunctionTypeContext context)
        {
            var typeList = context.typeList()?.type();
            var returnType = context.type();

            if (typeList == null || returnType == null) return null;

            var visitedTypeList = typeList.Select(x => Visit(x) as INodeType);
            var visitedReturn = Visit(returnType) as INodeType;

            return new FunctionType(visitedTypeList.ToList(), visitedReturn);
        }

        public override ASTNode VisitVariableTypeDeclaration([NotNull] ZParser.VariableTypeDeclarationContext context)
        {
            var ident = context.identifier();
            var type = context.identifierType();

            if (ident == null || type == null) return null;

            var visitedIdent = Visit(ident) as IdentifierNode;
            var visitedType = Visit(type) as VariableType;

            return new VariableTypeDeclarationNode(visitedIdent.Name, visitedType);
        }

        public override ASTNode VisitIdentifierType([NotNull] ZParser.IdentifierTypeContext context)
        {
            var ident = context.UPPERCASE_ID().GetText();
            return new VariableType(ident);
        }

        public override ASTNode VisitEmptyType([NotNull] ZParser.EmptyTypeContext context)
        {
            return new NoneType();
        }

        public override ASTNode VisitOpExpr([NotNull] ZParser.OpExprContext context)
        {
            var left = context.expression(0);
            var right = context.expression(1);
            var op = context.op;

            if (left == null || right == null || op == null) return null;

            var visitedLeft = Visit(left);
            var visitedRight = Visit(right);

            return new BinaryOperatorNode(visitedLeft, visitedRight, op.Text);
        }

        public override ASTNode VisitTypeCastExpr([NotNull] ZParser.TypeCastExprContext context)
        {
            var expr = context.expression();
            var type = context.identifierType();

            if (expr == null || type == null) return null;

            var visitedExpr = Visit(expr) as ExprAST;
            var visitedType = Visit(type) as INodeType;

            return new TypeCastNode(visitedType, visitedExpr);
        }

        public override ASTNode VisitUnaryExpr([NotNull] ZParser.UnaryExprContext context)
        {
            var expression = context.expression();
            var op = context.op;

            if (expression == null || op == null) return null;

            var visitedExpr = Visit(expression);
            return new UnaryOperatorNode(visitedExpr, op.Text);
        }

        public override ASTNode VisitIfExpression([NotNull] ZParser.IfExpressionContext context)
        {
            var cond = context.expression(0);
            var then = context.expression(1);
            var _else = context.expression(2);

            if (cond == null || then == null || _else == null) return null;

            var visitedCond = Visit(cond) as ExprAST;
            var visitedThen = Visit(then) as ExprAST;
            var visitedElse = Visit(_else) as ExprAST;

            return new IfExpressionNode(visitedCond, visitedThen, visitedElse);
        }

        public override ASTNode VisitLetExpression([NotNull] ZParser.LetExpressionContext context)
        {
            var assignments = context.letList()?._list;
            var expr = context.expression();

            if (assignments == null || expr == null) return null;

            var visitedList = assignments.Select(Visit);
            var visitedAssign = visitedList.Where(x => x is AssignmentNode).Cast<AssignmentNode>().ToList();
            var visitedDecl = visitedList.Except(visitedAssign).ToList();
            var visitedExpr = Visit(expr) as ExprAST;

            return new LetExpressionNode(visitedAssign, visitedDecl, visitedExpr);
        }

        public override ASTNode VisitAssignment([NotNull] ZParser.AssignmentContext context)
        {
            var identifier = context.identifier()?.LOWERCASE_ID();
            var expr = context.expression();

            if (identifier == null || expr == null) return null;

            var visitedExpr = Visit(expr);

            return new AssignmentNode(identifier.GetText(), visitedExpr);
        }

        public override ASTNode VisitFunctionCallExpr([NotNull] ZParser.FunctionCallExprContext context)
        {
            var expr = context.expression();
            var callParams = context.functionCall()?.usageParameterList()?._list;

            if (expr == null) return null;

            var visitedExpr = Visit(expr) as ExprAST;
            var visitedList = callParams?.Select(Visit).Cast<ExprAST>().ToList() ?? new List<ExprAST>();

            return new FunctionCallNode(visitedExpr, visitedList);
        }
    }
}
