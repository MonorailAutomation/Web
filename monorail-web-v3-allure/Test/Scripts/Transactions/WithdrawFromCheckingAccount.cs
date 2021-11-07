using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    public class WithdrawFromCheckingAccount : FunctionalTesting
    {
        [Test(Description = "Withdraw money to Checking Account")]
        [AllureEpic("Transactions")]
        [AllureFeature("Checking Account")]
        [AllureStory("Withdraw money to Checking Account")]
        public void WithdrawMoneyFromCheckingAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var spendMainScreen = new SpendMainScreen(Driver);
            var spendWithdrawCashModal = new SpendWithdrawCashModal(Driver);
            var spendWithdrawCashSuccessModal = new SpendWithdrawCashSuccessModal(Driver);

            const string
                username = "vimvestt+5033@gmail.com"; //should be replaced with autotests.mono+8.3.061121@gmail.com soon
            const string amountToWithdraw = "1";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickMoney();

            moneyScreen
                .CheckMoneyScreen()
                .ClickSpend();

            spendMainScreen
                .ClickCashOutButton();

            spendWithdrawCashModal
                .CheckSpendWithdrawCashModal()
                .SetWithdrawCashAmount(amountToWithdraw);

            spendWithdrawCashModal
                .ClickConfirmButton();

            spendWithdrawCashSuccessModal
                .CheckSpendCashOutSuccessModal()
                .VerifyWithdrawnAmount(amountToWithdraw)
                .ClickFinishButton();
        }
    }
}