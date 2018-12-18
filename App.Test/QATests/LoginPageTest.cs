using App.Test.Helpers;
using NUnit.Framework;
using System;
using System.Configuration;


namespace App.Test.QATests
{
    class LoginPageTest : QATestBase
    {
        private readonly string loggedInName = ConfigurationManager.AppSettings["LoggedInName"];

        [Test]
        public void Scenario_Login()
        {
            Login();

            var сurrentUserName = Helper.FindElement("/html/body/div[2]/div[1]/aside/footer/a[1]/span").Text;
            Console.WriteLine("Current user name is {CurrentUserName}");

            TestResult.IsElementExist("/html/body/div[2]/div[1]/aside/footer/a[1]/span");
        }

        [Test]
        public void Scenario_Logout()
        {
            Login();
            Helper.Delay(5);
            Helper.FindElement("//*[@id=\"user__logout\"]").JsClick();
        }
    }
}
