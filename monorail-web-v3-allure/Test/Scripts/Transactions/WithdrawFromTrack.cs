using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class WithdrawFromTrack : FunctionalTesting
    {
        [Test(Description = "Withdraw from Track")]
        [AllureEpic("Transactions")]
        [AllureFeature("Save")]
        [AllureStory("Withdraw from Track")]
        public void WithdrawFromTrackTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var saveMainScreen = new SaveMainScreen(Driver);
            var trackDetailsScreen = new TrackDetailsScreen(Driver);
            var trackWithdrawCashModal = new TrackWithdrawCashModal(Driver);
            var trackWithdrawCashSuccessModal = new TrackWithdrawCashSuccessModal(Driver);

            const string username = "autotests.mono+8.4.030322@gmail.com";
            const string trackName = "Big Purchase";
            const string amount = "1";

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
                .ClickWithdrawButton();

            trackWithdrawCashModal
                .CheckTrackWithdrawCashModal()
                .SetWithdrawCashAmount(amount);

            trackWithdrawCashModal
                .ClickConfirmButton();

            trackWithdrawCashSuccessModal
                .CheckTrackWithdrawSuccessModal()
                .ClickFinishButton();
        }
    }
}