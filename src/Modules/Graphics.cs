using Fluid_ConsoleManager.src.Core;

namespace Fluid_ConsoleManager.src.Modules
{
    public static class Graphics
    {

        public static void Register()
        {
            ConsoleEventHub.RegisterHandlersBatch(new Dictionary<string, ConsoleEventHandler<EventArgs>>()
            {
                { "Test", TestModule },
                { "ProgressBar", DrawnProgressBar },
            });
        }

        internal static void DrawnProgressBar(EventArgs evt)
        {
            // Add Code
        }
        internal static void TestModule(EventArgs evt)
        {
            // Add Code
        }
    }
}
