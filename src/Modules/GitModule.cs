using Fluid_ConsoleManager.src.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid_ConsoleManager.src.Modules
{
    public class GitModule
    {
        public static void Register()
        {
            
        }
    }

    public class Git
    {
        public static void Commit(GitEvent evt)
        {
            evt.ExecuteGitCommand();
        }

        public static void Push(GitEvent evt)
        {

        }

        public static void Pull(GitEvent evt)
        {

        }

        public static void Clone(GitEvent evt)
        {

        }
    }
}
