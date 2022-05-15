using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Login
{
    [TestFixture, AllureNUnit]
    internal class LoginAndLogout : FunctionalTesting
    {
        [Test(Description = "Successful login with correct username and password")]
        [AllureEpic("Login")]
        [AllureFeature("Successful Login")]
        [AllureStory("Valid Login and Logout Test")]
        public void LoginAndLogoutTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);

            const string username = "autotests.mono+40.131021@gmail.com";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .ExpandSideMenu();

            sideMenu
                .ClickLogOutLink();
        }
    }
}