using Fluid_ConsoleManager.src;
using Fluid_ConsoleManager.src.Events.Interfaces;
using System.Runtime.InteropServices.Marshalling;

namespace Fluid_ConsoleManager.src.Events
{
    public class LogEvent : IEvent
    {
        private protected string sender, message;
        private protected FConsole.LogType logtype;
        public LogEvent(string senderName, string input, FConsole.LogType logtype)
        {
            this.sender = senderName;
            this.message = input;
            this.logtype = logtype;
        }

        public virtual string Message => this.message;
        public virtual string Sender => this.sender;
        public virtual FConsole.LogType LogType => this.logtype;
    }
}
