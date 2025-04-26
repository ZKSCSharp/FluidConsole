namespace Fluid_ConsoleManager.src.Events
{
    public class ColorEvent : EventArgs
    {
        public ConsoleColor EvtColor { get; set; }
        public ColorEvent(ConsoleColor color) => EvtColor = color;

        public void SetForeGround() => Console.ForegroundColor = EvtColor;
        public void SetBackGround() => Console.BackgroundColor = EvtColor;
    }

}
