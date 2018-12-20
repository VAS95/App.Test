using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Test.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace App.Test.QATests
{
    class QATestBase
    {
        private readonly string browser = ConfigurationManager.AppSettings["Browser"];
        private readonly string signInUrl = ConfigurationManager.AppSettings["SignInUrl"];
        private readonly string CSKType = ConfigurationManager.AppSettings["CSKType"];
        private readonly string ECPPath = ConfigurationManager.AppSettings["ECPPath"];
        private readonly string Password = ConfigurationManager.AppSettings["Password"];

        public QAHelper Helper { get; set; }
        public string Url { get; set; } = ConfigurationManager.AppSettings["DicomUrl"];


        [SetUp]
        public void Initialize()
        {
            if (browser == "Chrome") SeleniumPropertiesCollection.Driver = new ChromeDriver();
            else if (browser == "Firefox") SeleniumPropertiesCollection.Driver = new FirefoxDriver();
            SeleniumPropertiesCollection.Driver.Manage().Window.Maximize();
            SeleniumPropertiesCollection.Driver.Manage().Cookies.DeleteAllCookies();
            Helper = new QAHelper(15);

            SeleniumPropertiesCollection.Driver.Navigate().GoToUrl(signInUrl);
            Console.WriteLine($"Opened URL - \"{signInUrl}\"");
        }

        protected void Login()
        {
            Console.WriteLine("Logining...");
            Console.WriteLine("Press SingIn bitton on Home/Info page");
            Helper.FindElement("//*[@class=\"content__button\"]").JsClick();
            Helper.Delay(2);

            Console.WriteLine("Press file storage button on id.gov.ua");
            Helper.FindElement("/html/body/div/main/div/div/div[1]/div[1]/a").JsClick();
            Helper.Delay(20);

            Console.WriteLine("Set ACSK Type");
            Helper.SetValueForDropdown("//*[@id=\"CAsServersSelect\"]", "АЦСК ТОВ \"Центр сертифікації ключів \"Україна\"");
            Helper.FindElement("//*[@id=\"PKeyFileInput\"]").JsClick();
            Helper.Delay(5);
            Console.WriteLine("Uploading ECP file");
            SendKeys.SendWait(ECPPath);
            SendKeys.SendWait(@"{Enter}");
   
            Console.WriteLine("Enter password");
            Helper.FindElement("//*[@id=\"PKeyPassword\"]").SendKeys(Password);
            Helper.FindElement("/html/body/div[1]/main/div/form/fieldset/div[3]/div/div[2]/div/button").JsClick();

            Helper.Delay(5);
            Console.WriteLine("Press sign in button on id.gov.ua");
            Helper.FindElement("/html/body/div/div[1]/div[2]/div[2]/div[2]/a").JsClick();

            Helper.Delay(5);
            Console.WriteLine("Logged in");
        }

        [TearDown]
        public void CleanUp()
        {
            SeleniumPropertiesCollection.Driver.Close();
            Helper.Dispose();
            Console.WriteLine("Closed browser");
        }
    }
}
