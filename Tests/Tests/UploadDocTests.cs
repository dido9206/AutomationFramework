using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UploadDocTests : BaseTest
    {
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Can_Upload_A_Document.xml", "input",
         DataAccessMethod.Sequential)]
        public void Can_Upload_A_Document()
        {
            string theme = TestContext.DataRow["theme"].ToString();
            string doc_path = TestContext.DataRow["doc_path"].ToString();
            string comment = TestContext.DataRow["comment"].ToString();

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme(theme).Pick();

            UploadDocsPage.UploadDoc(doc_path).WithComment(comment).Upload();

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("").PickByNumber("44");
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Can_Show_Uploaded_Document.xml", "input",
         DataAccessMethod.Sequential)]
        public void Can_Show_Uploaded_Document()
        {
            string theme = TestContext.DataRow["theme"].ToString();
            string comment = TestContext.DataRow["comment"].ToString();

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme(theme).Pick();

            UploadDocsPage.ViewModeActivate(comment);
            UploadDocsPage.ViewModeExit();

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("").PickByNumber("44");
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Uploaded_Document_Available_In_Review_Page.xml", "input",
         DataAccessMethod.Sequential)]
        public void Uploaded_Document_Available_In_Review_Page()
        {
            string theme = TestContext.DataRow["theme"].ToString();

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme(theme).Pick();

            Assert.IsTrue(UploadDocsPage.CheckLastVersionAvailability(), "The last version of your theme is not available in the Reviews Page.");

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("").PickByNumber("44");
        }
    }
}
