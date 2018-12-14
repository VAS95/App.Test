using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Test.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

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
            Helper.FindElement("//*[@class=\"content__button\"]").JsClick();

            Helper.Delay(5);
            Helper.FindElement("//*[@id='divLinkButton1']/a/table/tbody/tr/td[2]/span").JsClick();

            Helper.Delay(5);
            Helper.SetValueForDropdown("//*[@id='CAsServersSelect']", "АЦСК");
            //Helper.FindElement("//*[@id='PKeyFileName']").SendKeys(ECPPath);
            //Helper.FindElement("//*[@id='PKeyPassword']").SendKeys(Password);
            Helper.Delay(20);
                



            //Helper.FindElement("//*[@id=\"UserName\"]").EnterText(login);
            //Helper.FindElement("//*[@id=\"Password\"]").EnterText(password);
            //Helper.FindElement("//*[@id=\"loginform\"]/div[3]/button").JsClick();
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
