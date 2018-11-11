using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UploadDocTests : BaseTest
    {
        [TestMethod]
        public void Can_Upload_A_Document()
        {
            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("33 - Framework7 - разработка на уеб приложения за Android и iOS").Pick();

            UploadDocsPage.UploadDoc("C:\\Temp\\referat.zip").WithComment("Тест").Upload();

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("44 - Resemble.js: Анализ и сравнение на изображения посреством JavaScript и HTML").Pick();
        }

        [TestMethod]
        public void Can_Show_Uploaded_Document()
        {
            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("33 - Framework7 - разработка на уеб приложения за Android и iOS").Pick();

            UploadDocsPage.ViewModeActivate("Тест");
            UploadDocsPage.ViewModeExit();

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("44 - Resemble.js: Анализ и сравнение на изображения посреством JavaScript и HTML").Pick();
        }

        [TestMethod]
        public void Uploaded_Document_Available_In_Review_Page()
        {
            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("33 - Framework7 - разработка на уеб приложения за Android и iOS").Pick();

            Assert.IsTrue(UploadDocsPage.CheckLastVersionAvailability(), "The last version of your theme is not available in the Reviews Page.");

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("44 - Resemble.js: Анализ и сравнение на изображения посреством JavaScript и HTML").Pick();
        }
    }
}
