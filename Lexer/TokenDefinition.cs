using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lexer
{
    public class TokenDefinition
    {
        private TokenType _tokenType;
        private Regex _regex;
        private int _precedence;

        public TokenDefinition(TokenType type, string regex, int precedence = 1)
        {
            _tokenType = type;
            _regex = new Regex(regex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            _precedence = precedence;
        }

        public IEnumerable<TokenMatch> FindMatches(string inputString)
        {
            var matches = _regex.Matches(inputString);
            for(int i = 0; i<matches.Count; i++)
            {
                yield return new TokenMatch()
                {
                    StartIndex = matches[i].Index,
                    EndIndex = matches[i].Index + matches[i].Length,
                    TokenType = _tokenType,
                    Value = matches[i].Value,
                    Precedence = _precedence
                };
            }
        }
    }

    public class TokenMatch
    {
        public TokenType TokenType { get; set; }
        public string Value { get; set; } = "";
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int Precedence { get; set; }
    }
}
