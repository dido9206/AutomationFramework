using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework
{
    public class LoginPage
    {
        public static bool IsAt
        {
            get
            {
                //Refactor: Can we create IsAt for all pages?
                var h3s = Driver.Instance.FindElements(By.TagName("h3"));
                if (h3s.Count > 0)
                    return h3s[0].Text == "Влезте в своя профил";
                return false;
            }
        }
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "index.php");
            Driver.Wait(TimeSpan.FromSeconds(2));
            //var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            //wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("name") == "name");
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }

    public class LoginCommand
    {
        private readonly string userName;
        private string password;

        public LoginCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string password)
        {   
            this.password = password;
            return this; 
        }

        public void Login()
        {
            var loginInput = Driver.Instance.FindElement(By.Name("name"));
            loginInput.SendKeys(userName);

            var passwordInput = Driver.Instance.FindElement(By.Name("pass"));
            passwordInput.SendKeys(password);

            var loginButton = Driver.Instance.FindElement(By.LinkText("Вход"));
            loginButton.Click();
        }

    }
}
