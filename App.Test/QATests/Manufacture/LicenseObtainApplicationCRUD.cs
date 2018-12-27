using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Test.Helpers;
using App.Test.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace App.Test.QATests.Manufacture
{
    class LicenseObtainApplicationCRUD : QATestBase
    {
        [Test]
        public void Scenario_A_Create_Application()
        {
            Login();
            Helper.Delay(5);

            //SeleniumPropertiesCollection.Driver.Navigate().GoToUrl("http://localhost:5020/Application/Details/50189");

            CreateCustomApplication();

            //AddCustomMpd();

            //Helper.Delay(5);

            Console.WriteLine("Click STEP 3");
            Helper.FindElement("/html/body/div[2]/div[3]/div[4]/header").JsClick();
            Helper.Delay(5);

            Console.WriteLine("Create OrgEmployee button click");
            Helper.FindElement("//*[@id=\"newEmployee\"]").JsClick();
            Helper.Delay(5);

            Console.WriteLine("Enter FullName");
            Helper.FindElement("//*[@id=\"FullName\"]").SendKeys("Дем'яновський");

            Console.WriteLine("Enter Name");
            Helper.FindElement("//*[@id=\"Name\"]").SendKeys("Василь");

            Console.WriteLine("Enter MiddleName");
            Helper.FindElement("//*[@id=\"MiddleName\"]").SendKeys("Дмитрович");

            Console.WriteLine("Enter Birthday");
            Helper.FindElement("//*[@id=\"Birthday\"]").SetDate(new DateTime(2000, 1, 2));

            Console.WriteLine("Enter IPN");
            Helper.FindElement("//*[@id=\"IPN\"]").SetValue(6666666666);

            Console.WriteLine("Enter Email");
            Helper.FindElement("//*[@id=\"UserEmail\"]").SendKeys("vasiliydemyanovskyy@gmail.com");

            Console.WriteLine("Enter ContactInformation");
            Helper.FindElement("//*[@id=\"ContactInformation\"]").SendKeys("0996683163");

            Console.WriteLine("Enter YearOfGraduation");
            Helper.FindElement("//*[@id=\"YearOfGraduation\"]").SetValue(2000);

            Console.WriteLine("Enter NumberOfDiploma");
            Helper.FindElement("//*[@id=\"NumberOfDiploma\"]").SendKeys("666666");

            Console.WriteLine("Enter DateOfGraduation");
            Helper.FindElement("//*[@id=\"DateOfGraduation\"]").SetDate(new DateTime(2000, 1, 2));

            Console.WriteLine("Enter Speciality");
            Helper.FindElement("//*[@id=\"Speciality\"]").SendKeys("Інженерія програмного забезпечення");

            Console.WriteLine("Enter WorkExperience");
            Helper.FindElement("//*[@id=\"WorkExperience\"]").SetValue(666);

            Console.WriteLine("Enter EducationInstitution");
            Helper.FindElement("//*[@id=\"EducationInstitution\"]").SendKeys("Національний Авіаційний Університет");

            Console.WriteLine("Enter DateOfAppointment");
            Helper.FindElement("//*[@id=\"DateOfAppointment\"]").SetDate(new DateTime(2000, 1, 2));

            Console.WriteLine("Enter OrderNumber");
            Helper.FindElement("//*[@id=\"OrderNumber\"]").SendKeys("666666");

            Console.WriteLine("Enter MPD");
            Helper.FindElement("/html/body/div[2]/div[3]/div[8]/div/div/div/form/div[3]/div[1]/div[3]/div/div/button").JsClick();
            Helper.Delay(2);
            Helper.FindElement("/html/body/div[2]/div[3]/div[8]/div/div/div/form/div[3]/div[1]/div[3]/div/div/div/ul/li/a/span[1]").JsClick();

            Console.WriteLine("Enter NameOfPosition");
            Helper.FindElement("//*[@id=\"NameOfPosition\"]").SendKeys("Тестовий директор по тестуванню тестових тестів");

            Console.WriteLine("Enter NumberOfContract");
            Helper.FindElement("//*[@id=\"NumberOfContract\"]").SendKeys("666666");

            Console.WriteLine("Enter DateOfContract");
            Helper.FindElement("//*[@id=\"DateOfContract\"]").SetDate(new DateTime(2000, 1, 2));

            Console.WriteLine("Enter Comment");
            Helper.FindElement("/html/body/div[2]/div[3]/div[8]/div/div/div/form/div[4]/div/div/input").SendKeys("Тестовий коментар");

            Helper.Delay(15);

            Helper.FindElement("//*[@id=\"submitEmployee\"]").JsClick();




            //Console.WriteLine("Click STEP 3");
            //Helper.FindElement("/html/body/div[2]/div[3]/div[4]/header").JsClick();
            //Helper.Delay(5);

            //CreateContractor("Контрактрактний Виробник", "Локація Контрактного Виробника", "Manufacturer");
            //CreateContractor("Контрактна Лабораторія", "Локація Контрактної Лабораторії", "Laboratory");













        }

        public void CreateCustomApplication()
        {
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
            Console.WriteLine("Application creating started...");
            Helper.Delay(2);

            Console.WriteLine("Enter LegalFormType");
            Helper.SetValueForDropdown("//*[@id=\"LegalFormType\"]", "470 Релігійна спілка");

            Console.WriteLine("Enter OwnershipType");
            Helper.SetValueForDropdown("//*[@id=\"OwnershipType\"]", "40 Власність інших держав");

            //Set the value of City input with custom command (you can create with method CreateCity)
            Console.WriteLine("Enter City");
            Helper.FindElement("/html/body/div[2]/div[3]/div[2]/div[1]/form/div[2]/div[1]/div[2]/div/div/div[3]").Click();
            Helper.Delay(3);
            Helper.FindElement("/html/body/div[4]/div[2]/div[1]/div/input").EnterText("Київ");
            Helper.Delay(2);
            Helper.FindElement("/html/body/div[4]/div[2]/div[2]/div[3]/table/tbody/tr/td[1]").JsClick();

            //Set the value of Street input with custom command (you can create with method CreateStreet)
            Console.WriteLine("Enter Street");
            Helper.FindElement("/html/body/div[2]/div[3]/div[1]/div[1]/form/div[2]/div[1]/div[3]/div/input[1]").EnterText("Жилянська");
            Helper.Delay(3);

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

        public void AddCustomMpd()
        {
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
            Helper.FindElement("/html/body/div[3]/div[3]/div[2]/form/div/div[1]/div[4]/div/div/div[3]").Click();
            Helper.Delay(3);
            Helper.FindElement("/html/body/div[5]/div[2]/div[1]/div/input").EnterText("Київ");
            Helper.Delay(2);
            Helper.FindElement("/html/body/div[5]/div[2]/div[2]/div[3]/table/tbody/tr[1]/td[1]").JsClick();

            Console.WriteLine("Enter Street");
            Helper.FindElement("/html/body/div[3]/div[3]/div[1]/form/div/div[1]/div[6]/div/input[1]").EnterText("Жилянська");
            Helper.Delay(3);

            Console.WriteLine("Enter Building");
            Helper.FindElement("//*[@id=\"Building\"]").SendKeys("75");

            Console.WriteLine("Checkboxes on top activation");
            Helper.FindElement("/html/body/div[3]/div[3]/div[1]/form/div/div[2]/div[1]/div[1]/div/label").JsClick();
            Helper.FindElement("/html/body/div[3]/div[3]/div[1]/form/div/div[2]/div[1]/div[2]/div/label").JsClick();
            Helper.FindElement("/html/body/div[3]/div[3]/div[1]/form/div/div[2]/div[2]/div[1]/div/label").JsClick();
            Helper.FindElement("/html/body/div[3]/div[3]/div[1]/form/div/div[2]/div[2]/div[2]/div/label").JsClick();

            Console.WriteLine("Activation all checkboxes without textboxes");
            ReadOnlyCollection<IWebElement> TopLevelCheckboxesList = SeleniumPropertiesCollection.Driver.FindElements(By.ClassName("list__title--main"));
            foreach (var el in TopLevelCheckboxesList)
            {
                el.Click();
            }

            Console.WriteLine("Activation all checkboxes with textboxes");
            ReadOnlyCollection<IWebElement> InpuList = SeleniumPropertiesCollection.Driver.FindElements(By.ClassName("list__input"));
            foreach (var el in InpuList)
            {
                Console.WriteLine("Set data to input with id=" + el.GetProperty("id"));
                Helper.FindElement("//*[@for=\"" + el.GetProperty("id") + "\"]").Click();
                el.SendKeys("TEST DATA");
            }


            Helper.Delay(5);
            Console.WriteLine("Click Create MPD button");
            Helper.FindElement("//*[@id=\"submitBranch\"]").JsClick();
            Helper.Delay(10);
        }

        public void CreateContractor(string name, string location, string type)
        {

            if (type.Equals("Manufacturer"))
            {
                Console.WriteLine("Create ContractorManufacturer button click");
                Helper.FindElement("/html/body/div[2]/div[3]/div[4]/div/div[4]/a").JsClick();
            }

            if (type.Equals("Laboratory"))
            {
                Console.WriteLine("Create ContractorLaboratory button click");
                Helper.FindElement("/html/body/div[2]/div[3]/div[4]/div/div[7]/a").JsClick();
            }
            Helper.Delay(3);

            Console.WriteLine("Enter Edrpou");
            Helper.FindElement("//*[@id=\"Edrpou\"]").SetValue(666666666);

            Console.WriteLine("Enter MPD");
            Helper.FindElement("/html/body/div[2]/div[3]/div[8]/div/div/div/form/div[1]/div[1]/div[3]/div/div/button").JsClick();
            Helper.Delay(2);
            Helper.FindElement("/html/body/div[2]/div[3]/div[8]/div/div/div/form/div[1]/div[1]/div[3]/div/div/div/ul/li/a/span[1]").JsClick();

            Console.WriteLine("Enter Name");
            Helper.FindElement("//*[@id=\"Name\"]").SendKeys(name);

            Console.WriteLine("Enter Address");
            Helper.FindElement("//*[@id=\"Address\"]").SendKeys(location);

            Console.WriteLine("Submit contractor");
            Helper.FindElement("//*[@id=\"submitContractor\"]").JsClick();
            Helper.Delay(5);


            if (type.Equals("Manufacturer"))
            {
                ReadOnlyCollection<IWebElement> ContractorNamesList = SeleniumPropertiesCollection.Driver.FindElements(By.CssSelector("#contractorBox > table > tbody > tr > td:nth-child(2)"));
                ReadOnlyCollection<IWebElement> ContractorLocationList = SeleniumPropertiesCollection.Driver.FindElements(By.CssSelector("#contractorBox > table > tbody > tr > td:nth-child(3)"));

                if (TestResult.IsElementExist("/html/body/div[2]/div[3]/div[4]/div/div[5]/table/tbody/tr"))
                {
                    int matchIndicator = 0;
                    foreach (var contractor in ContractorNamesList)
                    {
                        if (contractor.Text.Equals(name))
                        {
                            Console.WriteLine("CONTRACTOR NAME FOUND IN LIST");
                            matchIndicator += 1;
                            break;
                        }
                    }

                    foreach (var contractor in ContractorLocationList)
                    {
                        if (contractor.Text.Equals(location))
                        {
                            Console.WriteLine("CONTRACTOR LOCATION FOUND IN LIST");
                            matchIndicator += 1;
                            break;
                        }
                    }
                    Console.WriteLine(matchIndicator == 2 ? "CONTRACTOR CREATED" : "ERROR CREATING CONTRACTOR");
                }
            }

            if (type.Equals("Laboratory"))
            {
                ReadOnlyCollection<IWebElement> ContractorLabNamesList = SeleniumPropertiesCollection.Driver.FindElements(By.CssSelector("#contractorLabBox > table > tbody > tr:nth-child(1) > td:nth-child(2)"));
                ReadOnlyCollection<IWebElement> ContractorLabLocationList = SeleniumPropertiesCollection.Driver.FindElements(By.CssSelector("#contractorLabBox > table > tbody > tr:nth-child(1) > td:nth-child(3)"));


                if (TestResult.IsElementExist("/html/body/div[2]/div[3]/div[4]/div/div[5]/table/tbody/tr"))
                {
                    int matchIndicator = 0;
                    foreach (var contractor in ContractorLabNamesList)
                    {
                        if (contractor.Text.Equals(name))
                        {
                            Console.WriteLine("CONTRACTOR NAME FOUND IN LIST");
                            matchIndicator += 1;
                            break;
                        }
                    }

                    foreach (var contractor in ContractorLabLocationList)
                    {
                        if (contractor.Text.Equals(location))
                        {
                            Console.WriteLine("CONTRACTOR LOCATION FOUND IN LIST");
                            matchIndicator += 1;
                            break;
                        }
                    }

                    Console.WriteLine(matchIndicator == 2 ? "CONTRACTOR CREATED" : "ERROR CREATING CONTRACTOR");
                }
            }
        }
    }
}
