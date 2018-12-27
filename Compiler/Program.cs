using Compiler.AST.ConsolePrintVisitor;
using Compiler.Parser.Expressions;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Program
    {
        public static void Main(string[] args)
        {
            DoTest("3 * 5)");
            DoTest("3 + (4 + 5)");
            DoTest("3 + (4 \\ 5 + 5)");
            DoTest("(3 + 3) - (4 \\ 5 * 5)");
            //DoTest("(3 + 3 * (4 \\ 5 * 5))");
            //DoTest("(3 + 3 * (4 \\ 5 % 5))");
            Console.ReadKey();
        }

        public static void DoTest(string test)
        {
            var node = ExpressionParser.Expression.Parse(test);
            node.Accept(new ASTPrintVisitor());
            Console.WriteLine("\n\n\n");
        }
    }
}
