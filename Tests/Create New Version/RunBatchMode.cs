using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RunbatchMode : BaseTest
    {
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Runbatch.xml", "input",
         DataAccessMethod.Sequential)]
        public void Runbatch()
        {
            string workingDir = TestContext.DataRow["workingDir"].ToString();
            string command = TestContext.DataRow["command"].ToString();

            ShellExecuter.ShellCommandExecute(command, workingDir);
        }
    }
}
