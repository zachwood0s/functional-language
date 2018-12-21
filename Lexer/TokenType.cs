

namespace Lexer
{
    public enum TokenType
    {
        Comma,
        Int,
        Float,
        Space,
        Dot,
        LeftParenthesis,
        RightParenthesis,
        Identifier,
        QuotedString,
        True,
        False,
        Colon,
        SequenceTerminator,
        Equal
    }

    public static class TokenDefinitions {
        public static readonly TokenDefinition[] DefaultDefinitions =
        {
            new TokenDefinition(TokenType.QuotedString,     @"([""'])(?:\\\1|.)*?\1"),
            new TokenDefinition(TokenType.Float,            @"[-+]?\d*\.\d+([eE][-+]?\d+)?"),
            new TokenDefinition(TokenType.Int,              @"[-+]?\d+"),
            new TokenDefinition(TokenType.True,             @"#t"),
            new TokenDefinition(TokenType.False,            @"#f"),
            new TokenDefinition(TokenType.Identifier,       @"[*<>\?\-+/A-Za-z->!]+"),
            new TokenDefinition(TokenType.Dot,              @"\."),
            new TokenDefinition(TokenType.Comma,            @"\,"),
            new TokenDefinition(TokenType.Colon,            @"\:"),
            new TokenDefinition(TokenType.LeftParenthesis,  @"\("),
            new TokenDefinition(TokenType.RightParenthesis, @"\)"),
            new TokenDefinition(TokenType.Space,            @"\s")
        };
    }
}