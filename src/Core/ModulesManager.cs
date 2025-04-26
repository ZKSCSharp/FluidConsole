using Fluid_ConsoleManager.src.Modules;

namespace Fluid_ConsoleManager.src.Core
{
    public class ModulesManager
    {
        public static void RegisterAll()
        {
            Graphics.Register();
            Network.Register();
        }
    }
}
