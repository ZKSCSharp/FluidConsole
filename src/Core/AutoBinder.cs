using Fluid_ConsoleManager.src;
using System.Reflection;

namespace Fluid_ConsoleManager.src.Core
{
    public class AutoBinder
    {
        public static void BindAllModules(string namespc)
        {
            /*
            Assembly assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes()
                .Where(t => t.IsClass && t.Name.Equals(namespc));

            foreach (var type in types)
            {
                FConsole.Log("BINDER", type.GetMethod("RegisterAll").Name);
            }
            */
        }
    }
}
