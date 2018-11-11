using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ReviewTests : BaseTest
    {
        [TestMethod]
        public void Can_Make_Review()
        {
            ReviewPage.GoTo();
            Assert.IsTrue(ReviewPage.IsAt, "Wasn't at Review page");

            ReviewPage.MakeReview("69 - Прихващане на аудио и видео в HTML5").Review("Добре").ElementType("h2").ElementText("Въведение").Save();

            Assert.IsTrue(ReviewPage.IsAt, "Wasn't at Review page");

            ReviewPage.MakeReview("69 - Прихващане на аудио и видео в HTML5").Review("Добре").ElementType("h2").ElementText("Въведение").Check();

            ReviewPage.MakeReview("69 - Прихващане на аудио и видео в HTML5").ElementType("h2").ElementText("Въведение").Delete();

        }

        [TestMethod]
        public void Can_Make_Final_Review()
        {
            

        }

        [TestMethod]
        public void Can_Set_Score()
        {


        }
    }
}
