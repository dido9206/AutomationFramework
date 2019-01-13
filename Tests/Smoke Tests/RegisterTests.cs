using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RegisterTests : BaseTest
    {
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\User_Can_Register.xml", "input",
         DataAccessMethod.Sequential)]
        public void User_Can_Register()
        {
            string fn = TestContext.DataRow["fn"].ToString();
            string userName = TestContext.DataRow["userName"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string mail = TestContext.DataRow["mail"].ToString();

            Navigation.Logout.Select();
            RegisterPage.GoTo();
            Assert.IsTrue(RegisterPage.IsAt, "Not at Register page.");
            RegisterPage.RegisterAs(fn).WithUserName(userName).WithPassword(password)
                .WithMail(mail).Register("c:\\Temp\\MyTest2.csv");
            LoginPage.LoginAs(userName).WithPassword(password).Login();
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login with user. " + userName);
        }
    }
}
