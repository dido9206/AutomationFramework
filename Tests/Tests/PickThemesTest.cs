using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PickThemesTest : BaseTest
    {
        [TestMethod]
        public void Can_Choose_A_Theme_By_Title()
        {
            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("33 - Framework7 - разработка на уеб приложения за Android и iOS").Pick();

            Assert.IsTrue(UploadDocsPage.IsAt, "Wasn't at Upload Doc page");
            Assert.AreEqual(UploadDocsPage.Theme, "Избраната тема е 33 - Framework7 - разработка на уеб приложения за Android и iOS", "Theme did not match the picked theme!");

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("44 - Resemble.js: Анализ и сравнение на изображения посреством JavaScript и HTML").Pick();
        }

        [TestMethod]
        public void Can_Choose_A_Theme_By_Number()
        {
            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("").PickByNumber("33");

            Assert.IsTrue(UploadDocsPage.IsAt, "Wasn't at Upload Doc page");
            Assert.AreEqual(UploadDocsPage.Theme, "Избраната тема е 33 - Framework7 - разработка на уеб приложения за Android и iOS", "Theme did not match the picked theme!");

            PickThemesPage.GoTo();
            PickThemesPage.PickTheme("").PickByNumber("44");
        }
    }
}
