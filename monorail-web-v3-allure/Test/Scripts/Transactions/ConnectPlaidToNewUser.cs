using System.Linq;
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
using static monorail_web_v3.DataGenerator.NumberGenerator;
using static monorail_web_v3.RestRequests.Helpers.UserManagementHelperFunctions;
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
            var connectedAccountScreen = new ConnectedAccountScreen(Driver);

            var username = UsernamePrefix + GenerateRandomDigits(3) + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .ExpandSideMenu();

            sideMenu
                .ClickMyConnectedAccountLink();

            connectedAccountScreen
                .CheckConnectedAccountScreenWithoutPlaidAccount()
                .ClickConnectYourBankAccountButton();

            ConnectPlaid();

            connectedAccountScreen
                .CheckMyConnectedAccountScreenWithConnectedPlaidAccount();

            CloseUser(username);
        }

        public static void ConnectPlaid()
        {
            var plaidWelcomeModal = new PlaidWelcomeModal(Driver);
            var plaidSelectYourBankModal = new PlaidSelectYourBankModal(Driver);
            var plaidEnterYourCredentialsModal = new PlaidEnterYourCredentialsModal(Driver);
            var plaidYourAccountsModal = new PlaidYourAccountsModal(Driver);
            var plaidSuccessModal = new PlaidSuccessModal(Driver);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

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

            Wait.Until(wd => wd.WindowHandles.Count == 1);
            Thread.Sleep(1000);
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }
    }
}