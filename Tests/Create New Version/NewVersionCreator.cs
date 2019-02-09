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
            setUrl(TestContext.DataRow["pf_hostname"].ToString());
            setRefPath(TestContext.DataRow["pf_refPath"].ToString());
            setRegOutPath(TestContext.DataRow["pf_registrationOutputFile"].ToString());
            setRefOutPath(TestContext.DataRow["pf_referatsOutputFile"].ToString());

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\config.xml", "input",
         DataAccessMethod.Sequential)]
        public void User_Registration()
        {
            string fn = TestContext.DataRow["pf_fn"].ToString();
            string userName = TestContext.DataRow["pf_userName"].ToString();
            string password = TestContext.DataRow["pf_password"].ToString();
            string mail = TestContext.DataRow["pf_mail"].ToString();

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
            string userName = TestContext.DataRow["pf_userName"].ToString();
            string password = TestContext.DataRow["pf_password"].ToString();
            string theme = TestContext.DataRow["pf_theme"].ToString();
            string zipName = TestContext.DataRow["pf_zipName"].ToString();

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
