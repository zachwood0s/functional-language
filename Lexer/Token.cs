using System;
using System.Collections.Generic;
using System.Text;

namespace Lexer
{
    public class Token
    {
        public TokenType TokenType { get; private set; }
        public string Value { get; private set; }
        public Token(TokenType type, string value)
        {
            TokenType = type;
            Value = value;
        }

        public Token(TokenType type): this(type, string.Empty)
        {
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Token tok:
                    return tok.Value == Value && tok.TokenType == TokenType;
                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
