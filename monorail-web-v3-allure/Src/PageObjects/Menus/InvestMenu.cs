using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Menus
{
    public class InvestMenu
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Milestones')]")]
        private IWebElement _milestonesNavItem;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Trading')]")]
        private IWebElement _tradingNavItem;

        public InvestMenu(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Trading'")]
        public InvestMenu ClickTrading()
        {
            Wait.Until(ElementToBeClickable(_tradingNavItem));
            _tradingNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Milestones'")]
        public InvestMenu ClickMilestones()
        {
            Wait.Until(ElementToBeClickable(_milestonesNavItem));
            _milestonesNavItem.Click();
            return this;
        }
    }
}