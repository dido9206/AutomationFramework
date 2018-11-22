﻿using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ReviewTests : BaseTest
    {
        private TestContext testContext;
        public TestContext TestContext
        {

            get { return testContext; }
            set { testContext = value; }

        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        "|DataDirectory|\\Can_Make_Review.xml", "input",
         DataAccessMethod.Sequential)]
        public void Can_Make_Review()
        {
            string theme = TestContext.DataRow["theme"].ToString();
            string review = TestContext.DataRow["review"].ToString();
            string element_type = TestContext.DataRow["element_type"].ToString();
            string element_text = TestContext.DataRow["element_text"].ToString();

            ReviewPage.GoTo();
            Assert.IsTrue(ReviewPage.IsAt, "Wasn't at Review page");

            ReviewPage.MakeReview(theme).Review(review).ElementType(element_type).ElementText(element_text).Save();

            Assert.IsTrue(ReviewPage.IsAt, "Wasn't at Review page");

            ReviewPage.MakeReview(theme).Review(review).ElementType(element_type).ElementText(element_text).Check();

            ReviewPage.MakeReview(theme).ElementType(element_type).ElementText(element_text).Delete();

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
