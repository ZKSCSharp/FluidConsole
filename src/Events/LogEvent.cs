using Fluid_ConsoleManager.src;

namespace Fluid_ConsoleManager.src.Events
{
    public class LogEvent : EventArgs
    {
        public string Input { get; }
        private string senderName { get; }
        public FConsole.LogType LogType { get; }
        public LogEvent(string senderName, string input, FConsole.LogType logtype)
        {
            this.senderName = senderName;
            Input = input;
            LogType = logtype;
        }

        public void Log()
        {
            switch (LogType)
            {
                case FConsole.LogType.SUCCESS:
                    new ColorEvent(ConsoleColor.Green).SetForeGround();
                    break;
                case FConsole.LogType.ERROR:
                    new ColorEvent(ConsoleColor.Red).SetForeGround();
                    break;
                case FConsole.LogType.INFO:
                    new ColorEvent(ConsoleColor.Cyan).SetForeGround();
                    break;
                case FConsole.LogType.WARN:
                    new ColorEvent(ConsoleColor.Yellow).SetForeGround();
                    break;
                case FConsole.LogType.CRITICAL:
                    new ColorEvent(ConsoleColor.DarkRed).SetForeGround();
                    break;
                default:
                    new ColorEvent(ConsoleColor.White).SetForeGround();
                    break;
            }

            Console.WriteLine($"[{senderName.ToUpper()}] - {Input}");
            new ColorEvent(ConsoleColor.White).SetForeGround();
        }

    }
}
