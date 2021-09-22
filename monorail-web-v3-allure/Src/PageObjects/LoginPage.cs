using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "inputEmail")]
        private IWebElement EmailField;

        [FindsBy(How = How.Id, Using = "inputPassword")]
        private IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//input[@id='inputEmail']//following::div[1]")]
        private IWebElement RequiredUnderEmail;

        [FindsBy(How = How.XPath, Using = "//input[@id='inputPassword']//following::div[1]")]
        private IWebElement RequiredUnderPassword;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement SignInButton;

        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Login with user '{0}' and password '{1}'")]
        public LoginPage PassCredentials(string email, string password)
        {
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            return this;
        }

        [AllureStep("Click 'Sign In' button")]
        public LoginPage ClickSignInButton()
        {
            SignInButton.Click();
            return this;
        }

        [AllureStep("Verify if 'Required' text is visible under E-mail field")]
        public LoginPage VerifyIfEmailIsRequired()
        {
            Wait.Until(ElementToBeVisible(RequiredUnderEmail));
            return this;
        }

        [AllureStep("Verify if 'Required' text is visible under Password field")]
        public LoginPage VerifyIfPasswordIsRequired()
        {
            Wait.Until(ElementToBeVisible(RequiredUnderPassword));
            return this;
        }
    }
}