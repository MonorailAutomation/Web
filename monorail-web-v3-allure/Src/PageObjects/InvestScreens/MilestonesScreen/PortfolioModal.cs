using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen
{
    public class PortfolioModal
    {
        [FindsBy(How = How.XPath, Using = "//vim-recommended-portfolio-modal//button[contains(text(),'Continue')]")]
        private IWebElement ContinueButton;

        public PortfolioModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public PortfolioModal ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(ContinueButton));
            ContinueButton.Click();
            return this;
        }
    }
}