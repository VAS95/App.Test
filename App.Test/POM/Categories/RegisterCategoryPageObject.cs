using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Test.Helpers;
using OpenQA.Selenium.Support.PageObjects;

namespace App.Test.POM.Categories
{
    public class RegisterCategoryPageObject
    {
        public RegisterCategoryPageObject()
        {
            PageFactory.InitElements(SeleniumPropertiesCollection.Driver, this);
        }
    }
}
