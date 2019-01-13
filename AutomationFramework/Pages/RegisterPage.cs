using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework
{
    public class RegisterPage
    {
        public static bool IsAt
        {
            get
            {
                //Refactor: Can we create IsAt for all pages?
                var h3s = Driver.Instance.FindElements(By.TagName("h3"));
                if (h3s.Count > 0)
                    return h3s[0].Text == "Регистрация";
                return false;
            }
        }
        public static void GoTo()
        {
            var registerButton = Driver.Instance.FindElement(By.LinkText("Регистрация"));
            registerButton.Click();
        }

        public static RegisterCommand RegisterAs(string fn)
        {
            return new RegisterCommand(fn);
        }
    }

   
    public class RegisterCommand
    {
        private readonly string fn;
        private string userName;
        private string password;
        private string mail;

        public RegisterCommand(string fn)
        {
            this.fn = fn;
        }

        public RegisterCommand WithUserName(string userName)
        {
            this.userName = userName;
            return this;
        }

        public RegisterCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public RegisterCommand WithMail(string mail)
        {
            this.mail = mail;
            return this;
        }

        public void Register(string outputFile)
        {
            var fnInput = Driver.Instance.FindElement(By.Name("fn"));
            fnInput.SendKeys(fn);

            var userInput = Driver.Instance.FindElement(By.Name("name"));
            userInput.SendKeys(userName);

            var passwordInput = Driver.Instance.FindElement(By.Name("pass"));
            passwordInput.SendKeys(password);

            var mailInput = Driver.Instance.FindElement(By.Name("mail"));
            mailInput.SendKeys(mail);

            var regButton = Driver.Instance.FindElement(By.LinkText("Регистрация"));
            regButton.Click();

            Driver.Wait(TimeSpan.FromSeconds(2));

            if (!LoginPage.IsAt)
            {
                CSVWriter.Write(@outputFile,"failed,"+fn+','+userName+','+password+','+mail);
            }
            else
            {
                CSVWriter.Write(@outputFile, "success," + fn + ',' + userName + ',' + password + ',' + mail);
            }
        }

    }
}
