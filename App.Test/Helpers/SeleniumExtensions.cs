using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
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

        public static void JsValue(this IWebElement element, string text)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)SeleniumPropertiesCollection.Driver;
            jsExec.ExecuteScript("$(arguments[0]).val(" + text + ")", element);
        }

        public static void SetValue(this IWebElement webElement, long val)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor) SeleniumPropertiesCollection.Driver;
            jsExec.ExecuteScript("$(arguments[0]).val(" + val + ");", webElement);
        }
        
        //not work
        public static void EnterValue(this IWebElement webElement, long val)
        {
            QAHelper hel = new QAHelper(15);
            string currentValue = "";
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)SeleniumPropertiesCollection.Driver;
            
            foreach (var ch in val.ToString())
            {
                
                currentValue = jsExec.ExecuteScript("$(arguments[0]).val();").ToString();
                Console.WriteLine("CURRENT VALUE STRING: " + currentValue);

                jsExec.ExecuteScript("$(arguments[0]).val(" + String.Concat(currentValue, ch.ToString()) + ");");
                hel.Delay(1);

                Console.WriteLine("CURRENT VALUE: " + currentValue);
                Console.WriteLine("CH: " + ch);
            }
        }

        public static void SetDate(this IWebElement element, DateTime date)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)SeleniumPropertiesCollection.Driver;
            jsExec.ExecuteScript("$(arguments[0]).val(new Date(\"" + date.ToString() + "\").toLocaleString(\"ua\", {year: 'numeric',month: 'numeric', day: 'numeric'}))", element);
        }
    }
}
