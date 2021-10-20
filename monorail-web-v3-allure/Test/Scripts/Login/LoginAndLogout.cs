using System;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Menus;
using static monorail_web_v3.Commons.Passwords;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace monorail_web_v3.Test.Scripts.Login
{
    [TestFixture]
    [AllureNUnit]
    internal class LoginAndLogout : FunctionalTesting
    {
        private const string Username = "autotests.mono+40.131021@gmail.com";
        //private const string Password = "Test123!!";

        [Test(Description = "Successful login with correct username and password")]
        [AllureEpic("Login")]
        [AllureFeature("Successful Login")]
        [AllureStory("Valid Login and Logout Test")]
        public void LoginAndLogoutTest()
        {
            var loginPage = new LoginPage(Driver);
            var sideMenu = new SideMenu(Driver);
            
            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();
            
            sideMenu
                .ExpandSideMenu()
                .Logout();
        }
    }
}