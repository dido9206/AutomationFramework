using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UITests : BaseTest
    {
        [TestMethod]
        public void Base_UI_Elements_Inspection()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Wrong DashboardPage label.");

            PickThemesPage.GoTo();
            Assert.IsTrue(PickThemesPage.IsAt, "Wrong PickThemesPage label.");

            UploadDocsPage.GoTo();
            Assert.IsTrue(UploadDocsPage.IsAt, "Wrong UploadDocsPage label.");

            ReviewPage.GoTo();
            Assert.IsTrue(ReviewPage.IsAt, "Wrong ReviewPage label.");

            Navigation.Logout.Select();
            Assert.IsTrue(LoginPage.IsAt, "Wrong LoginScreen label.");

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Visual_Compare_HTML.xml", "input",
         DataAccessMethod.Sequential)]
        public void Visual_Compare_HTML()
        {
            string theme = TestContext.DataRow["theme"].ToString();
            string actual = TestContext.DataRow["actual"].ToString();
            string expected = TestContext.DataRow["expected"].ToString();
            string result = TestContext.DataRow["result"].ToString();
            string workingDir = TestContext.DataRow["workingDir"].ToString();
            string refPath = TestContext.DataRow["refPath"].ToString();

            ReviewPage.GoTo();
            ReviewPage.MakeReview(theme)
                .MakeScreenshot(actual, expected, result, workingDir, refPath);
        }
    }
}
