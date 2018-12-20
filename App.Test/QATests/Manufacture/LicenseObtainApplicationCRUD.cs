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

            Console.WriteLine("Add application button press on Application/Index page");
            Helper.FindElement("/html/body/div[2]/div[3]/div[2]/header/a").JsClick();
            Helper.Delay(2);

            Helper.FindElement("/html/body/div[2]/div[3]/div[3]/div[2]/p[1]").JsClick();
            Helper.Delay(2);

            Helper.FindElement("/html/body/div[2]/div[3]/div[6]/a").JsClick();
            Helper.Delay(4);
            Console.WriteLine("Application creating started...");

            Console.WriteLine("Enter LegalFormType");
            Helper.SetValueForDropdown("//*[@id=\"LegalFormType\"]", "470 Релігійна спілка");

            Console.WriteLine("Enter OwnershipType");
            Helper.SetValueForDropdown("//*[@id=\"OwnershipType\"]", "40 Власність інших держав");

            //Set the value of City input with custom command (you can create with method CreateCity)
            Console.WriteLine("Enter City");
            Helper.Delay(5);
            Helper.FindElement("/html/body/div[2]/div[3]/div[1]/div[1]/form/div[2]/div[1]/div[2]/div/div/div[3]").JsClick();
            Helper.Delay(3);
            Helper.FindElement("/html/body/div[4]/div[2]/div[1]/div/input").EnterText("Київ");
            Helper.Delay(2);
            Helper.FindElement("/html/body/div[4]/div[2]/div[2]/div[3]/table/tbody/tr/td[1]").JsClick();



            //Helper.FindElement("/html/body/div[2]/div[3]/div[2]/div[1]/form/div[2]/div[1]/div[2]/div/div/div[2]/input").EnterText("Київ", 1);
            //Helper.Delay(2);
            //Helper.FindElement("//*[@class=\"ui-menu-item-wrapper\"]").JsClick();
            //Helper.Delay(10);
            //Set the value of Street input with custom command (you can create with method CreateStreet)
            Console.WriteLine("Enter Street");
            Helper.FindElement("/html/body/div[2]/div[3]/div[1]/div[1]/form/div[2]/div[1]/div[3]/div/input[1]").EnterText("Жилянська");
            Helper.Delay(5);
            Console.WriteLine("Enter OrgDirector");
            Helper.FindElement("//*[@id=\"OrgDirector\"]").SendKeys("Дем'яновський Василь Дмитрович");

            Console.WriteLine("Enter EMail");
            Helper.FindElement("//*[@id=\"EMail\"]").SendKeys("vasiliydemyanovskyy@gmail.com");

            Console.WriteLine("Enter Building");
            Helper.FindElement("//*[@id=\"Building\"]").SendKeys("75");

            Console.WriteLine("Enter Phone");
            Helper.FindElement("//*[@id=\"Phone\"]").SendKeys("0996683163");

            Console.WriteLine("Enter FaxNumber");
            Helper.FindElement("//*[@id=\"FaxNumber\"]").SendKeys("0996683163");

            Console.WriteLine("Enter PostIndex");
            Helper.FindElement("//*[@id=\"PostIndex\"]").SetValue(55555);

            Console.WriteLine("Enter NationalAccount");
            Helper.FindElement("//*[@id=\"NationalAccount\"]").SendKeys("666666");

            Console.WriteLine("Enter InternationalAccount");
            Helper.FindElement("//*[@id=\"InternationalAccount\"]").SendKeys("666666");

            Console.WriteLine("Enter NationalBankRequisites");
            Helper.FindElement("//*[@id=\"NationalBankRequisites\"]").SendKeys("NaziBank");

            Console.WriteLine("Enter InternationalBankRequisites");
            Helper.FindElement("//*[@id=\"InternationalBankRequisites\"]").SendKeys("InterNaziBank");

            Console.WriteLine("Enter NationalAccount");
            Helper.FindElement("//*[@id=\"NationalAccount\"]").SendKeys("666");

            Console.WriteLine("Enter Duns");
            Helper.FindElement("//*[@id=\"Duns\"]").SendKeys("666");

            Console.WriteLine("Click application create button");
            Helper.FindElement("//*[@id=\"submitBranch\"]").JsClick();

            Helper.Delay(10);

            Console.WriteLine("CREATING MPD");
            Console.WriteLine("Click STEP 2");
            Helper.FindElement("/html/body/div[2]/div[3]/div[3]/header").JsClick();
            Helper.Delay(2);

            Console.WriteLine("Create MPD button click");
            Helper.FindElement("//*[@id=\"addMpd\"]").JsClick();
            Helper.Delay(2);

            Console.WriteLine("Enter Name");
            Helper.FindElement("//*[@id=\"Name\"]").SendKeys("Тестовий структурний підрозділ");

            Console.WriteLine("Enter PhoneNumber");
            Helper.FindElement("//*[@id=\"PhoneNumber\"]").SendKeys("0996683163");

            Console.WriteLine("Enter FaxNumber");
            Helper.FindElement("//*[@id=\"FaxNumber\"]").SendKeys("0996683163");

            Console.WriteLine("Enter EMail");
            Helper.FindElement("//*[@id=\"EMail\"]").SendKeys("vasiliydemyanovskyy@gmail.com");

            Console.WriteLine("Enter AddressEng");
            Helper.FindElement("//*[@id=\"AddressEng\"]").SendKeys("English test address");

            Console.WriteLine("Enter PostIndex");
            Helper.FindElement("//*[@id=\"PostIndex\"]").SetValue(12345);

            Console.WriteLine("Enter City");
            Helper.FindElement("/html/body/div[3]/div[3]/div[2]/form/div/div[1]/div[4]/div/div/div[2]/input").EnterText("Київ", 1);
            Helper.Delay(3);
            Helper.FindElement("//*[@class=\"ui-menu-item-wrapper\"]").JsClick();

            Console.WriteLine("Enter Street");
            Helper.FindElement("/html/body/div[3]/div[3]/div[2]/form/div/div[1]/div[6]/div/input[1]").EnterText("Жилянська");

            Console.WriteLine("Enter Building");
            Helper.FindElement("//*[@id=\"Building\"]").SendKeys("75");

            Console.WriteLine("Checkboxes on top activation");
            Helper.FindElement("/html/body/div[3]/div[3]/div[2]/form/div/div[2]/div[1]/div[1]/div/label").JsClick();
            Helper.FindElement("/html/body/div[3]/div[3]/div[2]/form/div/div[2]/div[1]/div[2]/div/label").JsClick();
            Helper.FindElement("/html/body/div[3]/div[3]/div[2]/form/div/div[2]/div[2]/div[1]/div/label").JsClick();
            Helper.FindElement("/html/body/div[3]/div[3]/div[2]/form/div/div[2]/div[2]/div[2]/div/label").JsClick();

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

            if (String.IsNullOrEmpty(Helper.FindElement("/html/body/div[2]/div[3]/div[1]/div[1]/form/div[2]/div[1]/div[2]/div/div/div[2]/input").Text))
            {
                TestResult.IsFailed();
            }
        }

        public void CreateStreet(string streetType, string name)
        {
            Helper.FindElement("//*[@id=\"newStreet\"]").JsClick();
            Helper.Delay(5);
            Helper.SetValueForDropdown("//*[@id=\"StreetType\"]", streetType);
            Helper.FindElement("//*[@id=\"Name\"]").SendKeys(name);
            Helper.FindElement("//*[@id=\"submitStreet\"]").JsClick();
        }

    }
}
