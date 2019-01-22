using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr;
using ZAntlr.Visitors;

namespace ZAntlr
{
    class Program
    {
        public static void Main(string[] args)
        {
            string input = "";
            //StringBuilder text = new StringBuilder();
            //Console.WriteLine("Input the chat.");

            // to type the EOF character and end the input: use CTRL+D, then press <enter>
            /*
            while ((input = Console.ReadLine()) != "\u0004")
            {
                text.AppendLine(input);
            }
            */

            var text = File.ReadAllText("input.txt");
            
            var inputStream = new AntlrInputStream(text.ToString());
            var zLexer = new ZLexer(inputStream);
            var tokenStream = new CommonTokenStream(zLexer);
            var programParser = new ZParser(tokenStream)
            {
                BuildParseTree = true
            };
            var visitor = new ASTGeneratorVisitor();
            var ast = visitor.Visit(programParser.program());
            ast.Accept(new ASTPrintVisitor());
            Console.ReadKey();
        }

    }
}
