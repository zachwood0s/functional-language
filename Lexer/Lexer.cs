using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lexer
{
    public class Tokenizer : ITokenizer<Token>
    {
        private readonly TokenDefinition[] _tokenDefinitions;

        public Tokenizer(TokenDefinition[] tokenDefinitions)
        {
            _tokenDefinitions = tokenDefinitions;
        }

        public IEnumerable<Token> Tokenize(string line)
        {
            var tokenMatches = _FindTokenMatches(line);

            var groupedByIndex = tokenMatches.GroupBy(x => x.StartIndex)
                .OrderBy(x => x.Key);

            TokenMatch lastMatch = null;
            foreach (var item in groupedByIndex)
            {
                var bestMatch = item.OrderBy(x => x.Precedence).First();
                if(lastMatch != null && bestMatch.StartIndex < lastMatch.EndIndex)
                {
                    continue;
                }
                yield return new Token(bestMatch.TokenType, bestMatch.Value);

                lastMatch = bestMatch;
            }

            yield return new Token(TokenType.SequenceTerminator);
        }

        private IEnumerable<TokenMatch> _FindTokenMatches(string line) => 
            from def in _tokenDefinitions
            from match in def.FindMatches(line)
            select match;
    }
}
