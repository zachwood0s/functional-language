using Compiler.AST.Nodes;
using Compiler.PidginParser.Expressions;
using Pidgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace Compiler.PidginParser
{
    public static class FunctionDefinitionParser
    {
        public static Parser<char, FunctionNode> FunctionDefinition
            = Map(
                (proto, args, body) => new FunctionNode(proto, args.ToList(), body),
                FunctionaDeclarationParser.FunctionDeclaration,
                IdentifierParser.LowerIdentifier//.Labelled("function identifier1")
                    .Then(Utils.Parenthesised(
                        Try(IdentifierParser.LowerIdentifier).Separated(Utils.Token(","))))//.Labelled("parameter list"))
                    .Then(x => Utils.Token("=").WithResult(x)),
                ExpressionParser.Expression);//.Labelled("function body"))
            //.Labelled("function definition");
            
              
            //= //from _ in Between(SkipWhitespaces)
              /*from newLine in EndOfLine
              from identifier in String(proto.Name).Labelled($"function identifier (e.g. {proto.Name})")
              from args in Utils.Parenthesised(
                  IdentifierParser.LowerIdentifier.Separated(Utils.Token(","))).Labelled(proto.Name)
              from equal in Utils.Token("=")
              from body in ExpressionParser.Expression*/
              //select new FunctionNode(proto, null, null);
                  
    }
}
