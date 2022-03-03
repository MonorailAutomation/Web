using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Transactions
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
            var tradingMainScreen = new TradingMainScreen(Driver);
            var buyingPowerWithdrawCashModal = new BuyingPowerWithdrawCashModal(Driver);
            var buyingPowerWithdrawCashSuccessModal = new BuyingPowerWithdrawCashSuccessModal(Driver);

            const string username = "autotests.mono+8.2.310122@gmail.com";
            const string amountToWithdraw = "1";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickTrading();

            tradingMainScreen.ClickCashOutButton();

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