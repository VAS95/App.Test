using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Test.Helpers;
using App.Test.POM;
using NUnit.Framework;
using OpenQA.Selenium;

namespace App.Test.QATests.Manufacture
{
    class LicenseObtainApplicationCRUD : QATestBase
    {
        [Test]
        public void Scenario_A_Create_Application()
        {
            Login();
            Console.WriteLine("Create application");
            Helper.Delay(5);

            Helper.GoToCategory(CategoryTab.Submition);
            Helper.Delay(2);

            Helper.FindElement("/html/body/div[2]/div[3]/div[2]/header/a").JsClick();
            Helper.Delay(2);

            Helper.FindElement("/html/body/div[2]/div[3]/div[3]/div[2]/p[1]").JsClick();
            Helper.Delay(2);

            Helper.FindElement("/html/body/div[2]/div[3]/div[6]/a").JsClick();
            Helper.Delay(4);
            Console.WriteLine("Application creating started...");
            
            Helper.SetValueForDropdown("//*[@id=\"LegalFormType\"]", "470 Релігійна спілка");
            Helper.SetValueForDropdown("//*[@id=\"OwnershipType\"]", "40 Власність інших держав");

            //Set the value of City input with custom command (you can create with method CreateCity)
            Helper.FindElement("/html/body/div[2]/div[3]/div[2]/div[1]/form/div[2]/div[1]/div[2]/div/div/div[2]/input").EnterText("Київ", 1);
            Helper.Delay(5);
            Helper.FindElement("//*[@class=\"ui-menu-item-wrapper\"]").JsClick();
            Console.WriteLine("City added");

            
            Helper.FindElement("/html/body/div[2]/div[3]/div[2]/div[1]/form/div[2]/div[1]/div[3]/div/input[1]").EnterText("Жилянська");
            Helper.Delay(5);
            Console.WriteLine("Street added");



            Helper.Delay(2);
            Helper.FindElement("//*[@id=\"OrgDirector\"]").SendKeys("Дем'яновський Василь Дмитрович");
            Helper.FindElement("//*[@id=\"EMail\"]").SendKeys("vasiliydemyanovskyy@gmail.com");
            Helper.FindElement("//*[@id=\"Building\"]").SendKeys("75");
            Helper.FindElement("//*[@id=\"Phone\"]").SendKeys("0996683163");
            Helper.FindElement("//*[@id=\"FaxNumber\"]").SendKeys("0996683163");
            Helper.Delay(5);
            Helper.FindElement("//*[@id=\"PostIndex\"]").JsClick();
                //SendKeys("12345");
            Helper.Delay(5);
            Helper.FindElement("//*[@id=\"NationalAccount\"]").SendKeys("666666");
            Helper.FindElement("//*[@id=\"InternationalAccount\"]").SendKeys("666666");
            Helper.FindElement("//*[@id=\"NationalBankRequisites\"]").SendKeys("NaziBank");
            Helper.FindElement("//*[@id=\"InternationalBankRequisites\"]").SendKeys("InterNaziBank");
            Helper.FindElement("//*[@id=\"NationalAccount\"]").SendKeys("666");
            Helper.FindElement("//*[@id=\"Duns\"]").SendKeys("666");
            Helper.Delay(20);
            Helper.FindElement("//*[@id=\"submitBranch\"]").JsClick();

            Helper.Delay(10);


        }

        public void CreateCity(string district, string type, string region, string name)
        {
            Helper.FindElement("//*[@id=\"newCity\"]").JsClick();
            Helper.Delay(5);
            Helper.SetValueForDropdown("//*[@id=\"RegionId\"]", district);
            Helper.SetValueForDropdown("//*[@id=\"LocalityType\"]", type);
            Helper.FindElement("//*[@id=\"district-off\"]").EnterText(region, 1);
            Helper.FindElement("//*[@class=\"ui-menu-item-wrapper\"]").JsClick();
            Helper.FindElement("//*[@id=\"Name\"]").SendKeys(name);

            Helper.FindElement("//*[@id=\"submitCity\"]").JsClick();
        }
    }
}
