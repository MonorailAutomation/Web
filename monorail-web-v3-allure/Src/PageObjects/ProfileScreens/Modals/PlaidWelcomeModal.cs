using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.ProfileScreens.Modals
{
    public class PlaidWelcomeModal
    {
        [FindsBy(How = How.XPath, Using = "//button[@id='aut-button']")]
        private IWebElement _continueButton;

        public PlaidWelcomeModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public PlaidWelcomeModal ClickContinueButton()
        {
            Wait.Until(ElementToBeVisible(_continueButton));
            _continueButton.Click();
            return this;
        }
    }
}