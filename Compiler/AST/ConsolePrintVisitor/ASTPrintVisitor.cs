using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.AST.Nodes;

namespace Compiler.AST.ConsolePrintVisitor
{
    public class ASTPrintVisitor : IASTVisitor
    {
        private const string _identString = "| ";
        private string _currentIndent = "";
        private bool _isLast = true;

        public void Visit(ASTNode node)
        {
        }

        public void Visit(BinaryOperatorNode node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine(node.Operator);
                node.Left.Accept(this);
                _isLast = true;
                node.Right.Accept(this);
            });
        }

        public void Visit(ConstantDoubleNode node)
        {
            _DoPrint(() => 
            {
                Console.WriteLine(node.Value);
            });
        }

        public void Visit(UnaryOperatorNode node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine(node.Operator);
                _isLast = true;
                node.Node.Accept(this);
            });
        }

        public void Visit(FunctionCallNode node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine($"{node.Callee}:");
                for(int i = 0; i<node.Args.Count; i++)
                {
                    if (i == node.Args.Count - 1)
                        _isLast = true;
                    node.Args[i].Accept(this);
                }
            });
        }

        public void Visit(FunctionNode node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine("+Prototype: ");
                node.Prototype.Accept(this);

                _WriteIndent($"+Params: {string.Join(",", node.Args)}");
                _WriteIndent("+Body:");
                _isLast = true;
                node.Body.Accept(this);
            });
        }

        public void Visit(PrototypeNode node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine($"{node.Name}: {string.Join(",",node.ArgTypes)} -> {node.Return}");
            });
        }

        public void Visit(IdentifierNode node)
        {
            _DoPrint(() => Console.WriteLine(node.Name));
        }

        public void Visit(IfExpressionNode node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine("If/Then/Else");
                _WriteIndent("+Condition:");
                node.IfCondition.Accept(this);
                _WriteIndent("+Then:");
                if (node.ElseExpression.IsEmpty) _isLast = true;
                node.Then.Accept(this);

                if (node.ElseExpression.IsDefined)
                {
                    _isLast = true;
                    _WriteIndent("+Else:");
                    node.ElseExpression.Get().Accept(this);
                }
            });
        }

        public void Visit(LetExpressionNode node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine("Let");
                _WriteIndent("+Assignments:");
                foreach(var assignment in node.Assignments)
                {
                    _WriteIndent($"++ {assignment.Identifier}:");
                    assignment.Expression.Accept(this);
                }
                _WriteIndent("+In:");
                node.InExpression.Accept(this);
            });
        }

        #region Helper Methods
        private void _DoPrint(Action action)
        {
            Console.Write(_currentIndent);
            if (_isLast)
            {
                _IndentLast();
                _isLast = false;
            }
            else _Indent();
            action();
            _DecreaseIndent();
        }

        private void _WriteIndent(string text)
        {
            Console.Write(_currentIndent);
            Console.WriteLine(text);
        }

        private void _Indent()
        {
            Console.Write("|-");
            _currentIndent += _identString;
        }

        private void _IndentLast()
        {
            Console.Write("\\-");
            _currentIndent += "  ";
        }

        private void _DecreaseIndent()
        {
            var removeIndex = _currentIndent.Length - _identString.Length;
            if(removeIndex > 0)
                _currentIndent = _currentIndent.Remove(removeIndex);
        }
        #endregion
    }
}
