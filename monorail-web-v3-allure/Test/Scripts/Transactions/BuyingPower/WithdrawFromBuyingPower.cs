using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.InvestScreens.StocksScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.StocksScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Transactions.BuyingPower
{
    [TestFixture]
    [AllureNUnit]
    public class WithdrawFromBuyingPower : FunctionalTesting
    {
        [Test(Description = "Withdraw money from Buying Power")]
        [AllureEpic("Transactions")]
        [AllureFeature("Buying Power")]
        [AllureStory("Withdraw money from Buying Power")]
        public void WithdrawMoneyFromBuyingPowerTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var stocksMainScreen = new StocksMainScreen(Driver);
            var buyingPowerWithdrawCashModal = new BuyingPowerWithdrawCashModal(Driver);
            var buyingPowerWithdrawCashSuccessModal = new BuyingPowerWithdrawCashSuccessModal(Driver);

            const string username = "autotests.mono+8.2.310122@gmail.com";
            const string amountToWithdraw = "1";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickStocks();

            stocksMainScreen.ClickCashOutButton();

            buyingPowerWithdrawCashModal
                .CheckBuyingPowerWithdrawCashModal()
                .SetWithdrawCashAmount(amountToWithdraw)
                .ClickConfirmButton();

            buyingPowerWithdrawCashSuccessModal
                .CheckBuyingPowerCashOutSuccessModal()
                .VerifyWithdrawnAmount(amountToWithdraw)
                .ClickReturnButton();
        }
    }
}