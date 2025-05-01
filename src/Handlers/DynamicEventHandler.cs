using Fluid_ConsoleManager.src.Events.Interfaces;
using Fluid_ConsoleManager.src.Handlers.Interface;

namespace Fluid_ConsoleManager.src.Handlers
{
    public class DynamicEventHandler<T> : IEventHandler<IEvent>
    {
        public Delegate Method { get; private set; }

        public DynamicEventHandler(Delegate handleMethod)
        {
            Method = handleMethod;
        }

        public void Handle(IEvent evt)
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
