using monorail_web_v3.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Passwords;

namespace monorail_web_v3.Test.Scripts.Login
{
    [TestFixture]
    [AllureNUnit]
    internal class LoginIncorrectPassword : FunctionalTesting
    {
        [Test(Description = "Unsuccessful login with correct username and incorrect password")]
        [AllureEpic("Login")]
        [AllureFeature("Unsuccessful Login")]
        [AllureStory("Invalid Login - incorrect password")]
        public void LoginIncorrectPasswordTest()
        {
            var loginPage = new LoginPage(Driver);

            const string validUsername = "autotests.mono+40.131021@gmail.com";

            loginPage
                .PassCredentials(validUsername, InvalidPassword)
                .ClickSignInButton()
                .VerifyIfWhoopsIncorrectEmailOrPasswordMessageIsDisplayed();
        }
    }
}