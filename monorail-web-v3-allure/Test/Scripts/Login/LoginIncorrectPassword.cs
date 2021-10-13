using monorail_web_v3.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace monorail_web_v3.Test.Scripts.Login
{
    [TestFixture]
    [AllureNUnit]
    internal class LoginIncorrectPassword : FunctionalTesting
    {
        private const string ValidUsername = "autotests.mono+40.131021@gmail.com";
        private const string InvalidPassword = "123456789";

        [Test(Description = "Unsuccessful login with correct username and incorrect password")]
        [AllureEpic("Login")]
        [AllureFeature("Unsuccessful Login")]
        [AllureStory("Invalid Login - incorrect password")]
        public void LoginIncorrectPasswordTest()
        {
            var loginPage = new LoginPage(Driver);

            loginPage
                .PassCredentials(ValidUsername, InvalidPassword)
                .ClickSignInButton()
                .VerifyIfWhoopsIncorrectEmailOrPasswordMessageIsDisplayed();
        }
    }
}