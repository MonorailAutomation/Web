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
        private IWebElement MilestonesNavItem;

        public InvestMenu(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Milestones'")]
        public InvestMenu ClickMilestones()
        {
            Wait.Until(ElementToBeClickable(MilestonesNavItem));
            MilestonesNavItem.Click();
            return this;
        }
    }
}