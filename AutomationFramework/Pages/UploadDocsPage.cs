using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AutomationFramework
{
    public class UploadDocsPage
    {
        private static int lastCount;

        public static void StoreCount()
        {
            lastCount = GetUploadsCount();
        }
        private static int GetUploadsCount()
        {
            var rowSize = Driver.Instance.FindElements(By.XPath("/html/body/div/div[1]/table/tbody/tr/td[1]")).Count();
            return rowSize;
        }
        public static int PreviousUploadsCount
        {
            get { return lastCount; }
        }

        public static int CurrentUploadsCount()
        {
            return GetUploadsCount();
        }
        public static bool IsAt
        {
            get
            {
                //Refactor: Can we create IsAt for all pages?
                var h3s = Driver.Instance.FindElements(By.TagName("h3"));
                if (h3s.Count > 0)
                    return h3s[0].Text == "Качи нова ревизия на проекта";
                return false;
            }
        }

        public static void GoTo()
        {
            //Refactor: Should we make a general menu navigation?
            Navigation.UploadDoc.Select();
        }

        public static string Theme
        {
            get
            {
                var h4s = Driver.Instance.FindElements(By.TagName("h4"));
                return h4s[0].Text;
            }
        }

        public static void ViewModeActivate(string comment)
        {
            var rowSize = Driver.Instance.FindElements(By.XPath("/html/body/div/div[1]/table/tbody/tr/td[1]")).Count();
            for (int i = 1; i <= rowSize; i++)
            {
                var cellText = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[2]")).Text;
                if (cellText == comment)
                {
                    var reviewButton = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[6]/a"));
                    reviewButton.Click();
                    Driver.Wait(TimeSpan.FromSeconds(2));
                    return;
                }
            }
            throw new System.Exception("Not in View mode");
        }

        public static void ViewModeExit()
        {
            var exitButton = Driver.Instance.FindElement(By.XPath("//div[contains(text(), 'Назад')]"));
            exitButton.Click();
        }

        public static bool CheckLastVersionAvailability()
        {
            var uploadDate = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[1]/td[1]")).Text;
            var title = UploadDocsPage.Theme;
            ReviewPage.GoTo();
            var uploadDateReview = ReviewPage.GetUploadDate(title.Remove(0, 17));
            return (uploadDate == uploadDateReview);
        }

        public static UploadCommand UploadDoc(string filePath)
        {
            return new UploadCommand(filePath);
        }
    }

    public class UploadCommand
    {
        private readonly string filePath;
        private string comment;


        public UploadCommand(string filePath)
        {
            this.filePath = Driver.ZipAddress + filePath;
        }

        public UploadCommand WithComment(string comment)
        {
            this.comment = comment;
            return this;
        }

        public void Upload(string outputFile)
        {
            UploadDocsPage.StoreCount();

            var fileChooser = Driver.Instance.FindElement(By.Id("userfile"));
            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(fileChooser).Click().Build().Perform();

            Driver.Wait(TimeSpan.FromSeconds(2));
            SendKeys.SendWait(@filePath);
            Driver.Wait(TimeSpan.FromSeconds(2));
            SendKeys.SendWait(@"{Enter}");

            var commentInput = Driver.Instance.FindElement(By.Id("comment"));
            commentInput.SendKeys(comment);

            var uploadButton = Driver.Instance.FindElement(By.LinkText("Качи"));
            uploadButton.Click();
            Driver.Wait(TimeSpan.FromSeconds(3));

            var expected = UploadDocsPage.PreviousUploadsCount + 1;
            var actual = UploadDocsPage.CurrentUploadsCount();
            if (expected != actual)
            {
                CSVWriter.Write(@outputFile, "failed," + filePath);
                throw new System.Exception("File is not correctly uploaded. Expected number of revisions: " + expected + ", Got: " + actual);
            }
            else
            {
                CSVWriter.Write(@outputFile, "success," + filePath);
            }

        }
    }
}
