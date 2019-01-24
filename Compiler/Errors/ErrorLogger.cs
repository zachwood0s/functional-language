using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr;
using Console = Colorful.Console;

namespace Compiler.Errors
{
    public static class ErrorLogger
    {
        public const int MIN_INDENT = 2;

        public static class Colors {
            public static Color Error = Color.Red;
            public static Color Warning = Color.Yellow;
            public static Color Accent = Color.Cyan;
            public static Color Message = Color.White;
        }

        public static Dictionary<MessageType, (Color color, char underline)> MessageColors = new Dictionary<MessageType, (Color, char)>()
        {
            [MessageType.Error] = (Colors.Error, '^'),
            [MessageType.Warning] = (Colors.Warning, '^'),
            [MessageType.MoreInfo] = (Colors.Accent, '_')
        };

        public static void PrintCompilerMessage(CompilerMessage message)
        {
            Console.WriteLine();
            _PrintMainMessage(message);
            if(message.SubMessages.Count > 0)
            {
                _PrintSubMessage(message.SubMessages.First(), true);
                foreach(var sub in message.SubMessages.Skip(1))
                {
                    _PrintSubMessage(sub);
                }
            }
        }

        private static void _PrintMainMessage(CompilerMessage message)
        {
            var messageSettings = MessageColors[message.Type];
            var messageName = message.Type.ToString().ToLower();

            Console.WriteLineFormatted(messageName + "{0}", Colors.Message, messageSettings.color, $": {message.Message}");

            if (message.SourcePosition != null)
            {
                var line = message.SourcePosition.Line.ToString();
                var indentAmount = Math.Max(line.Length, MIN_INDENT);
                var stringIndent = new string(' ', indentAmount);

                Console.WriteLineFormatted(stringIndent + "--> {0}", Colors.Message, Colors.Accent, message.SourcePosition.ToStringExtended());
            }
        }

        private static void _PrintSubMessage(SubMessage message, bool isFirst = false)
        {
            var messageSettings = MessageColors[message.Type];
            var line = message.SourcePosition.Line.ToString();
            var indentAmount = Math.Max(line.Length, MIN_INDENT);
            var stringIndent = new string(' ', indentAmount);

            var firstLine = isFirst
                ? $"{stringIndent} |"
                : $"{stringIndent.RemoveLast(2)}...";

            Console.WriteLine(firstLine, Colors.Accent);
            Console.Write($"{message.SourcePosition.Line}{stringIndent.RemoveLast()}|", Colors.Accent);
            Console.WriteLine($"{message.SourceText}", messageSettings.color);
            Console.Write($"{stringIndent} |", Colors.Accent);

            var start = new string(' ', message.SourcePosition.Column);
            var highlight = new string(messageSettings.underline, message.SourcePosition.ErrorLength);
            Console.WriteLine($"{start}{highlight} {message.Message}", messageSettings.color);
        }

        public static string ToStringExtended(this SourcePosition pos) => $"{pos.FileName}:{pos.Line}:{pos.Column}";
        public static string RemoveLast(this string str) => str.RemoveLast(1);
        public static string RemoveLast(this string str, int amount) => str.Remove(str.Length - amount);
    }

    public enum MessageType
    {
        Error,
        Warning,
        MoreInfo
    }

    public class CompilerMessage
    {

        public SourcePosition SourcePosition { get; set; }
        public string Message { get; set; }
        public List<SubMessage> SubMessages { get; set; }
        public MessageType Type { get; set; }

        public CompilerMessage()
        {
            SubMessages = new List<SubMessage>();
        }

        public CompilerMessage(string message, MessageType type): this()
        {
            Message = message;
            Type = type;
        }

        public CompilerMessage(string message, MessageType type, SourcePosition position) :this(message, type)
        {
            SourcePosition = position;
        }

        public CompilerMessage(string message, MessageType type, SourcePosition position, List<SubMessage> subs) :this(message, type, position)
        {
            SubMessages = subs;
        }
    }

    public class SubMessage
    {
        public SourcePosition SourcePosition { get; set; }
        public MessageType Type { get; set; }
        public string Message { get; set; }
        public string SourceText { get; set; }

        public SubMessage()
        {
        }

        public SubMessage(string message, string sourceText, MessageType type, SourcePosition position)
        {
            SourcePosition = position;
            Type = type;
            Message = message;
            SourceText = sourceText;
        }
    }
}
