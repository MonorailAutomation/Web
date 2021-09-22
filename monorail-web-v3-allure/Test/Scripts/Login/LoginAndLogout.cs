using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace monorail_web_v3.Test.Scripts.Login
{
    [TestFixture]
    [AllureNUnit]
    internal class LoginAndLogout : FunctionalTesting
    {
        private const string Username = "mp.1.042021@vimvest.com";
        private const string Password = "Test123!!";

        [Test(Description = "Valid Login and Logout Test")]
        [AllureEpic("Login")]
        [AllureFeature("Valid Login")]
        [AllureStory("Login with correct username and password")]
        public void LoginAndLogoutTest()
        {
            var loginPage = new LoginPage(Driver);
            var sideMenu = new SideMenu(Driver);

            loginPage
                .PassCredentials(Username, Password)
                .ClickSignInButton();

            sideMenu
                .ExpandSideMenu()
                .Logout();
        }
    }
}