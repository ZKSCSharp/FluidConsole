using Fluid_ConsoleManager.src.Events.Interfaces;
using System.Diagnostics;
using System.Reflection;

namespace Fluid_ConsoleManager.src.Events
{
    public  class GitEvent : IEvent
    {
        private string filePath, command, repoPath;
        private bool log;
        private DateTime timeStamp;

        public GitEvent(string command, string repoPath, string[] args, bool log = false)
        {
            this.log = log;
            this.command = command;
            this.repoPath = repoPath;
            this.timeStamp = DateTime.UtcNow;
        }

        public void ExecuteGitCommand()
        {

        }

        public void GenerateGitLogFile()
        {
            if (!this.log && !string.IsNullOrEmpty(this.filePath))
            {
                this.log = !this.log;
                this.filePath = this.SetFilePath();
            }
        }

        private string SetFilePath() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public bool Loggable => this.log;
        public string FilePath => this.filePath;
        public string Command => this.command;
        public string RepositoryPath => this.repoPath;
        public DateTime TimeStamp => this.timeStamp;
    }
}
