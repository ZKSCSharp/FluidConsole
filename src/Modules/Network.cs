using Fluid_ConsoleManager.src.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid_ConsoleManager.src.Modules
{

    public static class Network
    {
        public static void Register()
        {
            ConsoleEventHub.RegisterHandlersBatch(new Dictionary<string, ConsoleEventHandler<EventArgs>>()
            {
                { "ApiCall", ApiCall },
                { "TestNet", TestNet },
            });
        }

        internal static void ApiCall(EventArgs evt)
        {
            // Add Code
        }
        internal static void TestNet(EventArgs evt)
        {
            // Add Code
        }
    }
}
