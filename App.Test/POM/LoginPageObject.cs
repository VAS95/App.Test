using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Test.Helpers;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;



namespace App.Test.POM
{
    public class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(SeleniumPropertiesCollection.Driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//*[@class=\"content__button\"]")]
        public IWebElement BtnLoginPortal { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='divLinkButton1']/a/table/tbody/tr/td[2]/span")]
        public IWebElement BtnECPIdGovUa { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"CAsServersSelect\"]")]
        public IWebElement ACSKTypeDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PKeySelectFileButton\"]")]
        public IWebElement ECPFile { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PKeyPassword\"]")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PKeyReadButton\"]")]
        public IWebElement BtnSend { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div[2]/div[2]/div[2]/a")]
        public IWebElement BtnSubmit { get; set; }


        public ModdiMainPageObject Login(string acskType, string ecpFile, string password)
        {
            QAHelper Helper = new QAHelper(15);
            BtnLoginPortal.JsClick();
            Helper.Delay(2);
            BtnECPIdGovUa.JsClick();
            Helper.Delay(5);

            Helper.SetValueForDropdown(ACSKTypeDropdown.ToString(), acskType);

            ECPFile.JsClick();
            Helper.Delay(5);
            SendKeys.SendWait(ecpFile);
            SendKeys.SendWait(@"{Enter}");

            Password.SendKeys(password);

            BtnSend.JsClick();
            Helper.Delay(5);

            BtnSubmit.JsClick();

            return new ModdiMainPageObject();
        }
    }
}
