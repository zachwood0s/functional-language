﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private ITokenStream _stream;
        public ASTGeneratorVisitor(ITokenStream stream)
        {
            _stream = stream;
        }
        public override ASTNode VisitProgram([NotNull] ZParser.ProgramContext context)
        {
            var defs = context.definition();
            var declarations = context.typeDeclaration();
            var module = context.module();
            var importList = context.importList()?._list;

            var visitedList = importList?.Select(Visit).Cast<ImportNode>().ToList();
            var visitedDefs = defs?.Select(Visit).ToList();
            var visitedDecls = declarations?.Select(Visit).ToList();
            var visitedModule = module?.Accept(this);

            return new ProgramNode(visitedModule, visitedDefs, visitedDecls, visitedList);
        }

        public override ASTNode VisitImportItem([NotNull] ZParser.ImportItemContext context)
        {
            var name = context.importName()?.GetText();

            if (name == null) return null;
            var asName = context.UPPERCASE_ID()?.GetText() ?? name;

            var source = _GetSourcePosition(context);
            return new ImportNode(name, asName) { SourcePosition = source };
        }

        public override ASTNode VisitIdentifier([NotNull] ZParser.IdentifierContext context)
        {
            var idName = context.LOWERCASE_ID().GetText();
            SourcePosition source = _GetSourcePosition(context);
            source.ErrorLength = idName.Length;
            return new IdentifierNode(idName){ SourcePosition = source };
        }

        public override ASTNode VisitLargeIdentifier([NotNull] ZParser.LargeIdentifierContext context)
        {
            var idName = context.GetText();
            SourcePosition source = _GetSourcePosition(context);
            source.ErrorLength = idName.Length;
            return new IdentifierNode(idName) { SourcePosition = source };
        }

        public override ASTNode VisitLiteralFloat([NotNull] ZParser.LiteralFloatContext context)
        {
            var front = context.INT(0).GetText();
            var back = context.INT(1).GetText();
            var val = double.Parse($"{front}.{back}");
            SourcePosition source = _GetSourcePosition(context);
            source.ErrorLength = front.Length + back.Length + 1;
            return new ConstantDoubleNode(val){ SourcePosition = source };
        }

        public override ASTNode VisitLiteralInt([NotNull] ZParser.LiteralIntContext context)
        {
            var val = int.Parse(context.INT().GetText());
            SourcePosition source = _GetSourcePosition(context);
            source.ErrorLength = val.ToString().Length;
            return new ConstantIntegerNode(val){ SourcePosition = source };
        }

        public override ASTNode VisitLiteralChar([NotNull] ZParser.LiteralCharContext context)
        {
            var val = Regex.Unescape(context.CHARACTER_CONSTANT().GetText())[1];
            SourcePosition source = _GetSourcePosition(context);
            return new ConstantCharNode(val){ SourcePosition = source };
        }

        public override ASTNode VisitFunctionDefinition([NotNull] ZParser.FunctionDefinitionContext context)
        {
            var ident = context.identifier();
            var pars = context.parameterList();
            var body = context.functionBody();

            if (ident == null || body == null)
                return null;
            var visitedIdent = Visit(ident) as IdentifierNode;

            var visitedPars = pars?.identifier()?.Select(Visit);
            var parNames = visitedPars?.Select(x => x is IdentifierNode i ? i.Name : "").ToList() ?? new List<string>();

            var name = visitedIdent.Name;
            var visitedBody = Visit(body) as ExprAST;

            SourcePosition source = _GetSourcePosition(context.Start, context.Start, context.Start.Line);
            source.ErrorLength = visitedIdent.Name.Length + parNames.Aggregate(0, (acc, str) => acc + str.Length) + 2;
            return new FunctionNode(name, parNames, visitedBody) { SourcePosition = source };
        }

        public override ASTNode VisitFunctionTypeDeclaration([NotNull] ZParser.FunctionTypeDeclarationContext context)
        {
            var ident = context.identifier();
            var type = context.functionType();
            if (ident == null || type == null)
                return null;

            var visitedIdent = Visit(ident) as IdentifierNode;
            var visitedTypes = Visit(type) as FunctionType;

            SourcePosition source = _GetSourcePosition(context);
            return new PrototypeNode(visitedIdent.Name, visitedTypes) { SourcePosition = source };
        }

        public override ASTNode VisitFunctionType([NotNull] ZParser.FunctionTypeContext context)
        {
            var typeList = context.typeList()?.type();
            var returnType = context.type();

            if (typeList == null || returnType == null)
                return null;

            var visitedTypeList = typeList.Select(x => Visit(x) as INodeType);
            var visitedReturn = Visit(returnType);

            SourcePosition source = _GetSourcePosition(context);
            source.ErrorLength += visitedReturn.SourcePosition.ErrorLength;
            return new FunctionType(visitedTypeList.ToList(), visitedReturn as INodeType) { SourcePosition = source };
        }

        public override ASTNode VisitVariableTypeDeclaration([NotNull] ZParser.VariableTypeDeclarationContext context)
        {
            var ident = context.identifier();
            var type = context.identifierType();

            if (ident == null || type == null)
                return null;

            var visitedIdent = Visit(ident) as IdentifierNode;
            var visitedType = Visit(type) as VariableType;

            SourcePosition source = _GetSourcePosition(context);
            source.ErrorLength += visitedType.TypeName.Length;
            return new VariableTypeDeclarationNode(visitedIdent.Name, visitedType) { SourcePosition = source };
        }

        public override ASTNode VisitIdentifierType([NotNull] ZParser.IdentifierTypeContext context)
        {
            var ident = context.UPPERCASE_ID().GetText();
            SourcePosition source = _GetSourcePosition(context);
            source.ErrorLength = ident.Length;
            return new VariableType(ident) { SourcePosition = source };
        }

        public override ASTNode VisitEmptyType([NotNull] ZParser.EmptyTypeContext context)
        {
            SourcePosition source = _GetSourcePosition(context);
            return new NoneType() { SourcePosition = source };
        }

        public override ASTNode VisitOpExpr([NotNull] ZParser.OpExprContext context)
        {
            var left = context.expression(0);
            var right = context.expression(1);
            var op = context.op;

            if (left == null || right == null || op == null)
                return null;

            var visitedLeft = Visit(left);
            var visitedRight = Visit(right);

            SourcePosition source = _GetSourcePosition(context);
            return new BinaryOperatorNode(visitedLeft, visitedRight, op.Text) { SourcePosition = source };
        }

        public override ASTNode VisitParenExpr([NotNull] ZParser.ParenExprContext context)
        {
            var expr = context.expression();

            if (expr == null)
                return null;

            var visitedExpr = Visit(expr);

            return visitedExpr;
        }

        public override ASTNode VisitTypeCastExpr([NotNull] ZParser.TypeCastExprContext context)
        {
            var expr = context.expression();
            var type = context.identifierType();

            if (expr == null || type == null)
                return null;

            var visitedExpr = Visit(expr);
            var visitedType = Visit(type) as INodeType;

            SourcePosition source = _GetSourcePosition(context);
            return new TypeCastNode(visitedType, visitedExpr as ExprAST) { SourcePosition = source };
        }

        public override ASTNode VisitUnaryExpr([NotNull] ZParser.UnaryExprContext context)
        {
            var expression = context.expression();
            var op = context.op;

            if (expression == null || op == null)
                return null;

            var visitedExpr = Visit(expression);
            SourcePosition source = _GetSourcePosition(context);
            return new UnaryOperatorNode(visitedExpr, op.Text) { SourcePosition = source };
        }

        public override ASTNode VisitIfExpression([NotNull] ZParser.IfExpressionContext context)
        {
            var cond = context.expression(0);
            var then = context.expression(1);
            var _else = context.expression(2);

            if (cond == null || then == null || _else == null)
                return null;

            var visitedCond = Visit(cond) as ExprAST;
            var visitedThen = Visit(then) as ExprAST;
            var visitedElse = Visit(_else) as ExprAST;

            SourcePosition source = _GetSourcePosition(context);
            return new IfExpressionNode(visitedCond, visitedThen, visitedElse) { SourcePosition = source };
        }

        public override ASTNode VisitLetExpression([NotNull] ZParser.LetExpressionContext context)
        {
            var assignments = context.letList()?._list;
            var expr = context.expression();

            if (assignments == null || expr == null)
                return null;

            var visitedList = assignments.Select(Visit);
            var visitedAssign = new List<AssignmentNode>();
            var visitedDecl = new List<ITypeDeclarationNode<INodeType>>();
            foreach(var val in visitedList)
            {
                if (val is AssignmentNode a) visitedAssign.Add(a);
                else if (val is ITypeDeclarationNode<INodeType> t) visitedDecl.Add(t);
            }
            var visitedExpr = Visit(expr) as ExprAST;

            SourcePosition source = _GetSourcePosition(context);
            return new LetExpressionNode(visitedAssign, visitedDecl, visitedExpr) { SourcePosition = source };
        }

        public override ASTNode VisitAssignment([NotNull] ZParser.AssignmentContext context)
        {
            var identifier = context.identifier()?.LOWERCASE_ID();
            var expr = context.expression();

            if (identifier == null || expr == null)
                return null;

            var visitedExpr = Visit(expr);

            SourcePosition source = _GetSourcePosition(context.Start, context.Start, context.Start.Line);
            source.ErrorLength = source.SourceText.Length - context.Start.Column;
            return new AssignmentNode(identifier.GetText(), visitedExpr) { SourcePosition = source };
        }

        public override ASTNode VisitFunctionCallExpr([NotNull] ZParser.FunctionCallExprContext context)
        {
            var expr = context.expression();
            var callParams = context.functionCall()?.usageParameterList()?._list;

            if (expr == null)
                return null;

            var visitedExpr = Visit(expr) as ExprAST;
            var visitedList = callParams?.Select(Visit).Cast<ExprAST>().ToList() ?? new List<ExprAST>();

            SourcePosition source = _GetSourcePosition(context);
            return new FunctionCallNode(visitedExpr, visitedList) { SourcePosition = source };
        }

        public override ASTNode VisitModule([NotNull] ZParser.ModuleContext context)
        {
            var exportList = context.exportList()?._list;
            var ident = context.UPPERCASE_ID()?.GetText();

            if (exportList == null || ident == null) return null;

            var visitedList = exportList.Select(x => x.GetText()).ToList();

            SourcePosition source = _GetSourcePosition(context);
            return new ModuleNode(ident, visitedList) { SourcePosition = source };
        }

        private SourcePosition _GetSourcePosition(ParserRuleContext context)
        {
            var start = context.Start;
            var stop = context.Stop;
            var line = start.Line;
            return _GetSourcePosition(start, stop, line);
        }

        private SourcePosition _GetSourcePosition(IToken start, IToken stop, int line)
        {
            string sourceText = Utils.GetLineTextForTokens(start, stop, _stream);
            var source = new SourcePosition()
            {
                Line = line,
                Column = start.Column,
                ErrorLength = stop.Column - start.Column,
                FileName = start.TokenSource.SourceName,
                SourceText = sourceText
            };
            return source;
        }
    }
}
