using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Compiler.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAntlr
{
    public delegate void ParseErrorHandler(int line, int charPositionInLine, string msg);
    public class ErrorListener: BaseErrorListener, IAntlrErrorListener<int>
    {
        private ITokenStream _stream;

        public ErrorListener(ITokenStream stream)
        {
            _stream = stream;
        }

        public bool FoundErrors { get; set; }

        public override void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, 
            int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            var message = _CreateErrorMessage(recognizer, line, charPositionInLine, msg);
            if (offendingSymbol != null)
            {
                var errorLength = offendingSymbol.StopIndex+1 - offendingSymbol.StartIndex;
                message.SourcePosition.ErrorLength = errorLength;
                var sourceText = Utils.GetLineTextForToken(offendingSymbol, _stream);
                var subMessage = new SubMessage()
                {
                    SourcePosition = new SourcePosition()
                    {
                        ErrorLength = errorLength,
                        Column = charPositionInLine,
                        Line = line
                    },
                    SourceText = sourceText,
                    Message = msg,
                    Type = MessageType.Error
                };

                message.SubMessages.Add(subMessage);
            }
            ErrorLogger.PrintCompilerMessage(message);
        }

        public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] int offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            var message = _CreateErrorMessage(recognizer, line, charPositionInLine, msg);
            ErrorLogger.PrintCompilerMessage(message);
        }

        private CompilerMessage _CreateErrorMessage(IRecognizer recognizer, int line, int charPositionInLine, string msg)
        {
            FoundErrors = true;
            string sourceName = recognizer.InputStream.SourceName;
            var message = new CompilerMessage()
            {
                SourcePosition = new SourcePosition() { Line = line, Column = charPositionInLine, FileName = sourceName },
                Message = msg,
                Type = MessageType.Error
            };
            return message;
        }

    }
}
