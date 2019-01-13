﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.AST.Types
{
    public class FunctionType : INodeType
    {
        private List<INodeType> _parameterTypes;
        private INodeType _returnType;

        public IReadOnlyList<INodeType> ParameterTypes => _parameterTypes;
        public INodeType ReturnType => _returnType;

        public FunctionType(List<INodeType> parameterTypes, INodeType returnType)
        {
            _parameterTypes = parameterTypes;
            _returnType = returnType;
        }

        public bool IsMatch(INodeType node)
            => (node is FunctionType f)
            ? _parameterTypes.SequenceEqual(f.ParameterTypes) && _returnType == f.ReturnType
            : false;

        public override string ToString() => $"{string.Join(", ", _parameterTypes)} -> {_returnType}";
    }
}
