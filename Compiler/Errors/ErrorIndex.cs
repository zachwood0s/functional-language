using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAntlr.AST.Types;

namespace Compiler.Errors
{
    public static class ErrorIndex
    {
        public static readonly CompilerMessage AbortError = new CompilerMessage("aborting due to previous error", MessageType.Error);
        public static readonly Dictionary<int, CompilerMessage> Errors = new Dictionary<int, CompilerMessage>()
        {
            [1] = new CompilerMessage("No known conversion from {0} to {1}", MessageType.Error),
            [2] = new CompilerMessage("Cannot reassign type of '{0}'", MessageType.Error),
            [3] = new CompilerMessage("Assignment does not match type definitions. Expected {0}, got {1}", MessageType.Error),
            [4] = new CompilerMessage($"If condition must evaulate to {DefaultTypes.Bool}", MessageType.Error),
            [5] = new CompilerMessage("Then branch type not expected. Expected {0}, got {1}", MessageType.Error),
            [6] = new CompilerMessage("Else branch type not expected. Expected {0}, got {1}", MessageType.Error),
            [7] = new CompilerMessage("Use of an undefined identifier '{0}'", MessageType.Error),
            [8] = new CompilerMessage("In branch type not expected. Expected {0}, got {1}", MessageType.Error),
        };

        public static readonly List<SubMessage> Expected = new List<SubMessage>()
        {
            new SubMessage() {Message = "expected {0}, got {1}", Type = MessageType.Error}
        };

        public static readonly Dictionary<int, List<SubMessage>> SubMessages = new Dictionary<int, List<SubMessage>>()
        {
            [1] = new List<SubMessage>() {
                new SubMessage() { Message = "has type {0}", Type = MessageType.MoreInfo},
                new SubMessage() { Message = "Unknown conversion from {0} to {1}", Type = MessageType.Error }
            },
            [2] = new List<SubMessage>()
            {
                new SubMessage() { Message = "type redefinition occurs here", Type = MessageType.Error },
                new SubMessage() { Message = "previous definition occurs here", Type = MessageType.MoreInfo },
            },
            [3] = new List<SubMessage>()
            {
                new SubMessage() {Message = "assignment occurs here", Type = MessageType.Error },
                new SubMessage() {Message = "previously defined as '{0}' here", Type = MessageType.MoreInfo }
            },
            [4] = new List<SubMessage>()
            {
                new SubMessage() {Message = "condition evaluates to '{0}' not '"+DefaultTypes.Bool+"'", Type = MessageType.Error}
            },
            [5] = Expected,
            [6] = Expected,
            [7] = new List<SubMessage>()
            {
                new SubMessage() {Message = "undefined identifier", Type = MessageType.Error}
            },
            [8] = Expected,
        };

        public static CompilerMessage GetCompilerMessage(int errorCode)
        {
            return Errors[errorCode];
        }
    }
}
