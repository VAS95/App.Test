using App.Test.Helpers;
using NUnit.Framework;
using System;
using System.Configuration;


namespace App.Test.QATests
{
    class LoginPageTest : QATestBase
    {
        [Test]
        public void Scenario_Login()
        {
            Login();
        }

        [Test]
        public void Scenario_Logout()
        {
           Logout();
        }
    }
}
