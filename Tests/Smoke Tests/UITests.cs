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
    }
}
