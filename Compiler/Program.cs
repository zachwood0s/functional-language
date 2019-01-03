using Compiler.AST;
using Compiler.AST.CodeGenVisitor;
using Compiler.AST.ConsolePrintVisitor;
using Compiler.PidginParser;
using Pidgin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Program
    {
        public static void Main(string[] args)
        {
            LoadFile("testSource.txt");

            //var node = PidginParser.Expressions.ExpressionParser.Expression
             //   .ParseOrThrow("4 + 5 * alpha == (2 + 2) * 4 + 4 || b < a && a");
            //node.Accept(new ASTPrintVisitor());
            Console.ReadKey();
        }

        public static void LoadFile(string file)
        {
            string text = File.ReadAllText(file);
            try
            {
                var nodes = ProgramParser.Program.ParseOrThrow(text);
                //var nodes = FunctionDefinitionParser.FunctionDefinition.XMany().End().Parse(text);
                foreach(var node in nodes)
                {
                    node.Accept(new ASTPrintVisitor());
                }
                //node(new ASTPrintVisitor());

                var codegen = new ASTCodeGenVisitor("my cool jit");
                foreach(var node in nodes)
                {
                    node.Accept(codegen);
                }
                codegen.PrintIR();

            }
            catch(ParseException e)
            {
                Console.WriteLine(text);
                Console.WriteLine(e.Message);
            }
            catch(CodeGenException<string> e)
            {
                Console.WriteLine(text);
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n");
        }

        /*
        public static void DoExpression(string test)
        {
            try
            {
                var node = ExpressionParser.Expression.End().Parse(test);
                node.Accept(new ASTPrintVisitor());
            } catch (Exception e)
            {
                Console.WriteLine(test);
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n\n\n");
        }

        public static void DoFunction(string test)
        {
            try
            {
                var node = FunctionDefinitionParser.FunctionDefinition.Parse
                    (test);
                node.Accept(new ASTPrintVisitor());
            }
            catch (Sprache.ParseException e)
            {
                Console.WriteLine(test);
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n\n\n");
        }
        */

    }
}
