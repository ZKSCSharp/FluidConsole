using Fluid_ConsoleManager.src;
using Fluid_ConsoleManager.src.Events;

namespace Fluid_ConsoleManager.src.Core
{
    public delegate void ConsoleEventHandler<in T>(T evt) where T : EventArgs;

    public interface IConsoleEventHandler<TEvent> where TEvent : EventArgs
    {
        void Handle(TEvent T);
    }

    public class ConsoleEventHub
    {
        public static Dictionary<Type, Dictionary<string, Delegate>> Registry = new();
        public static Dictionary<string, Func<string>> Functions = new();

        public static void RegisterHandlers<T>(string id, ConsoleEventHandler<T> handler) where T : EventArgs
        {
            if (!Registry.ContainsKey(typeof(T)))
                Registry[typeof(T)] = new();

            Registry[typeof(T)].Add(id, handler);
        }

        public static void RegisterFunc(string name, Func<string> method) => Functions[name] = method;

        public static void RegisterHandlersBatch<T>(Dictionary<string, ConsoleEventHandler<T>> handlers) where T : EventArgs
        {
            if (!Registry.ContainsKey(typeof (T)))
                Registry[typeof (T)] = new();

            foreach (var kvp in handlers)
            { Registry[typeof(T)][kvp.Key] = kvp.Value; }

        }

        public static void RegisterFuncsBatch(Dictionary<string, Func<string>> funcs)
        {
            foreach (var kvp in funcs)
            {
                Functions[kvp.Key] = kvp.Value;
            }
        }

        public static void Invoke<T>(T evt, string id) where T : EventArgs
        {
            if (Registry.TryGetValue(typeof(T), out var handler))
            {
                if (handler.TryGetValue(id, out var func))
                { ((ConsoleEventHandler<T>)func)?.Invoke(evt); }
                else
                {
                    LogEvent logevt = new LogEvent("HUB_INVOKE", $"No Method Registered on this name: {id}", FConsole.LogType.ERROR);
                    logevt.Log();
                }
            }
        }

        public static string InvokeFunc(string name)
        {
            if (Functions.TryGetValue(name, out var method))
                return method();
            return $"No Method Named {name} Found";
        }

        public static void InvokeBatchs<T>(T evt) where T : EventArgs
        {
            
            if (Registry.TryGetValue(typeof(T), out var handlers))
            {
                foreach (var kvp in handlers)
                { ((ConsoleEventHandler<T>)kvp.Value)?.Invoke(evt); }
            }
        }

        public static List<string> InvokeFuncsBatchs(string filter = "")
        {
            List<string> args = new();

            foreach (var kvp in Functions)
            {
                if (string.IsNullOrEmpty(filter) || kvp.Key == filter)
                    args.Add(kvp.Key);
            }

            return args;
        }
    }
}
