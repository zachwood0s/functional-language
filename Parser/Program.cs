using Parser.Functions;
using Parser.Basics;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Program
    {
        public static void Main(string[] args)
        {
            string test = "basicFunc : Int, Float -> Int";
            Console.WriteLine(FunctionDefinitionParser.FunctionDefinition.Parse(test));

            string test2 = "basicFunc : Int -> [Int]";
            Console.WriteLine(FunctionDefinitionParser.FunctionDefinition.Parse(test2));

            string Uident = "Uident2_423";
            Console.WriteLine(IdentifierParser.UpperIdentifier.Parse(Uident));
            string Lident = "uident2_423";
            Console.WriteLine(IdentifierParser.LowerIdentifier.Parse(Lident));

            string type = "Int";
            Console.WriteLine(TypeParser.TypeUsage.Parse(type));
            string type2 = "[Int]";
            Console.WriteLine(TypeParser.TypeUsage.Parse(type2));
            string type3 = "[[Int]]";
            Console.WriteLine(TypeParser.TypeUsage.Parse(type3));

            Console.ReadKey();
        }
    }
}
