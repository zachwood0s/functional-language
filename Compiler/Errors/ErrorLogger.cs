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
    public static class Logger
    {
        private const int MIN_INDENT = 2;

        public static class Colors {
            public static Color Error = Color.Red;
            public static Color Warning = Color.Yellow;
            public static Color Accent = Color.Cyan;
            public static Color Message = Color.White;
        }

        public static void PrintCompilerMessage(CompilerMessage message)
        {
            switch (message.Type)
            {
                case CompilerMessage.MessageType.Error:
                    _PrintErrorMessage(message);
                    break;
                case CompilerMessage.MessageType.Warning:
                    _PrintWarningMessage(message);
                    break;
                default:
                    _PrintMessage(message);
                    break;
            }
        }

        private static void _PrintErrorMessage(CompilerMessage message)
        {
            Console.WriteLineFormatted("error{0}", Colors.Message, Colors.Error, $": {message.Message}");
            var line = message.SourcePosition.Line.ToString();
            var indentAmount = Math.Max(line.Length, MIN_INDENT);
            var stringIndent = new string(' ', indentAmount);

            Console.WriteLineFormatted(stringIndent+"--> {0}", Colors.Message, Colors.Accent, message.SourcePosition.ToStringExtended());


            Console.WriteLine($"{stringIndent} |", Colors.Accent);
            Console.Write($"{message.SourcePosition.Line}{stringIndent.RemoveLast()}|", Colors.Accent);
            Console.WriteLine($"{message.SourceText}", Colors.Error);
            Console.Write($"{stringIndent} |", Colors.Accent);

            var start = new string(' ', message.SourcePosition.Column);
            var highlight = new string('^', message.SourcePosition.ErrorLength);
            Console.WriteLine($"{start}{highlight} {message.SubMessage}", Colors.Error);
        }

        private static void _PrintWarningMessage(CompilerMessage message)
        {

        }

        private static void _PrintMessage(CompilerMessage message)
        {

        }

        public static string ToStringExtended(this SourcePosition pos) => $"{pos.FileName}:{pos.Line}:{pos.Column}";
        public static string RemoveLast(this string str) => str.Remove(str.Length - 1);
    }

    public class CompilerMessage
    {
        public enum MessageType
        {
            Error,
            Warning
        }

        public SourcePosition SourcePosition { get; set; }
        public string Message { get; set; }
        public string SubMessage { get; set; }
        public string SourceText { get; set; }
        public MessageType Type { get; set; }
    }
}
