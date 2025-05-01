using Fluid_ConsoleManager.src.Core;
using Fluid_ConsoleManager.src.Events;
using Fluid_ConsoleManager.src.Handlers;
using static Fluid_ConsoleManager.src.FConsole;

namespace Fluid_ConsoleManager.src
{
    public class FConsole
    {
        public enum LogType
        {
            DEFAULT, SUCCESS, INFO, WARN, ERROR, CRITICAL
        }

        static FConsole()
        {
            Init();
        }

        private static void Init()
        {
            EventBus.Register(new LogHandler());
            EventBus.Register(new GitHandler());
            EventBus.Register(new ReadHandler());
            EventBus.Register(new ColorHandler());
            EventBus.Register(new DebugHandler());
            EventBus.Register(new ClearHandler());

            FConsole.Log("FCONSOLE", "Initialization...", LogType.INFO); // PUT IT HERE BECAUSE IT CAN'T BE CALLED BEFORE IT'S NOT REGISTERED LOL
            Thread.Sleep(500); // AESTHETIC THING, STILL USELESS

            FConsole.Log("FCONSOLE_INIT_CORE", "Core Events Registered", LogType.SUCCESS);
            Thread.Sleep(500);

            ModulesManager.RegisterAll();
            FConsole.Log("FCONSOLE_INIT_MODS", "Additionnals Modules Registered", LogType.SUCCESS);
            Thread.Sleep(500);

            FConsole.Log("FCONSOLE", "Initialzation Completed !\n", LogType.SUCCESS);
            
            EventBus.Publish(new ColorEvent(ConsoleColor.White));
            EventBus.Publish(new ClearEvent());
        }

        public static void Log(string message)
            => EventBus.Publish(new LogEvent("SYS", message, LogType.DEFAULT));
        
        public static void Log(string senderName, string input, LogType logType = LogType.DEFAULT) 
            => EventBus.Publish(new LogEvent(senderName, input, logType));
        public static void Log(LogEvent evt) => EventBus.Publish(evt);

        public static string Read() => Console.ReadLine();

        public static void Debug(Delegate method, string methodName)
            => EventBus.Publish(new DebugEvent(method, methodName));
        public static void Debug(DebugEvent evt)
            => EventBus.Publish(evt);

        public static void SetForeGroundColor(ConsoleColor color) 
            => EventBus.Publish(new ColorEvent(color));
        public static void SetBackGroundColor(ConsoleColor color) 
            => EventBus.Publish(new ColorEvent(color, false));
    }
}
