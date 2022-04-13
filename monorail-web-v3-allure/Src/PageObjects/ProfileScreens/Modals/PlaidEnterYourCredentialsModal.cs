using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.ProfileScreens.Modals
{
    public class PlaidEnterYourCredentialsModal
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='aut-input-1']")]
        private IWebElement _passwordField;

        [FindsBy(How = How.XPath, Using = "//button[@id='aut-button']")]
        private IWebElement _submitButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='aut-input-0']")]
        private IWebElement _usernameField;


        public PlaidEnterYourCredentialsModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Submit' button")]
        public PlaidEnterYourCredentialsModal PassCredentials()
        {
            Wait.Until(ElementToBeVisible(_usernameField));
            Wait.Until(ElementToBeVisible(_passwordField));
            Wait.Until(ElementToBeClickable(_submitButton));

            _usernameField.SendKeys("user_good");
            _passwordField.SendKeys("pass_good");
            _submitButton.Click();
            return this;
        }

        [AllureStep("Click 'Submit' button")]
        public PlaidEnterYourCredentialsModal ClickSubmitButton()
        {
            Wait.Until(ElementToBeVisible(_submitButton));
            _submitButton.Click();
            return this;
        }
    }
}