using Fluid_ConsoleManager.src.Events.Interfaces;

namespace Fluid_ConsoleManager.src.Events
{
    public class ColorEvent : IEvent
    {
        public ConsoleColor EvtColor { get; set; }
        public bool ForeOrBack { get; }
        public ColorEvent(ConsoleColor color, bool fore = true)
        { 
            EvtColor = color; 
            ForeOrBack = fore;
        }
    }

}
