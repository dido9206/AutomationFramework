using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework
{
    public class ShellExecuter
    {
        public static void ShellCommandExecute(string command, string workingDir)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = @workingDir;
            process.StartInfo.Arguments = "/c " + command;
            process.Start();
        }
    }
}
