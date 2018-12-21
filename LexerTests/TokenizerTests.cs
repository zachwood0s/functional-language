using Lexer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LexerTests
{
    [TestClass]
    public class TokenizerTest
    {
        private Tokenizer _tokenizer;

        [TestInitialize]
        public void Init()
        {
            _tokenizer = new Tokenizer(TokenDefinitions.DefaultDefinitions);
        }

        [TestMethod]
        public void TokenizesCorrectly()
        {
            string test = @",10 10.2.() "" \"" quoted"" #t#f test:";
            var tokens = _tokenizer.Tokenize(test).ToList();
            var expectedTokens = new List<Token>()
            {
                new Token(TokenType.Comma, ","),
                new Token(TokenType.Int, "10"),
                new Token(TokenType.Space, " "),
                new Token(TokenType.Float, "10.2"),
                new Token(TokenType.Dot, "."),
                new Token(TokenType.LeftParenthesis, "("),
                new Token(TokenType.RightParenthesis, ")"),
                new Token(TokenType.Space, " "),
                new Token(TokenType.QuotedString, @""" \"" quoted"""),
                new Token(TokenType.Space, " "),
                new Token(TokenType.True, "#t"),
                new Token(TokenType.False, "#f"),
                new Token(TokenType.Space, " "),
                new Token(TokenType.Identifier, "test"),
                new Token(TokenType.Colon, ":"),
                new Token(TokenType.SequenceTerminator, ""),
            };
                
            CollectionAssert.AreEqual(expectedTokens, tokens);
        }
    }
}
