using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Menus;
using monorail_web_v3.PageObjects.ProfileScreens.Modals;
using monorail_web_v3.PageObjects.ProfileScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Commons.RandomGenerator;
using static monorail_web_v3.RestRequests.Helpers.UserOnboardingHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class ConnectPlaidToNewUser : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+20.071121";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Connect Plaid to new user")]
        [AllureEpic("Transactions")]
        [AllureFeature("Plaid")]
        [AllureStory("Connect Plaid to new user")]
        public void ConnectPlaidToNewUserTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);
            var myConnectedAccountScreen = new MyConnectedAccountScreen(Driver);
            var plaidWelcomeModal = new PlaidWelcomeModal(Driver);
            var plaidSelectYourBankModal = new PlaidSelectYourBankModal(Driver);
            var plaidEnterYourCredentialsModal = new PlaidEnterYourCredentialsModal(Driver);
            var plaidYourAccountsModal = new PlaidYourAccountsModal(Driver);
            var plaidSuccessModal = new PlaidSuccessModal(Driver);

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .ExpandSideMenu();

            sideMenu
                .ClickMyConnectedAccountLink();

            Thread.Sleep(10000); // issue 32348

            myConnectedAccountScreen
                .CheckMyConnectedAccountScreenWithoutPlaidAccount()
                .ClickLinkYourBankAccount();

            var plaidIframe = Driver.FindElement(By.Id("plaid-link-iframe-1"));
            Driver.SwitchTo().Frame(plaidIframe);

            plaidWelcomeModal
                .ClickContinueButton();

            plaidSelectYourBankModal
                .ClickBank("Chase");

            plaidEnterYourCredentialsModal
                .PassCredentials()
                .ClickSubmitButton();

            plaidYourAccountsModal
                .ClickPlaidCheckingOption()
                .ClickContinueButton();

            plaidSuccessModal
                .ClickContinueButton();

            Driver.SwitchTo().DefaultContent();

            myConnectedAccountScreen
                .CheckMyConnectedAccountScreenWithConnectedPlaidAccount();
        }
    }
}