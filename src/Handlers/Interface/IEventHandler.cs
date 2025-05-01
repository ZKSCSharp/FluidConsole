using Fluid_ConsoleManager.src.Events.Interfaces;

namespace Fluid_ConsoleManager.src.Handlers.Interface
{
    public interface IEventHandler<T> where T : IEvent
    {
        void Handle(T evt);
    }
}
