using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using App.Test.Helpers;
using App.Test.POM.Categories;


namespace App.Test.POM
{
    public enum ModdiCategories
    {

        Main,
        Submition,
        Monitoring,
        Messages,
        VksResult,
        Register
    }


    public class ModdiMainPageObject
    {
        public ModdiMainPageObject()
        {
            PageFactory.InitElements(SeleniumPropertiesCollection.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/aside/ul/li[1]/a")]
        private IWebElement HrefMain { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/aside/ul/li[2]/a")]
        private IWebElement HrefSubmition { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/aside/ul/li[3]/a")]
        private IWebElement HrefMonitoring { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/aside/ul/li[4]/a")]
        private IWebElement HrefMessages { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/aside/ul/li[5]/a")]
        private IWebElement HrefVksResult { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/aside/ul/li[6]/a")]
        private IWebElement HrefRegister { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"user__logout\"]")]
        private  IWebElement HrefLogout { get; set; }

        public object GoToCategory(ModdiCategories moddiCategories)
        {
            switch (moddiCategories)
            {
                case ModdiCategories.Main:
                    HrefMain.JsClick();
                    return  new MainCategoryPageObject();
                case ModdiCategories.Submition:
                    HrefSubmition.JsClick();
                    return new SubmitionCategoryPageObject();
                case ModdiCategories.Monitoring:
                    HrefMonitoring.JsClick();
                    return new SubmitionCategoryPageObject();
                case ModdiCategories.Messages:
                    HrefMessages.JsClick();
                    return new MessagesCategoryPageObject();
                case ModdiCategories.VksResult:
                    HrefVksResult.JsClick();
                    return  new VksResultCategoryPageObject();
                case ModdiCategories.Register:
                    HrefRegister.JsClick();
                    return  new RegisterCategoryPageObject();
                default:
                    throw new NotFoundException("The category doesn't exist");
            }
        }
        public LoginPageObject LogOut()
        {
            HrefLogout.Click();
            return new LoginPageObject();
        }

    }
}
