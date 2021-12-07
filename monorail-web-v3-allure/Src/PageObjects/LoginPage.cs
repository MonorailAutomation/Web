using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects
{
    public class LoginPage
    {
        private const string ExpectedInvalidLoginHeader = "Whoops! Incorrect email or password.";

        private const string ExpectedInvalidLoginMessage =
            "If you don't have an account, create one in the Vimvest App.";

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Create an Account')]")]
        private IWebElement _createAnAccountButton;

        [FindsBy(How = How.Id, Using = "inputEmail")]
        private IWebElement _emailField;

        [FindsBy(How = How.ClassName, Using = "vim-flash-message__dismiss")]
        private IWebElement _flashMessageDismissButton;

        [FindsBy(How = How.ClassName, Using = "vim-flash-message__text")]
        private IWebElement _flashMessageText;

        [FindsBy(How = How.ClassName, Using = "vim-flash-message__title")]
        private IWebElement _flashMessageTitle;

        [FindsBy(How = How.Id, Using = "inputPassword")]
        private IWebElement _passwordField;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Reset Password')]")]
        private IWebElement _resetPasswordButton;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement _signInButton;

        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Login with user '{0}' and password '{1}'")]
        public LoginPage PassCredentials(string email, string password)
        {
            Wait.Until(ElementToBeVisible(_emailField));
            Wait.Until(ElementToBeVisible(_passwordField));

            _emailField.SendKeys(email);
            _passwordField.SendKeys(password);
            return this;
        }

        [AllureStep("Click 'Sign In' button")]
        public LoginPage ClickSignInButton()
        {
            Wait.Until(ElementToBeClickable(_signInButton));
            _signInButton.Click();
            return this;
        }

        [AllureStep("Click 'Create an Account' button")]
        public LoginPage ClickCreateAnAccountButton()
        {
            Wait.Until(ElementToBeClickable(_createAnAccountButton));
            _createAnAccountButton.Click();
            return this;
        }

        [AllureStep("Verify that 'Whoops! Incorrect email or password.' message is displayed")]
        public LoginPage VerifyIfWhoopsIncorrectEmailOrPasswordMessageIsDisplayed()
        {
            Wait.Until(ElementToBeVisible(_flashMessageTitle));
            Wait.Until(ElementToBeVisible(_flashMessageText));
            Wait.Until(ElementToBeClickable(_flashMessageDismissButton));

            var actualHeader = _flashMessageTitle.Text;
            var actualMessage = _flashMessageText.Text;

            actualHeader.Should().Be(ExpectedInvalidLoginHeader);
            actualMessage.Should().Be(ExpectedInvalidLoginMessage);

            return this;
        }
    }
}