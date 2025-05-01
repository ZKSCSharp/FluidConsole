using Fluid_ConsoleManager.src.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
