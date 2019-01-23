using CommandLine;
using Compiler.AST;
using Compiler.AST.CodeGenVisitor;
using Compiler.AST.TypeCheckVisitor;
using Compiler.Errors;
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
        public class Options
        {
            [Option('o', "out", Required = false, Default = "out", HelpText = "Set output filename")]
            public string FileName { get; set; }

            [Option("printAST", Required = false, HelpText = "Prints out the parsed AST before compiling")]
            public bool PrintAST { get; set; }

            [Option("printIR", Required = false, HelpText = "Prints out the LLVM IR code before compiling")]
            public bool PrintIR { get; set; }

            [Option("optimize", Required = false, Default = true, HelpText = "Runs LLVM optimization passes")]
            public bool Optimize { get; set; }

            [Value(0, MetaName = "input", Required = true, HelpText = "Set input files")]
            public IEnumerable<string> InputFiles { get; set; }

        }
        public static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(_RunOptions);
            Logger.PrintCompilerMessage(new CompilerMessage() {
                Message = "method 'foo' has '&self' declaration in the trait, but not in the impl",
                SourcePosition = new ZAntlr.SourcePosition { Line = 18, Column = 5, FileName = "src/test/compile-fail.rs", ErrorLength = 14},
                SourceText = "     fn foo(&self);",
                SubMessage = "'&self' used in trait"
            });
            Console.ReadKey();
        }

        private static void _RunOptions(Options opts)
        {
             
        }
    }
}
