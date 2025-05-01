using Fluid_ConsoleManager.src.Core;
using Fluid_ConsoleManager.src.Events;
using Fluid_ConsoleManager.src.Handlers.Interface;

namespace Fluid_ConsoleManager.src.Handlers
{
    public class LogHandler : IEventHandler<LogEvent>
    {
        public void Handle(LogEvent evt)
        {
            switch (evt.LogType)
            {
                case FConsole.LogType.SUCCESS:
                    EventBus.Publish(new ColorEvent(ConsoleColor.Green));
                    break;
                case FConsole.LogType.ERROR:
                    EventBus.Publish(new ColorEvent(ConsoleColor.Red));
                    break;
                case FConsole.LogType.INFO:
                    EventBus.Publish(new ColorEvent(ConsoleColor.Cyan));
                    break;
                case FConsole.LogType.WARN:
                    EventBus.Publish(new ColorEvent(ConsoleColor.Yellow));
                    break;
                case FConsole.LogType.CRITICAL:
                    EventBus.Publish(new ColorEvent(ConsoleColor.DarkRed));
                    break;
                default:
                    EventBus.Publish(new ColorEvent(ConsoleColor.White));
                    break;
            }

            Console.WriteLine($"[{evt.Sender.ToUpper()}] - {evt.Message}");

            EventBus.Publish(new ColorEvent(ConsoleColor.White));
        }
    }
}
