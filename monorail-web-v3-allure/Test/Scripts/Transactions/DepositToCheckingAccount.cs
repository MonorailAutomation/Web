using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals;
using monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class DepositToCheckingAccount : FunctionalTesting
    {
        [Test(Description = "Deposit money to Checking Account")]
        [AllureEpic("Transactions")]
        [AllureFeature("Checking Account")]
        [AllureStory("Deposit money to Checking Account")]
        public void DepositMoneyToCheckingAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var spendMainScreen = new SpendMainScreen(Driver);
            var spendAddCashModal = new SpendAddCashModal(Driver);
            var spendAddCashSuccessModal = new SpendAddCashSuccessModal(Driver);

            const string username = "autotests.mono+7.3.061121@gmail.com";
            const string amountToAdd = "10";

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
                .ClickAddCashButton();

            spendAddCashModal
                .CheckSpendAddCashModal()
                .SetAddCashAmount(amountToAdd)
                .ClickConfirmButton();

            spendAddCashSuccessModal
                .CheckSpendAddCashSuccessModal()
                .VerifyDepositedAmount(amountToAdd)
                .ClickFinishButton();
        }
    }
}