using Fluid_ConsoleManager.src;
using Fluid_ConsoleManager.src.Core;

namespace Fluid_ConsoleManager.src.Events
{
    public class DynamicEventHandler<T> : IConsoleEventHandler<EventArgs>
    {
        public Delegate Method { get; private set; }

        public DynamicEventHandler(Delegate handleMethod)
        {
            Method = handleMethod;
        }

        public void Handle(EventArgs evt)
        {
            if (Method is T typed)
                try
                {
                    Method.DynamicInvoke(this, evt);
                }
                catch (Exception e)
                {
                    FConsole.Log("CUSTOM_HANDLER", e.Message, FConsole.LogType.ERROR);
                }
        }
    }
}
