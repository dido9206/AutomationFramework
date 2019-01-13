using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NewVersionCreator : SanityTest
    {
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\config.xml", "setup",
         DataAccessMethod.Sequential)]
        public void Setup()
        {
            setUrl(TestContext.DataRow["hostname"].ToString());
            setRefPath(TestContext.DataRow["refPath"].ToString());
            setRegOutPath(TestContext.DataRow["registrationOutputFile"].ToString());
            setRefOutPath(TestContext.DataRow["referatsOutputFile"].ToString());

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\config.xml", "input",
         DataAccessMethod.Sequential)]
        public void User_Registration()
        {
            string fn = TestContext.DataRow["fn"].ToString();
            string userName = TestContext.DataRow["userName"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string mail = TestContext.DataRow["mail"].ToString();

            LoginPage.GoTo(getUrl);
            RegisterPage.GoTo();
            Assert.IsTrue(RegisterPage.IsAt, "Not at Register page.");
            RegisterPage.RegisterAs(fn).WithUserName(userName).WithPassword(password)
                .WithMail(mail).Register(getRegOutPath);
            LoginPage.LoginAs(userName).WithPassword(password).Login();
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login with user. " + userName);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\config.xml", "input",
         DataAccessMethod.Sequential)]
        public void Referats_Upload()
        {
            string userName = TestContext.DataRow["userName"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string theme = TestContext.DataRow["theme"].ToString();
            string zipName = TestContext.DataRow["zipName"].ToString();

            LoginPage.GoTo(getUrl);
            LoginPage.LoginAs(userName).WithPassword(password).Login();
            PickThemesPage.GoTo();
            PickThemesPage.PickTheme(theme).Pick();

            Assert.IsTrue(UploadDocsPage.IsAt, "Wasn't at Upload Doc page");
            Assert.AreEqual(UploadDocsPage.Theme, "Избраната тема е " + theme, "Theme did not match the picked theme!");

            UploadDocsPage.UploadDoc(zipName).WithComment("").Upload(getRefOutPath);
        }
    }
}
