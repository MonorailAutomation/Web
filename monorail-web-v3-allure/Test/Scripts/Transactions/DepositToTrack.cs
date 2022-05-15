using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals.TransactionModals;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture, AllureNUnit]
    internal class DepositToTrack : FunctionalTesting
    {
        [Test(Description = "Deposit to Track")]
        [AllureEpic("Transactions")]
        [AllureFeature("Save")]
        [AllureStory("Deposit to Track")]
        public void DepositToTrackTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var saveMainScreen = new SaveMainScreen(Driver);
            var trackDetailsScreen = new TrackDetailsScreen(Driver);
            var trackAddCashModal = new TrackAddCashModal(Driver);
            var trackAddCashSuccessModal = new TrackAddCashSuccessModal(Driver);

            const string username = "autotests.mono+7.4.030322@gmail.com";
            const string trackName = "Travel";
            const string amount = "5";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickMoney();

            moneyScreen
                .CheckMoneyScreen()
                .ClickSave();

            saveMainScreen
                .ClickTrack(trackName);

            trackDetailsScreen
                .ClickAddFundsButton();

            trackAddCashModal
                .CheckTrackAddCashModal()
                .SetAddCashAmount(amount)
                .ClickConfirmButton();

            trackAddCashSuccessModal
                .CheckWishlistAddCashSuccessModal()
                .VerifyDepositedAmount(amount)
                .ClickFinishButton();
        }
    }
}