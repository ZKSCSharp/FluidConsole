using Fluid_ConsoleManager.src.Events.Interfaces;

namespace Fluid_ConsoleManager.src.Events
{
    public class DebugEvent : IEvent
    {
        public Delegate Method { get; }
        public string MethodName { get; }
        public Exception? Error { get; set; }
        public object? Result { get; set; }

        public DebugEvent(Delegate method, string methodName)
        {
            MethodName = methodName;
            Method = method;
        }

        public Type GetMethodType() => Method.Method.ReturnType;
    }
}
