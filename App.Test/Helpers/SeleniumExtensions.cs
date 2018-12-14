using System.Threading;
using OpenQA.Selenium;

namespace App.Test.Helpers
{
    public static class SeleniumExtensions
    {
        public static void EnterText(this IWebElement webElement, string value, int? delay = null)
        {
            if (delay.HasValue)
            {
                foreach (var ch in value)
                {
                    webElement.SendKeys(ch.ToString());
                    Thread.Sleep(delay.Value);
                }
            }
            else webElement.SendKeys(value);
        }

        public static string GetText(this IWebElement webElement)
        {
            return webElement.Text ?? webElement.GetAttribute("value");
        }

        public static void JsClick(this IWebElement element)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)SeleniumPropertiesCollection.Driver;
            jsExec.ExecuteScript("arguments[0].click();", element);
        }
    }
}
