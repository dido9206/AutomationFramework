using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework
{
    public class PickThemesPage
    {
        public static bool IsAt
        {
            get
            {
                //Refactor: Can we create IsAt for all pages?
                var h3s = Driver.Instance.FindElements(By.TagName("h3"));
                if (h3s.Count > 0)
                    return h3s[0].Text == "Избери тема за реферат";
                return false;
            }
        }

        public static string Theme
        {
            get
            {
                var h4s = Driver.Instance.FindElements(By.TagName("h4"));
                return h4s[0].Text;
            }
        }

        public static void GoTo()
        {
            //Refactor: Should we make a general menu navigation?
            Driver.Wait(TimeSpan.FromSeconds(2));
            Navigation.ChooseDoc.Select();
        }

        public static PickThemeCommand PickTheme(string title)
        {
            return new PickThemeCommand(title);
        }

        public class PickThemeCommand
        {
            private readonly string title;

            public PickThemeCommand(string title)
            {
                this.title = title;
            }

            public void Pick()
            {

                SelectElement dropdown = new SelectElement(Driver.Instance.FindElement(By.Name("project_theme_select")));
                dropdown.SelectByText(title);

                Driver.Instance.FindElement(By.LinkText("Избор")).Click();
                Driver.Wait(TimeSpan.FromSeconds(2));
            }

            public void PickByNumber(string themeNumber)
            {

                var numberInput = Driver.Instance.FindElement(By.Name("project_theme"));
                numberInput.SendKeys(themeNumber);

                Driver.Instance.FindElement(By.LinkText("Избор")).Click();
                Driver.Wait(TimeSpan.FromSeconds(2));
            }
        }
    }
}
