using Fluid_ConsoleManager.src.Events;
using Fluid_ConsoleManager.src.Handlers.Interface;
using static Fluid_ConsoleManager.src.FConsole;

namespace Fluid_ConsoleManager.src.Handlers
{
    public class DebugHandler : IEventHandler<DebugEvent>
    {
        public void Handle(DebugEvent evt)
        {

            switch (evt.Method)
            {
                case Func<int> f:
                    if (this.Execute(evt))
                        FConsole.Log(new LogEvent(evt.MethodName, evt.Result.ToString(), LogType.SUCCESS));
                    else
                        FConsole.Log(new LogEvent(evt.MethodName, "Error, Can't Execute Method", LogType.ERROR));
                    break;

                case Func<string> s:
                    if (this.Execute(evt))
                        FConsole.Log(new LogEvent(evt.MethodName, evt.Result.ToString(), LogType.SUCCESS));
                    else
                        FConsole.Log(new LogEvent(evt.MethodName, "Error, Can't Execute Method", LogType.ERROR));
                    break;

                case Action a:
                    a();
                    break;

                default:
                    FConsole.Log(new LogEvent(evt.MethodName, "Type not supported for now", LogType.ERROR));
                    break;
            }
            if (evt.Result == null && evt.Method == null)
                FConsole.Log(new LogEvent("SYS", "Unknow Failure", LogType.CRITICAL));
        }

        private bool Execute(DebugEvent evt)
        {
            try
            {
                evt.Result = evt.Method.DynamicInvoke();
                return true;
            }
            catch (Exception ex)
            {
                evt.Error = ex;
                return false;
            }
        }
    }
}
