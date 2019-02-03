using Antlr4.Runtime;
using Compiler.Errors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr;
using ZAntlr.AST.Nodes;
using ZAntlr.AST.Types;
using ZAntlr.Visitors;
using static Compiler.Errors.ErrorLogger;

namespace Compiler
{
    public class ModuleHandler
    {
        private Dictionary<string, ProgramNode> _loadedModules;

        public IReadOnlyDictionary<string, ProgramNode> LoadedModules => _loadedModules;


        public ModuleHandler()
        {
            _loadedModules = new Dictionary<string, ProgramNode>();
        }

        public ProgramNode LoadFile(string path)
        {
            if(_loadedModules.TryGetValue(path, out var loaded))
            {
                return loaded;
            }

            var fileStream = new AntlrFileStream(path);
            var lexer = new ZLexer(fileStream);

            CommonTokenStream tokens = new CommonTokenStream(lexer);

            var lexerListener = new ErrorListener(tokens);
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(lexerListener);

            var parser = new ZParser(tokens);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(lexerListener);

            var tree = parser.program();
            var visitor = new ASTGeneratorVisitor(tokens);
            var ast = visitor.Visit(tree) as ProgramNode;

            if (lexerListener.FoundErrors)
            {
                PrintCompilerMessage(ErrorIndex.AbortError);
                return null;
            }

            _loadedModules.Add(path, ast);

            return ast;
        }

        public ProgramNode LoadModule(string startingLocation, string moduleName, SourcePosition pos)
        {
            var relativePath = $"\\{moduleName.Replace('.', '\\')}.z";
            startingLocation = new FileInfo(startingLocation).DirectoryName;
            return LoadModuleAtLocation(startingLocation + relativePath, pos);
        }

        public ProgramNode LoadModuleAtLocation(string path, SourcePosition pos)
        {
            var ast = LoadFile(path);
            if (ast == null) return null;

            if(ast.Module == null)
            {
                PrintFromErrorCode(13,
                    new MessageConfig(pos, path));
                return null;
            }
            return ast;
        }
    }

    public static class ASTExtensions
    {
        public static string GetModuleName(this ProgramNode node)
        {
            var module = node.Module as ModuleNode;
            return module?.Name;
        }

        public static IEnumerable<ITypeDeclarationNode<INodeType>> GetExportedTypes(this ProgramNode node)
        {
            if (node.Module is ModuleNode module)
            {
                return from declaration in node.Declarations.Cast<ITypeDeclarationNode<INodeType>>()
                       where module.Exports.Contains(declaration.Name)
                       select declaration;
            }
            return null;
        }
    }
}
