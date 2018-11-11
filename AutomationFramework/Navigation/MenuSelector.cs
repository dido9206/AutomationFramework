using OpenQA.Selenium;

namespace AutomationFramework
{
    public class MenuSelector
    {
        public static void Select(string menuLinkText)
        {
            Driver.Instance.FindElement(By.PartialLinkText(menuLinkText)).Click();
        }
    }
}
