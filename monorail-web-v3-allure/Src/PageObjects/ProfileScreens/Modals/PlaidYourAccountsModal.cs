using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.ProfileScreens.Modals
{
    public class PlaidYourAccountsModal
    {
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Plaid Checking')]")]
        private IWebElement _plaidCheckingOption;

        public PlaidYourAccountsModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Plaid Checking' option")]
        public PlaidYourAccountsModal ClickPlaidCheckingOption()
        {
            Wait.Until(ElementToBeVisible(_plaidCheckingOption));
            _plaidCheckingOption.Click();
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public PlaidYourAccountsModal ClickContinueButton()
        {
            Wait.Until(ElementToBeVisible(_continueButton));
            _continueButton.Click();
            return this;
        }
    }
}