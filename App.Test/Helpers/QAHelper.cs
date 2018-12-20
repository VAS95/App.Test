using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace App.Test.Helpers
{
    public enum SelectorType
    {
        Id,
        Name,
        ClassName,
        XPath,
        CssSelector,
        LinkText
    }

    public enum CategoryTab
    {
        Main,
        Submition,
        Monitoring,
        Messages,
        VksResult,
        Register
    }

    class QAHelper : IDisposable
    {
        private readonly int maxTimeoutInSeconds;

        public QAHelper(int maxTimeoutInSeconds)
        {
            this.maxTimeoutInSeconds = maxTimeoutInSeconds;
        }

        public IWebElement FindElement(string element, SelectorType selector = SelectorType.XPath)
        {
            IWebElement currentElement = null;
            var wait = new WebDriverWait(SeleniumPropertiesCollection.Driver, TimeSpan.FromSeconds(maxTimeoutInSeconds));
            switch (selector)
            {
                case SelectorType.Id:
                    currentElement = wait.Until(drv => drv.FindElement(By.Id(element)));
                    break;
                case SelectorType.Name:
                    currentElement = wait.Until(drv => drv.FindElement(By.Name(element)));
                    break;
                case SelectorType.ClassName:
                    currentElement = wait.Until(drv => drv.FindElement(By.ClassName(element)));
                    break;
                case SelectorType.XPath:
                    currentElement = wait.Until(drv => drv.FindElement(By.XPath(element)));
                    break;
                case SelectorType.CssSelector:
                    currentElement = wait.Until(drv => drv.FindElement(By.CssSelector(element)));
                    break;
                case SelectorType.LinkText:
                    currentElement = wait.Until(drv => drv.FindElement(By.LinkText(element)));
                    break;
            }
            return currentElement;
        }

        public void SetValueForDropdown(string element, string value)
        {
            var selectElement = new SelectElement(FindElement(element));
            selectElement.SelectByText(value);
            //selectElement.SelectByValue(value);
        }


        private string GetCorrectXpathForDropdownElement(string element)
        {
            var newString = element.Substring(0, element.Length - 9);
            var result = $"{newString}ul/li/a";
            return result;
        }

        public void GoToCategory(CategoryTab categoryTab)
        {
            switch (categoryTab)
            {
                case CategoryTab.Main:
                    FindElement("/html/body/div[2]/div[1]/aside/ul/li[1]/a", SelectorType.XPath).JsClick();
                    break;
                case CategoryTab.Submition:
                    FindElement("/html/body/div[2]/div[1]/aside/ul/li[2]/a", SelectorType.XPath).JsClick();
                    break;
                case CategoryTab.Monitoring:
                    FindElement("/html/body/div[2]/div[1]/aside/ul/li[3]/a", SelectorType.XPath).JsClick();
                    break;
                case CategoryTab.Messages:
                    FindElement("/html/body/div[2]/div[1]/aside/ul/li[4]/a", SelectorType.XPath).JsClick();
                    break;
                case CategoryTab.VksResult:
                    FindElement("/html/body/div[2]/div[1]/aside/ul/li[5]/a", SelectorType.XPath).JsClick();
                    break;
                case CategoryTab.Register:
                    FindElement("/html/body/div[2]/div[1]/aside/ul/li[6]/a", SelectorType.XPath).JsClick();
                    break;
            }
        }

        public void Confirm(bool accept)
        {
            if (accept)
                SeleniumPropertiesCollection.Driver.SwitchTo().Alert().Accept();
            else
                SeleniumPropertiesCollection.Driver.SwitchTo().Alert().Dismiss();
        }

        public void Delay(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
