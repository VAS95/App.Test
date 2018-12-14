using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace App.Test.QATests
{
    class LoginPageTest : QATestBase
    {
        [Test]
        public void Scenario_Login()
        {
            Login();
        }
    }
}
