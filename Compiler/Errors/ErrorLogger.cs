﻿using System;
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

        public delegate string Formatter(string msg);
        public static readonly Formatter None = msg => msg;
        public struct MessageConfig
        {
            public MessageConfig(SourcePosition pos, Formatter formatter) : this(pos, formatter, "") { }
            public MessageConfig(SourcePosition pos, Formatter formatter, string source)
            {
                Position = pos;
                Formatter = formatter;
                SourceText = source;
            }
            public MessageConfig(SourcePosition pos, params object[] formatters) : this(pos,
                msg => string.Format(msg, formatters)) { }
            public SourcePosition Position;
            public Formatter Formatter;
            public string SourceText;
        }

        public static Dictionary<MessageType, (Color color, char underline)> MessageColors = new Dictionary<MessageType, (Color, char)>()
        {
            [MessageType.Error] = (Colors.Error, '^'),
            [MessageType.Warning] = (Colors.Warning, '^'),
            [MessageType.MoreInfo] = (Colors.Accent, '_')
        };

        public static void PrintFromErrorCode(int code, SourcePosition pos)
        {
            PrintFromErrorCode(code, new MessageConfig(pos, None));
        }

        public static void PrintFromErrorCode(int code, MessageConfig config, params MessageConfig[] subMessagesConfig)
        {
            var message = ErrorIndex.Errors[code];
            message.Message = config.Formatter(message.Message);
            message.SourcePosition = config.Position;
            if(subMessagesConfig.Length != 0)
            {
                var subs = ErrorIndex.SubMessages[code];
                if (subs.Count != subMessagesConfig.Length) throw new ArgumentException($"{subMessagesConfig.Length} messages provided, expecting {subs.Count}", nameof(subMessagesConfig));

                foreach(var (sub, subConfig) in subs.TupZip(subMessagesConfig))
                {
                    sub.SourcePosition = subConfig.Position;
                    sub.Message = subConfig.Formatter(sub.Message);
                    message.SubMessages.Add(sub);
                }
            }
            PrintCompilerMessage(message, code);
        }

        public static void PrintCompilerMessage(CompilerMessage message, int errorCode = 0)
        {
            _TransformTabs(message);
            Console.WriteLine();
            _PrintMainMessage(message, errorCode);
            if(message.SubMessages.Count > 0)
            {
                _PrintSubMessage(message.SubMessages.First(), true);
                foreach(var sub in message.SubMessages.Skip(1))
                {
                    var differentFile = sub.SourcePosition.FileName != message.SourcePosition.FileName;
                    _PrintSubMessage(sub, false, differentFile);
                }
            }
        }

        private static void _TransformTabs(CompilerMessage message)
        {
            message.Message = message.Message.TabsToSpaces(); 
            foreach(var sub in message.SubMessages)
            {
                sub.Message = sub.Message.TabsToSpaces();
                if(sub.SourcePosition.SourceText != null && sub.SourcePosition.SourceText.Length > 0)
                {
                    sub.SourceText = sub.SourcePosition.SourceText;
                }
                if(sub.SourceText != null)
                {
                    sub.SourceText = sub.SourceText.TabsToSpaces();
                }
            }
        }

        private static void _PrintMainMessage(CompilerMessage message, int errorCode)
        {
            var messageSettings = MessageColors[message.Type];
            var messageName = message.Type.ToString().ToLower();
            var codeString = errorCode > 0 ? $"[E{errorCode:D4}]" : "";
            messageName += codeString;

            Console.WriteLineFormatted(messageName + "{0}", Colors.Message, messageSettings.color, $": {message.Message}");

            if (message.SourcePosition != null)
            {
                var line = message.SourcePosition.Line.ToString();
                var indentAmount = Math.Max(line.Length, MIN_INDENT);
                var stringIndent = new string(' ', indentAmount);

                Console.WriteLineFormatted(stringIndent + "--> {0}", Colors.Message, Colors.Accent, message.SourcePosition.ToStringExtended());
            }
        }

        private static void _PrintSubMessage(SubMessage message, bool isFirst = false, bool differentFile = false)
        {
            var messageSettings = MessageColors[message.Type];
            var line = message.SourcePosition.Line.ToString();
            var indentAmount = Math.Max(line.Length, MIN_INDENT);
            var stringIndent = new string(' ', indentAmount);

            var firstLine = isFirst
                ? $"{stringIndent} |"
                : $"{stringIndent.RemoveLast(2)}...";

            Console.WriteLine(firstLine, Colors.Accent);
            if (differentFile)
            {
                Console.WriteLine($"{stringIndent} | {message.SourcePosition.ToStringExtended()}", Colors.Accent);
                Console.WriteLine($"{stringIndent} |", Colors.Accent);
            }
            Console.Write($"{message.SourcePosition.Line}{stringIndent.RemoveLast(line.Length)} |", Colors.Accent);
            Console.WriteLine($" {message.SourceText}", messageSettings.color);
            Console.Write($"{stringIndent} |", Colors.Accent);

            var start = new string(' ', message.SourcePosition.Column);
            var highlight = new string(messageSettings.underline, message.SourcePosition.ErrorLength);
            Console.WriteLine($" {start}{highlight} {message.Message}", messageSettings.color);
        }

        public static string ToStringExtended(this SourcePosition pos) => $"{pos.FileName}:{pos.Line}:{pos.Column}";
        public static string RemoveLast(this string str) => str.RemoveLast(1);
        public static string RemoveLast(this string str, int amount) => str.Remove(str.Length - amount);
        public static string TabsToSpaces(this string str) => str.Replace('\t', ' ');
        public static IEnumerable<(T, U)> TupZip<T, U>(this IEnumerable<T> first, IEnumerable<U> second) => first.Zip(second, (item1, item2) => (item1, item2));
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
        public int ErrorCode { get; set; }

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
