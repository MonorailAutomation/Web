using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Menus
{
    public class MoneyMenu
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Save')]")]
        private IWebElement _saveNavMenu;

        public MoneyMenu(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Save'")]
        public MoneyMenu ClickSave()
        {
            Wait.Until(ElementToBeClickable(_saveNavMenu));
            _saveNavMenu.Click();
            return this;
        }
    }
}