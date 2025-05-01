using Fluid_ConsoleManager.src.Events;
using Fluid_ConsoleManager.src.Handlers.Interface;

namespace Fluid_ConsoleManager.src.Handlers
{
    public class ClearHandler : IEventHandler<ClearEvent>
    {
        public void Handle(ClearEvent evt)
        {
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
