using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Money.Spend
{
    [TestFixture, AllureNUnit]
    internal class LockUnlockCard : FunctionalTesting
    {
        [Test(Description = "Lock/Unlock Card")]
        [AllureEpic("Money")]
        [AllureFeature("Spend")]
        [AllureStory("Lock/Unlock Card")]
        public void LockUnlockCardTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var spendMainScreen = new SpendMainScreen(Driver);

            const string username = "autotests.mono+5.1.160322@gmail.com";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .ClickMoney();

            moneyScreen
                .ClickSpend();

            spendMainScreen
                .CheckIfCardIsActive()
                .ClickLockUnlockCardToggle()
                .CheckIfCardIsLocked()
                .ClickLockUnlockCardToggle()
                .CheckIfCardIsActive();
        }
    }
}