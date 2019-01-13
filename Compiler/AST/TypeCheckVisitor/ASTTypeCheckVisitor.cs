﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.AST.Nodes;
using Compiler.AST.Types;

namespace Compiler.AST.TypeCheckVisitor
{
    public class ASTTypeCheckVisitor : IASTVisitor
    {
        private Dictionary<string, INodeType> _types;
        private Stack<INodeType> _typeStack;
        private Stack<INodeType> _expectedTypes;

        public ASTTypeCheckVisitor()
        {
            _types = new Dictionary<string, INodeType>();
            _typeStack = new Stack<INodeType>();
            _expectedTypes = new Stack<INodeType>();
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

            if (!leftType.IsMatch(rightType)) throw new TypeCheckException($"Cannot implicitly convert {leftType} to {rightType}");

            _typeStack.Push(leftType);
        }

        public void Visit(ConstantDoubleNode node)
        {
            _typeStack.Push(node.Type);
        }

        public void Visit(ConstantIntegerNode node)
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

                _typeStack.Push(f.ReturnType);
            }
            else
            {
                throw new TypeCheckException("Function call on non-function");
            }
        }

        public void Visit(FunctionNode node)
        {
            node.Prototype.Accept(this);
            var functionType = _typeStack.Pop();

            if(functionType is FunctionType f)
            {
                foreach(var arg in node.Prototype.Type.ParameterTypes.Zip(node.Args, (type, name) => (type, name)))
                {
                    _types.Add(arg.name, arg.type);   
                }
                _expectedTypes.Push(f.ReturnType);
                node.Body.Accept(this);
                _expectedTypes.Pop();
            }
            else
            {
                throw new TypeCheckException("Prototype does not describe a function");
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

            _typeStack.Push(expectedType);
        }

        public void Visit(LetExpressionNode node)
        {
            foreach(var assignment in node.Assignments)
            {
                _types.Add(assignment.Identifier, assignment.Type);
                _expectedTypes.Push(assignment.Type);
                assignment.Expression.Accept(this);
                _expectedTypes.Pop();
                var exprType = _typeStack.Pop();

                if (!assignment.Type.IsMatch(exprType)) throw new TypeCheckException($"Assignment type of {assignment.Identifier} does not match type definition");
            }
            node.InExpression.Accept(this);
            var bodyType = _typeStack.Pop();
            var expectedType = _expectedTypes.Peek();
            if (!bodyType.IsMatch(expectedType)) throw new TypeCheckException($"In part of let expression does not match expected type {expectedType}. In type: {bodyType}");
        }
    }
}