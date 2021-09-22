using monorail_web_v3.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace monorail_web_v3.Test.Scripts.Login
{
    [TestFixture]
    [AllureNUnit]
    internal class LoginWithoutCredentials : FunctionalTesting
    {
        private const string Username = "mp.1.042021@vimvest.com";
        private const string EmptyUsername = "";
        private const string EmptyPassword = "";

        [Test(Description = "Invalid Login Test with correct username and empty password")]
        [AllureEpic("Login")]
        [AllureFeature("Invalid Login")]
        [AllureStory("Invalid Login with empty username and empty password")]
        public void LoginWithoutEmailAndPasswordTest()
        {
            var loginPage = new LoginPage(Driver);

            loginPage
                .PassCredentials(EmptyUsername, EmptyPassword)
                .ClickSignInButton()
                .VerifyIfEmailIsRequired()
                .VerifyIfPasswordIsRequired();
        }

        [Test(Description = "Invalid Login Test with empty username and empty password")]
        [AllureEpic("Login")]
        [AllureFeature("Invalid Login")]
        [AllureStory("Invalid Login with correct username and empty password")]
        public void LoginWithoutPasswordTest()
        {
            var loginPage = new LoginPage(Driver);

            loginPage
                .PassCredentials(Username, EmptyPassword)
                .ClickSignInButton()
                .VerifyIfEmailIsRequired()
                .VerifyIfPasswordIsRequired();
        }
    }
}