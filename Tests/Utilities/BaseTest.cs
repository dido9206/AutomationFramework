using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public class BaseTest
    {
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }

        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();

            LoginPage.GoTo();
            LoginPage.LoginAs("9999").WithPassword("1").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
           Driver.Close();
        }
    }
}
