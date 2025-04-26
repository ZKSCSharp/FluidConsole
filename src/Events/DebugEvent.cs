namespace Fluid_ConsoleManager.src.Events
{
    public class DebugEvent : EventArgs
    {
        public Delegate Method { get; }
        public string MethodName { get; }
        public Exception? Error { get; private set; }
        public object? Result { get; private set; }

        public DebugEvent(Delegate method, string methodName)
        {
            MethodName = methodName;
            Method = method;
        }

        public bool Execute()
        {
            try
            {
                Result = Method.DynamicInvoke();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        public Type GetMethodType() => Method.Method.ReturnType;
    }
}
