using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public class BaseTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();

            LoginPage.GoTo();
            LoginPage.LoginAs("9999").WithPassword("9999").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //Driver.Close();
        }
    }
}
