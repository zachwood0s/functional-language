using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr.AST;
using ZAntlr.AST.Nodes;
using ZAntlr.AST.Types;

namespace Compiler.AST.TypeCheckVisitor
{
    public class ASTTypeCheckVisitor : IASTVisitor
    {
        private Dictionary<string, INodeType> _types;
        private Stack<INodeType> _typeStack;
        private Stack<INodeType> _expectedTypes;

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


        public ASTTypeCheckVisitor()
        {
            _types = new Dictionary<string, INodeType>();
            _typeStack = new Stack<INodeType>();
            _expectedTypes = new Stack<INodeType>();
            _SetupKnownCasts();
            _SetupKnownOperators();
            _SetupBuiltInFunctions();
        }

        private void _SetupBuiltInFunctions()
        {
            _types.Add("printChar", new FunctionType(new List<INodeType>() { DefaultTypes.Char }, DefaultTypes.Int));
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
                new AcceptableTypeCast(){From = DefaultTypes.Float, To = DefaultTypes.Char},
            };
        }

        public void Visit(ASTNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(BinaryOperatorNode node)
        {
            node.Left.Accept(this);
            var leftType = _typeStack.Pop();

            node.Right.Accept(this);
            var rightType = _typeStack.Pop();

            var foundOp = _knownOperators.Find(x => x.Op == node.Operator && x.LHS.IsMatch(leftType) && x.RHS.IsMatch(rightType));
            if (foundOp == null) throw new TypeCheckException($"No defined operator '{node.Operator}' for {leftType} and {rightType}");

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
                if (f.ParameterTypes.Count != node.Args.Count) throw new TypeCheckException($"Function call made with incorrect number of arguments. Expected {f.ParameterTypes.Count}, got {node.Args.Count}");

                foreach(var typePair in node.Args.Zip(f.ParameterTypes, (actual, expected) => (actual, expected)))
                {
                    typePair.actual.Accept(this);
                    var argType = _typeStack.Pop();

                    if (!argType.IsMatch(typePair.expected)) throw new TypeCheckException($"Incorrect argument type. Expected {typePair.expected}, got {argType}");
                }

                node.Type = f.ReturnType;
                _typeStack.Push(f.ReturnType);
            }
            else
            {
                throw new TypeCheckException("Function call on non-function");
            }
        }

        public void Visit(FunctionNode node)
        {
            if(!_types.TryGetValue(node.Name, out var nodeType))
            {
                //Error 
                return; 
            }
            if(nodeType is FunctionType f)
            {
                var args = f.ParameterTypes.Zip(node.Args, (type, name) => (type, name));
                foreach(var (type, name) in args)
                {
                    _types.Add(name, type);
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
                //Error
            }
        }

        public void Visit(PrototypeNode node)
        {
            _types.Add(node.Name, node.Type);
            _typeStack.Push(node.Type);
        }

        public void Visit(IdentifierNode node)
        {
            if(_types.TryGetValue(node.Name, out var type))
            {
                _typeStack.Push(type);
            }
            else
            {
                throw new TypeCheckException($"Identifier {node.Name} does not have a specified type");
            }
        }

        public void Visit(IdentifierTypeNode node)
        {
            if (_types.ContainsKey(node.Name)) throw new TypeCheckException($"Cannot redifine type of {node.Name}");

            _types.Add(node.Name, node.Type);
            _typeStack.Push(node.Type);
        }

        public void Visit(IfExpressionNode node)
        {
            node.IfCondition.Accept(this);
            var condType = _typeStack.Pop();

            if (!condType.IsMatch(DefaultTypes.Bool)) throw new TypeCheckException($"If condition must evaluate to {DefaultTypes.Bool}");

            var expectedType = _expectedTypes.Peek();
            node.Then.Accept(this);
            var thenType = _typeStack.Pop();
            if (!thenType.IsMatch(expectedType)) throw new TypeCheckException($"Then branch type is not expected. Expected {expectedType} got {thenType}");

            node.ElseExpression.Accept(this);
            var elseType = _typeStack.Pop();
            if (!elseType.IsMatch(expectedType)) throw new TypeCheckException($"Else branch type is not expected. Expected {expectedType} got {elseType}");

            node.Type = thenType;

            _typeStack.Push(expectedType);
        }

        public void Visit(LetExpressionNode node)
        {
            foreach(var decl in node.Declarations)
            {
                if (_types.ContainsKey(decl.Name))
                {
                    //Error
                    return;
                }
            }
            foreach(var assignment in node.Assignments)
            {
                var type = _types[assignment.Identifier];
                _expectedTypes.Push(type);
                assignment.Expression.Accept(this);
                var exprType = _typeStack.Pop();
                _expectedTypes.Pop();

                if (!type.IsMatch(exprType))
                {
                    //Error
                    throw new TypeCheckException($"Assignment type of {assignment.Identifier} does not match type definition. Expected {type}, got {exprType}");
                }
            }
            node.InExpression.Accept(this);
            var bodyType = _typeStack.Pop();
            var expectedType = _expectedTypes.Peek();
            if (!bodyType.IsMatch(expectedType)) throw new TypeCheckException($"In part of let expression does not match expected type {expectedType}. In type: {bodyType}");

            node.Type = bodyType;
            _typeStack.Push(bodyType);

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
            else throw new TypeCheckException($"Cannot implicitly convert {exprType} to {node.ToType}");
        }

        public void Visit(ProgramNode node)
        {
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
