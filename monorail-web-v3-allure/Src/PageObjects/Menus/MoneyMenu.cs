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

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Spend')]")]
        private IWebElement _spendNavMenu;

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

        [AllureStep("Click 'Spend'")]
        public MoneyMenu ClickSpend()
        {
            Wait.Until(ElementToBeClickable(_spendNavMenu));
            _spendNavMenu.Click();
            return this;
        }
    }
}