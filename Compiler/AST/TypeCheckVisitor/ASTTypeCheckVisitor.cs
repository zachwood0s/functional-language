using Compiler.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr;
using ZAntlr.AST;
using ZAntlr.AST.Nodes;
using ZAntlr.AST.Types;
using static Compiler.Errors.ErrorLogger;

namespace Compiler.AST.TypeCheckVisitor
{
    public class ASTTypeCheckVisitor : IASTVisitor
    {
        private Dictionary<string, (INodeType type, SourcePosition location)> _types;
        private Stack<INodeType> _typeStack;
        private Stack<INodeType> _expectedTypes;
        private ModuleHandler _handler;
        private List<AcceptableTypeCast> _knownCasts;
        private List<Operator> _knownOperators;

        private class Operator
        {
            public INodeType LHS { get; set; }
            public INodeType RHS { get; set; }
            public INodeType ReturnType { get; set; }
            public string Op { get; set; }
            
            public override bool Equals(object obj)
                => obj is Operator a
                ? Op == a.Op && a.LHS.IsMatch(LHS) && a.RHS.IsMatch(RHS) && a.ReturnType.IsMatch(ReturnType)
                : false;
        }
        private class AcceptableTypeCast
        {
            public INodeType From { get; set; }
            public INodeType To { get; set; }

            public override bool Equals(object obj)
                => obj is AcceptableTypeCast a
                ? a.From.IsMatch(From) && a.To.IsMatch(To)
                : false;

            public override int GetHashCode()
                => (From.ToString() + To.ToString()).GetHashCode();
        }


        public ASTTypeCheckVisitor(ModuleHandler handler)
        {
            _types = new Dictionary<string, (INodeType, SourcePosition)>();
            _typeStack = new Stack<INodeType>();
            _expectedTypes = new Stack<INodeType>();
            _handler = handler;
            _SetupKnownCasts();
            _SetupKnownOperators();
            _SetupBuiltInFunctions();
        }

        private void _SetupBuiltInFunctions()
        {
            _types.Add("printChar", (new FunctionType(new List<INodeType>() { DefaultTypes.Char }, DefaultTypes.Int), null));
        }

        private void _SetupKnownOperators()
        {
            _knownOperators = new List<Operator>()
            {
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Float, Op = BinaryOperatorOpCode.Addition},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Float, Op = BinaryOperatorOpCode.Subtraction},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Float, Op = BinaryOperatorOpCode.Multiplication},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Float, Op = BinaryOperatorOpCode.Division},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Float, Op = BinaryOperatorOpCode.Modulo},

                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Int, Op = BinaryOperatorOpCode.Addition},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Int, Op = BinaryOperatorOpCode.Subtraction},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Int, Op = BinaryOperatorOpCode.Multiplication},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Int, Op = BinaryOperatorOpCode.Division},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Int, Op = BinaryOperatorOpCode.Modulo},

                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.LessThan},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.LessThanEq},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.GreaterThan},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.GreaterThanEq},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.Equality},
                new Operator(){LHS = DefaultTypes.Float, RHS = DefaultTypes.Float, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.NotEquality},

                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.LessThan},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.LessThanEq},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.GreaterThan},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.GreaterThanEq},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.Equality},
                new Operator(){LHS = DefaultTypes.Int, RHS = DefaultTypes.Int, ReturnType = DefaultTypes.Bool, Op = BinaryOperatorOpCode.NotEquality},
            };
        }

        private void _SetupKnownCasts()
        {
            _knownCasts = new List<AcceptableTypeCast>()
            {
                new AcceptableTypeCast(){From = DefaultTypes.Int, To = DefaultTypes.Float},
                new AcceptableTypeCast(){From = DefaultTypes.Float, To = DefaultTypes.Int},
                new AcceptableTypeCast(){From = DefaultTypes.Char, To = DefaultTypes.Int},
                new AcceptableTypeCast(){From = DefaultTypes.Int, To = DefaultTypes.Char},
                new AcceptableTypeCast(){From = DefaultTypes.Char, To = DefaultTypes.Float},
               // new AcceptableTypeCast(){From = DefaultTypes.Float, To = DefaultTypes.Char},
            };
        }

        public void Visit(ASTNode node)
        {
            //throw new NotImplementedException();
        }

        public void Visit(ModuleNode node)
        {

        }

        public void Visit(ImportNode node)
        {
            var module = _handler.LoadModule(node.SourcePosition.FileName, node.ModuleName, node.SourcePosition);
            var types = module.GetExportedTypes().ToList();

            foreach (var type in types)
            {
                var name = $"__{node.AsName.Replace(".", "")}{type.Name}__";
                if (!_types.ContainsKey(name))
                {
                    _types.Add(name, (type.Type, node.SourcePosition));
                }
                else
                {
                    //error
                }
            }
        }

        public void Visit(BinaryOperatorNode node)
        {
            node.Left.Accept(this);
            var leftType = _typeStack.Pop();

            node.Right.Accept(this);
            var rightType = _typeStack.Pop();

            var foundOp = _knownOperators.Find(x => x.Op == node.Operator && x.LHS.IsMatch(leftType) && x.RHS.IsMatch(rightType));
            if (foundOp == null)
            {
                PrintFromErrorCode(11,
                    new MessageConfig(node.SourcePosition, node.Operator, leftType, rightType),
                    new MessageConfig(node.SourcePosition, leftType, rightType));
                return;
            }

            node.Type = leftType;
            node.ReturnType = foundOp.ReturnType;
            _typeStack.Push(node.ReturnType);
        }

        public void Visit(ConstantDoubleNode node)
        {
            _typeStack.Push(node.Type);
        }

        public void Visit(ConstantIntegerNode node)
        {
            _typeStack.Push(node.Type);
        }

        public void Visit(ConstantCharNode node)
        {
            _typeStack.Push(node.Type);
        }

        public void Visit(UnaryOperatorNode node)
        {
            node.Node.Accept(this);
        }

        public void Visit(FunctionCallNode node)
        {
            node.Callee.Accept(this);
            var callType = _typeStack.Pop();

            if(callType is FunctionType f)
            {
                if (f.ParameterTypes.Count != node.Args.Count)
                {

                }//throw new TypeCheckException($"Function call made with incorrect number of arguments. Expected {f.ParameterTypes.Count}, got {node.Args.Count}");

                foreach(var (actual, expected) in node.Args.TupZip(f.ParameterTypes))
                {
                    actual.Accept(this);
                    var argType = _typeStack.Pop();

                    if (!argType.IsMatch(expected))
                    {
                        PrintFromErrorCode(12,
                            new MessageConfig(actual.SourcePosition, expected, argType),
                            new MessageConfig(actual.SourcePosition, expected, argType),
                            new MessageConfig(f.SourcePosition, None));
                        return;
                    }
                }

                node.Type = f.ReturnType;
                _typeStack.Push(f.ReturnType);
            }
            else
            {
                //throw new TypeCheckException("Function call on non-function");
            }
        }

        public void Visit(FunctionNode node)
        {
            if(!_types.TryGetValue(node.Name, out var nodeType))
            {
                PrintFromErrorCode(9,
                    new MessageConfig(node.SourcePosition, node.Name),
                    new MessageConfig(node.SourcePosition, None));
                return; 
            }
            if(nodeType.type is FunctionType f)
            {
                var args = f.ParameterTypes.TupZip(node.Args);
                foreach(var (type, name) in args)
                {
                    _types.Add(name, (type, node.SourcePosition));
                }
                _expectedTypes.Push(f.ReturnType);
                node.Body.Accept(this);
                _expectedTypes.Pop();
                foreach(var (_, name) in args)
                {
                    _types.Remove(name);
                }
            }
            else
            {
                PrintFromErrorCode(10,
                    new MessageConfig(node.SourcePosition, nodeType.type),
                    new MessageConfig(node.SourcePosition, None),
                    new MessageConfig(nodeType.location, nodeType.type));
            }
        }

        public void Visit(PrototypeNode node)
        {
            _types.Add(node.Name, (node.Type, node.SourcePosition));
            _typeStack.Push(node.Type);
        }

        public void Visit(IdentifierNode node)
        {
            var name = node.Name;
            if (name.Contains("."))
            {
                name = $"__{name.Replace(".","")}__";
            }
            if(_types.TryGetValue(name, out var type))
            {
                _typeStack.Push(type.type);
            }
            else
            {
                PrintFromErrorCode(7,
                    new MessageConfig(node.SourcePosition,  node.Name),
                    new MessageConfig(node.SourcePosition, None));
            }
        }

        public void Visit(VariableTypeDeclarationNode node)
        {
            if(_types.TryGetValue(node.Name, out var type))
            {
                PrintFromErrorCode(2,
                    new MessageConfig(node.SourcePosition, node.Name),
                    new MessageConfig(node.SourcePosition, None),
                    new MessageConfig(type.location, None));
            }
            else
            {
                _types.Add(node.Name, (node.Type, node.SourcePosition));
            }
        }

        public void Visit(IdentifierTypeNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(IfExpressionNode node)
        {
            node.IfCondition.Accept(this);
            var condType = _typeStack.Pop();

            if (!condType.IsMatch(DefaultTypes.Bool))
            {
                PrintFromErrorCode(4,
                    new MessageConfig(node.IfCondition.SourcePosition, None),
                    new MessageConfig(node.IfCondition.SourcePosition, condType));
                return;
            }

            var expectedType = _expectedTypes.Peek();
            node.Then.Accept(this);
            var thenType = _typeStack.Pop();
            if (!thenType.IsMatch(expectedType))
            {
                PrintFromErrorCode(5,
                    new MessageConfig(node.Then.SourcePosition, expectedType, thenType),
                    new MessageConfig(node.Then.SourcePosition, expectedType, thenType));
                _typeStack.Push(expectedType);
                return;
            }

            node.ElseExpression.Accept(this);
            var elseType = _typeStack.Pop();
            if (!elseType.IsMatch(expectedType))
            {
                PrintFromErrorCode(6,
                    new MessageConfig(node.ElseExpression.SourcePosition, expectedType, elseType),
                    new MessageConfig(node.ElseExpression.SourcePosition, expectedType, elseType));
                _typeStack.Push(expectedType);
                return;
            }

            node.Type = thenType;

            _typeStack.Push(expectedType);
        }

        public void Visit(LetExpressionNode node)
        {
            foreach(var decl in node.Declarations)
            {
                if (_types.ContainsKey(decl.Name))
                {
                    var (_, pos) = _types[decl.Name];
                    PrintFromErrorCode(2,
                        new MessageConfig(node.SourcePosition, decl.Name),
                        new MessageConfig(decl.SourcePosition, None),
                        new MessageConfig(pos, None));
                    return;
                }
                _types.Add(decl.Name, (decl.Type, decl.SourcePosition));
            }
            foreach(var assignment in node.Assignments)
            {
                var (type, pos) = _types[assignment.Identifier];
                _expectedTypes.Push(type);
                assignment.Expression.Accept(this);
                var exprType = _typeStack.Pop();
                _expectedTypes.Pop();

                if (!type.IsMatch(exprType))
                {
                    PrintFromErrorCode(3,
                        new MessageConfig(assignment.SourcePosition, type, exprType),
                        new MessageConfig(assignment.SourcePosition, None),
                        new MessageConfig(pos, type));
                }
            }
            node.InExpression.Accept(this);
            if (_typeStack.Count > 0)
            {
                var bodyType = _typeStack.Pop();
                var expectedType = _expectedTypes.Peek();
                if (!bodyType.IsMatch(expectedType))
                {
                    PrintFromErrorCode(8,
                        new MessageConfig(node.InExpression.SourcePosition, expectedType, bodyType),
                        new MessageConfig(node.InExpression.SourcePosition, expectedType, bodyType));
                }

                node.Type = bodyType;
                _typeStack.Push(bodyType);
            }

            foreach(var assignment in node.Assignments)
            {
                _types.Remove(assignment.Identifier);
            }
        }

        public void Visit(TypeCastNode node)
        {
            node.Expression.Accept(this);
            var exprType = _typeStack.Pop();

            if (exprType.IsMatch(node.ToType) || _knownCasts.Contains(new AcceptableTypeCast() { From = exprType, To = node.ToType }))
            {
                _typeStack.Push(node.ToType);
                node.FromType = exprType;
            }
            else
            {
                PrintFromErrorCode(1,
                    new MessageConfig(node.SourcePosition, exprType, node.ToType),
                    new MessageConfig(node.Expression.SourcePosition, exprType),
                    new MessageConfig(node.SourcePosition, exprType, node.ToType));
            }
        }

        public void Visit(ProgramNode node)
        {
            foreach(var import in node.Imports)
            {
                import.Accept(this);
            }
            foreach(var child in node.Declarations)
            {
                child.Accept(this);
            }
            foreach (var child in node.Definitions)
            {
                child.Accept(this);
            }
        }
    }
}
