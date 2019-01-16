using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                Console.WriteLine($"{node.Value:F1}");
            });
        }

        public void Visit(ConstantIntegerNode node)
        {
            _DoPrint(() => 
            {
                Console.WriteLine(node.Value);
            });
        }

        public void Visit(ConstantCharNode node)
        {
            _DoPrint(() => 
            {
                Console.WriteLine($"'{Regex.Escape(node.Value.ToString())}'");
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
                if(node.Callee is IdentifierNode ident) Console.WriteLine($"{ident.Name}:");
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
                Console.WriteLine($"{node.Name}: {node.Type}");
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
                node.Then.Accept(this);

                _isLast = true;
                _WriteIndent("+Else:");
                node.ElseExpression.Accept(this);
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
                    _WriteIndent($"++ {assignment.Identifier}: {assignment.Type}");
                    assignment.Expression.Accept(this);
                }
                _WriteIndent("+In:");
                _isLast = true;
                node.InExpression.Accept(this);
            });
        }

        public void Visit(IdentifierTypeNode node)
        {
            _DoPrint(() => Console.WriteLine($"{node.Name}'s Type: {node.Type}"));
        }

        public void Visit(TypeCastNode node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine($"Cast to: {node.ToType}");
                node.Expression.Accept(this);
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
