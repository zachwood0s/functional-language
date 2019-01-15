using Compiler.AST.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Nodes
{
    public class ConstantDoubleNode : ExprAST
    {
        private double _value;
        public double Value => _value;
        public new VariableType Type => DefaultTypes.Float;

        public ConstantDoubleNode(double value)
        {
            _value = value;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ConstantIntegerNode : ExprAST
    {
        private int _value;
        public int Value => _value;
        public new VariableType Type => DefaultTypes.Int;

        public ConstantIntegerNode(int value)
        {
            _value = value;
        }

        public override void Accept(IASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
