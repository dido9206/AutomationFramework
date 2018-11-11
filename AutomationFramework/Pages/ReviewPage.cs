﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework
{
    public class ReviewPage
    {
        private static int lastCount;

        public static void StoreCount(string theme)
        {
            lastCount = GetReviewsCount(theme);
        }
        private static int GetReviewsCount(string theme)
        {
            var rowSize = Driver.Instance.FindElements(By.XPath("/html/body/div/div[1]/table/tbody/tr/td[1]")).Count();
            for (int i = 1; i <= rowSize; i++)
            {
                var cellText = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[1]")).Text;
                if (cellText == theme)
                {
                    var numReviews = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[5]"));
                    return int.Parse(numReviews.Text);
                }
            }
            throw new System.Exception("Theme "+ theme + " not found");

        }
        public static int PreviousReviewsCount
        {
            get { return lastCount; }
        }

        public static int CurrentReviewsCount(string theme)
        {
            return GetReviewsCount(theme);
        }

        public static bool IsAt
        {
            get
            {
                var c1 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/thead/tr/th[1]")).Text;
                var c2 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/thead/tr/th[2]")).Text;
                var c3 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/thead/tr/th[3]")).Text;
                var c4 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/thead/tr/th[4]")).Text;
                var c5 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/thead/tr/th[5]")).Text;
                var c6 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/thead/tr/th[6]")).Text;
                var c7 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/thead/tr/th[7]")).Text;
                var c8 = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/thead/tr/th[8]")).Text;

                return c1 == "Тема" && c2 == "Качено" && c3 == "Коментар" && c4 == "Рецензии" && c5 == "Корекции" 
                    && c6 == "Средна оценка" && c7 == "Рецензия" && c8 == "Преглед";
            }
        }

        public static void GoTo()
        {
            //Refactor: Should we make a general menu navigation?
            Driver.Wait(TimeSpan.FromSeconds(2));
            Navigation.MakeReview.Select();
        }

        public static void ReviewModeActivate(string title)
        {
            var rowSize = Driver.Instance.FindElements(By.XPath("/html/body/div/div[1]/table/tbody/tr/td[1]")).Count();
            for (int i = 1; i <= rowSize; i++)
            {
                var cellText = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[1]")).Text;
                if (cellText == title)
                {
                    var reviewButton = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[7]/a"));
                    reviewButton.Click();
                    Driver.Wait(TimeSpan.FromSeconds(2));
                    return;
                }
            }
            throw new System.Exception("Not in Review mode");
        }

        public static void ViewModeActivate(string title)
        {
            var rowSize = Driver.Instance.FindElements(By.XPath("/html/body/div/div[1]/table/tbody/tr/td[1]")).Count();
            for (int i = 1; i <= rowSize; i++)
            {
                var cellText = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[1]")).Text;
                if (cellText == title)
                {
                    var reviewButton = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[8]/a"));
                    reviewButton.Click();
                    Driver.Wait(TimeSpan.FromSeconds(2));
                    return;
                }
            }
            throw new System.Exception("Not in View mode");
        }

        public static void ReviewModeExit()
        {
            var exitButton = Driver.Instance.FindElement(By.XPath("//div[contains(text(), 'Назад')]"));
            exitButton.Click();
        }

        public static string GetUploadDate(string theme)
        {
            var rowSize = Driver.Instance.FindElements(By.XPath("/html/body/div/div[1]/table/tbody/tr/td[1]")).Count();
            for (int i = 1; i <= rowSize; i++)
            {
                var cellText = Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[1]")).Text;
                if (cellText == theme)
                {
                    return Driver.Instance.FindElement(By.XPath("/html/body/div/div[1]/table/tbody/tr[" + i + "]/td[2]")).Text;
                }
            }
            throw new System.Exception("No such theme");
        }

        public static ReviewCommand MakeReview(string theme)
        {
            return new ReviewCommand(theme);
        }
    }

    public class ReviewCommand
    {
        private readonly string theme;
        private string review;
        private string type;
        private string text;


        public ReviewCommand(string theme)
        {
            this.theme = theme;
        }

        public ReviewCommand Review(string review)
        {
            this.review = review;
            return this;
        }

        public ReviewCommand ElementType(string type)
        {
            this.type = type;
            return this;
        }

        public ReviewCommand ElementText(string text)
        {
            this.text = text;
            return this;
        }

        public void Save()
        {
            ReviewPage.StoreCount(theme);
            ReviewPage.ReviewModeActivate(theme);

            var elements = Driver.Instance.FindElements(By.TagName(type));
            for (int i = 0; i < elements.Count(); i++)
            {
                if (elements[i].Text == this.text)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(elements[i]).Click().Build().Perform();

                    var commentField = Driver.Instance.FindElement(By.Id("__ht__elementcomment"));
                    action.MoveToElement(commentField).Click();
                    commentField.SendKeys(review);

                    
                    var saveButton = Driver.Instance.FindElement(By.LinkText("Запази"));
                    saveButton.Click();
                    Driver.Wait(TimeSpan.FromSeconds(2));
                    break;
                }
            }

            ReviewPage.ReviewModeExit();
            if (ReviewPage.PreviousReviewsCount + 1 != ReviewPage.CurrentReviewsCount(theme))
            {
                throw new System.Exception("Count of reviews did not increase");
            }
        }

        public void Check()
        {
            ReviewPage.ViewModeActivate(theme);

            var elements = Driver.Instance.FindElements(By.TagName(type));
            for (int i = 0; i < elements.Count(); i++)
            {
                if (elements[i].Text == this.text)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(elements[i]).Click().Build().Perform();

                    var commentFieldText = Driver.Instance.FindElement(By.XPath("/html/body/div[5]/div[2]/div")).Text;
                    if (commentFieldText != this.review)
                    {
                        ReviewPage.ReviewModeExit();
                        throw new System.Exception("The review is not correct or not saved. Expected: " + this.review + ", Got: " + commentFieldText);
                    }
                    ReviewPage.ReviewModeExit();
                    return;
                }
            }
            ReviewPage.ReviewModeExit();
            throw new System.Exception("The element, containing the comment, cannot be found");
        }

        public void Delete()
        {
            ReviewPage.StoreCount(theme);
            ReviewPage.ReviewModeActivate(theme);

            var elements = Driver.Instance.FindElements(By.TagName(type));
            for (int i = 0; i < elements.Count(); i++)
            {
                if (elements[i].Text == this.text)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(elements[i]).Click().Build().Perform();

                    var deleteButton = Driver.Instance.FindElement(By.LinkText("Изтрий"));
                    deleteButton.Click();
                    Driver.Wait(TimeSpan.FromSeconds(2));
                    break;
                }
            }

            ReviewPage.ReviewModeExit();
            if (ReviewPage.PreviousReviewsCount-1 != ReviewPage.CurrentReviewsCount(theme))
            {
                throw new System.Exception("Unable to delete review. Previous: " + ReviewPage.PreviousReviewsCount + ", Current:" + ReviewPage.CurrentReviewsCount(theme));
            }
        }
    }
}