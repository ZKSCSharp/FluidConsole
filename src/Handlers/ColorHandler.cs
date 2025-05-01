using Fluid_ConsoleManager.src.Events;
using Fluid_ConsoleManager.src.Handlers.Interface;

namespace Fluid_ConsoleManager.src.Handlers
{
    public class ColorHandler : IEventHandler<ColorEvent>
    {
        public void Handle(ColorEvent evt)
        {
            if (evt.ForeOrBack)
                this.SetForeGround(evt);
            else
                this.SetBackGround(evt);
        }

        private void SetForeGround(ColorEvent evt) => Console.ForegroundColor = evt.EvtColor;
        private void SetBackGround(ColorEvent evt) => Console.BackgroundColor = evt.EvtColor;
    }
}
