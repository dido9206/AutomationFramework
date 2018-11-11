using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LoginTests : BaseTest
    {
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login.");
        }

        [TestMethod]
        public void Admin_User_Can_Logout()
        {
            Navigation.Logout.Select();
            Assert.IsTrue(LoginPage.IsAt, "Failed to logout.");
        }
    }
}
