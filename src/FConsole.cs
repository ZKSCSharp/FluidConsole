using Fluid_ConsoleManager.src.Core;
using Fluid_ConsoleManager.src.Events;
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
            ConsoleEventHub.RegisterHandlersBatch(new Dictionary<string, ConsoleEventHandler<LogEvent>>()
            {
                {"Print", Log }
            });

            ConsoleEventHub.RegisterHandlersBatch(new Dictionary<string, ConsoleEventHandler<DebugEvent>>()
            {
                {"Debug", Debug }
            });

            ConsoleEventHub.RegisterFuncsBatch(new Dictionary<string, Func<string>>()
            {
                {"Read", ReadEvent.Prompt},
            });

            ConsoleEventHub.RegisterHandlersBatch(new Dictionary<string, ConsoleEventHandler<ColorEvent>>()
            {
                { "ForeColor",  SetForeGroundColor },
                { "BackColor", SetBackGroundColor },
            });

            Log("FCONSOLE", "Initialization...", LogType.INFO); // PUT IT HERE BECAUSE IT CAN'T BE CALLED BEFORE IT'S NOT REGISTERED LOL

            Log("FCONSOLE_INIT_CORE", "Core Events Registered", LogType.SUCCESS);

            ModulesManager.RegisterAll();
            Log("FCONSOLE_INIT_MODS", "Additionnals Modules Registered", LogType.SUCCESS);

            Log("FCONSOLE", "Initialzation Completed !\n", LogType.SUCCESS);

            ConsoleEventHub.Invoke(new ColorEvent(ConsoleColor.White), "ForeColor");
        }

        public static void Log(string message)
            => ConsoleEventHub.Invoke(new LogEvent("SYS", message, LogType.DEFAULT), "Print");
        public static void Log(string senderName, string input, LogType logType = LogType.DEFAULT) 
            => ConsoleEventHub.Invoke(new LogEvent(senderName, input, logType), "Print");
        public static void Log(LogEvent evt) => evt.Log();

        public static string Read() => ConsoleEventHub.InvokeFunc("Read");

        public static void Debug(Delegate method, string methodName)
            => ConsoleEventHub.Invoke(new DebugEvent(method, methodName), "Debug");
        public static void Debug(DebugEvent evt)
        {
            switch (evt.Method)
            {
                case Func<int> f:
                    if (evt.Execute()) Log(new LogEvent(evt.MethodName, evt.Result.ToString(), LogType.SUCCESS));
                    else
                        Log(new LogEvent(evt.MethodName, "Error, Can't Execute Method", LogType.ERROR));
                    break;
                case Action a:
                    a();
                    break;
                default:
                    Log(new LogEvent(evt.MethodName, "Type not supported for now", LogType.ERROR));
                    break;
            }
            if (evt.Result == null && evt.Method == null)
                Log(new LogEvent("SYS", "Unknow Failure", LogType.CRITICAL));
        }

        public static void SetForeGroundColor(ConsoleColor color) 
            => ConsoleEventHub.Invoke(new ColorEvent(color), "ForeColor");
        public static void SetForeGroundColor(ColorEvent evt) 
            => evt.SetForeGround();
        public static void SetBackGroundColor(ConsoleColor color) 
            => ConsoleEventHub.Invoke(new ColorEvent(color), "BackColor");
        public static void SetBackGroundColor(ColorEvent evt)
            => evt.SetBackGround();
    }
}
