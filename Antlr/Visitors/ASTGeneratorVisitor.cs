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

            if (ident == null || pars == null || body == null) return null;
            var visitedIdent = Visit(ident) as IdentifierNode;
            var visitedPars = pars.identifier()?.Select(Visit);
            var name = visitedIdent.Name;
            var parNames = visitedPars.Select(x => x is IdentifierNode i ? i.Name : "");
            var visitedBody = Visit(body) as ExprAST;

            return new FunctionNode(name, parNames.ToList(), visitedBody);
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

    }
}
