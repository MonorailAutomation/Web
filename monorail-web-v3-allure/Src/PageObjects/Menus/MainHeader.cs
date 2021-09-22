using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Menus
{
    public class MainHeader
    {
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header__main-content']//child::span[contains(text(),'Invest')]")]
        private IWebElement InvestNavItem;

        public MainHeader(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Invest'")]
        public MainHeader ClickInvest()
        {
            Wait.Until(ElementToBeClickable(InvestNavItem));
            InvestNavItem.Click();
            return this;
        }
    }
}