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

        public void Visit(BinaryOperator node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine(node.Operator);
                node.Left.Accept(this);
                _isLast = true;
                node.Right.Accept(this);
            });
        }

        public void Visit(ConstantDouble node)
        {
            _DoPrint(() => 
            {
                Console.WriteLine(node.Value);
            });
        }

        public void Visit(UnaryOperator node)
        {
            _DoPrint(() =>
            {
                Console.WriteLine(node.Operator);
                _isLast = true;
                node.Node.Accept(this);
            });
        }

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

        private void _Indent()
        {
            Console.Write("|-");
            _currentIndent += _identString;
        }

        private void _IndentLast()
        {
            Console.Write("\\-");
            _currentIndent += " ";
        }

        private void _DecreaseIndent()
        {
            var removeIndex = _currentIndent.Length - _identString.Length;
            if(removeIndex > 0)
                _currentIndent = _currentIndent.Remove(removeIndex);
        }
    }
}
