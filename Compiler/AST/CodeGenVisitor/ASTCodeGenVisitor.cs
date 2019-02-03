using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LLVMSharp;
using ZAntlr.AST;
using ZAntlr.AST.Nodes;
using ZAntlr.AST.Types;

namespace Compiler.AST.CodeGenVisitor
{
    public partial class ASTCodeGenVisitor : IASTVisitor
    {
        public static readonly bool OPTIMIZE = true;

        private readonly LLVMModuleRef _module;
        private readonly LLVMBuilderRef _builder;
        private readonly LLVMPassManagerRef _functionPassManager;
        private readonly LLVMPassManagerRef _modulePassManager;
        private readonly Dictionary<string, LLVMValueRef> _namedValues;
        private readonly Stack<LLVMValueRef> _valueStack;

        public ASTCodeGenVisitor(string moduleName)
        {
            _namedValues = new Dictionary<string, LLVMValueRef>();
            _valueStack = new Stack<LLVMValueRef>();
            _module = LLVM.ModuleCreateWithName(moduleName);
            _builder = LLVM.CreateBuilder();

            _functionPassManager = LLVM.CreateFunctionPassManagerForModule(_module);
            _modulePassManager = LLVM.CreatePassManager();

            _SetupPasses();
            _SetupDefaultLLVMTypes();
            _SetupDefaultCasts();
            _CreateDefaultOperators();
            _CreateBuiltInFunctions();
        }

        private void _SetupPasses()
        {
            LLVM.AddPromoteMemoryToRegisterPass(_functionPassManager);
            LLVM.AddInstructionCombiningPass(_functionPassManager);
            LLVM.AddReassociatePass(_functionPassManager);
            LLVM.AddGVNPass(_functionPassManager);
            LLVM.AddCFGSimplificationPass(_functionPassManager);
            LLVM.AddTailCallEliminationPass(_functionPassManager);
            LLVM.InitializeFunctionPassManager(_functionPassManager);

            LLVM.AddFunctionInliningPass(_modulePassManager);
            LLVM.AddGlobalDCEPass(_modulePassManager);
        }

        public void PrintIR()
        {
            LLVM.VerifyModule(_module, LLVMVerifierFailureAction.LLVMPrintMessageAction, out var _);
            if(OPTIMIZE) LLVM.RunPassManager(_modulePassManager, _module);
            LLVM.DumpModule(_module);
        }

        public void WriteIRToFile(string fileName)
        {
            var triple = LLVM.GetDefaultTargetTriple();
            var targetTriple = Marshal.PtrToStringAnsi(triple);
            
            LLVM.InitializeX86TargetInfo();
            LLVM.InitializeX86Target();
            LLVM.InitializeX86TargetMC();
            LLVM.InitializeX86AsmParser();
            LLVM.InitializeX86AsmPrinter();

            if(LLVM.GetTargetFromTriple(targetTriple, out var target, out var error))
            {
                Console.WriteLine($"Object file error: {error}");
            }
            else
            {
                var CPU = "generic";
                var features = "";
                var targetMachine = LLVM.CreateTargetMachine(
                    target, 
                    targetTriple, 
                    CPU, 
                    features, 
                    LLVMCodeGenOptLevel.LLVMCodeGenLevelDefault, 
                    LLVMRelocMode.LLVMRelocDefault, 
                    LLVMCodeModel.LLVMCodeModelDefault);


                var layout = LLVM.CreateTargetDataLayout(targetMachine);
                LLVM.SetModuleDataLayout(_module, layout);
                LLVM.SetTarget(_module, targetTriple);
                var stringPtr = Marshal.StringToHGlobalAuto("output.obj");
                if (LLVM.TargetMachineEmitToFile(targetMachine, _module, stringPtr, LLVMCodeGenFileType.LLVMObjectFile, out var innererror))
                {
                    Console.WriteLine($"Object file error: {innererror}");
                }
                else
                {
                    Console.WriteLine("success");
                }

            }
            LLVM.PrintModuleToFile(_module, fileName, out var msg);
            Console.WriteLine(msg);
        }

        public void Visit(ASTNode node)
        {
        }

        public void Visit(ModuleNode node)
        {

        }

        public void Visit(ImportNode node)
        {

        }

        public void Visit(ConstantDoubleNode node)
        {
            _valueStack.Push(LLVM.ConstReal(_GetLLVMType(node.Type, new Pidgin.SourcePos()), node.Value));
        }

        public void Visit(ConstantIntegerNode node)
        {
            _valueStack.Push(LLVM.ConstInt(_GetLLVMType(node.Type, new Pidgin.SourcePos()), (ulong) node.Value, true));
        }

        public void Visit(ConstantCharNode node)
        {
            _valueStack.Push(LLVM.ConstInt(_GetLLVMType(node.Type, new Pidgin.SourcePos()), node.Value, true));
        }

        public void Visit(UnaryOperatorNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(IdentifierNode node)
        {
            if(_namedValues.TryGetValue(node.Name, out var value))
            {
                var loaded = LLVM.BuildLoad(_builder, value, node.Name);
                _valueStack.Push(loaded);
            }
            else
            {
                throw new CodeGenException($"Unknown variable name '{node.Name}'", new Pidgin.SourcePos());
            }
        }

        public void Visit(VariableTypeDeclarationNode node)
        {
        
        }

        public void Visit(IfExpressionNode node)
        {
            node.IfCondition.Accept(this);
            var condV = _valueStack.Pop();
            condV = LLVM.BuildICmp(
                _builder,
                LLVMIntPredicate.LLVMIntNE,
                condV,
                LLVM.ConstInt(_llvmTypes[DefaultTypes.Bool], 0, false),
                "ifcond");

            var function = LLVM.GetInsertBlock(_builder).GetBasicBlockParent();

            var thenBB = function.AppendBasicBlock("then");
            var elseBB = function.AppendBasicBlock("else");
            var mergeBB = function.AppendBasicBlock("ifcont");

            LLVM.BuildCondBr(_builder, condV, thenBB, elseBB);

            LLVM.PositionBuilderAtEnd(_builder, thenBB);
            node.Then.Accept(this);
            var thenV = _valueStack.Pop();
            LLVM.BuildBr(_builder, mergeBB);
            thenBB = LLVM.GetInsertBlock(_builder);

            LLVM.PositionBuilderAtEnd(_builder, elseBB);
            node.ElseExpression.Accept(this);
            var elseV = _valueStack.Pop();
            LLVM.BuildBr(_builder, mergeBB);
            elseBB = LLVM.GetInsertBlock(_builder);

            LLVM.PositionBuilderAtEnd(_builder, mergeBB);
            var ifType = _GetLLVMType(node.Type, new Pidgin.SourcePos());
            var phiNode = LLVM.BuildPhi(_builder, ifType, "iftmp");

            phiNode.AddIncoming(new[] {thenV, elseV}, new[] { thenBB, elseBB }, 2);
            _valueStack.Push(phiNode);
        }

        public void Visit(LetExpressionNode node)
        {
            var oldBindings = new List<LLVMValueRef>();

            foreach(var assignment in node.Assignments)
            {
                /*
                assignment.Expression.Accept(this);
                var calculated = _valueStack.Pop();
                var llvmType = _GetLLVMType(assignment.Type, new Pidgin.SourcePos());
                var value = LLVM.BuildAlloca(_builder, llvmType, assignment.Identifier);
                LLVM.BuildStore(_builder, calculated, value);
                _namedValues.TryGetValue(assignment.Identifier, out var oldValue);
                oldBindings.Add(oldValue);
                _namedValues.Add(assignment.Identifier, value);
                */
            }

            node.InExpression.Accept(this);

            for(int i = 0; i<node.Assignments.Count; i++)
            {
                _namedValues[node.Assignments[i].Identifier] = oldBindings[i];
            }
        }

        public void Visit(IdentifierTypeNode node)
        {
            throw new NotImplementedException();
        }

        private LLVMValueRef _CreateEntryBlockAlloca(LLVMValueRef function, string varName, LLVMTypeRef type)
        {
            var tempB = LLVM.CreateBuilder();
            var entry = function.GetEntryBasicBlock();
            LLVM.PositionBuilder(tempB, entry, entry.GetFirstInstruction());

            return LLVM.BuildAlloca(tempB, type, varName);
        }

        public void Visit(ProgramNode node)
        {
            throw new NotImplementedException();
        }
    }
}
