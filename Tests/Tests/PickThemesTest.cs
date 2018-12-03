using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PickThemesTest : BaseTest
    {
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Can_Choose_A_Theme_By_Title.xml", "input",
         DataAccessMethod.Sequential)]
        public void Can_Choose_A_Theme_By_Title()
        {
            string theme = TestContext.DataRow["theme"].ToString();
           
            PickThemesPage.GoTo();
            PickThemesPage.PickTheme(theme).Pick();

            Assert.IsTrue(UploadDocsPage.IsAt, "Wasn't at Upload Doc page");
            Assert.AreEqual(UploadDocsPage.Theme, "Избраната тема е "+ theme, "Theme did not match the picked theme!");

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("").PickByNumber("44"); 
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Can_Choose_A_Theme_By_Number.xml", "input",
         DataAccessMethod.Sequential)]
        public void Can_Choose_A_Theme_By_Number()
        {
            string theme_number = TestContext.DataRow["theme_number"].ToString();
            string theme = TestContext.DataRow["theme"].ToString();

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("").PickByNumber(theme_number);

            Assert.IsTrue(UploadDocsPage.IsAt, "Wasn't at Upload Doc page");
            Assert.AreEqual(UploadDocsPage.Theme, "Избраната тема е "+theme, "Theme did not match the picked theme!");

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("").PickByNumber("44");
        }
    }
}
