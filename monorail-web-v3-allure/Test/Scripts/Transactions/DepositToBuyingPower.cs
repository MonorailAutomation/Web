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
    internal class DepositToBuyingPower : FunctionalTesting
    {
        [Test(Description = "Deposit money to Buying Power")]
        [AllureEpic("Transactions")]
        [AllureFeature("Buying Power")]
        [AllureStory("Deposit money to Buying Power")]
        public void DepositMoneyToBuyingPowerTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var tradingMainScreen = new TradingMainScreen(Driver);
            var buyingPowerAddCashModal = new BuyingPowerAddCashModal(Driver);
            var buyingPowerAddCashSuccessModal = new BuyingPowerAddCashSuccessModal(Driver);

            const string username = "autotests.mono+7.2.271021@gmail.com";
            const string amountToAdd = "1";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickTrading();

            tradingMainScreen.ClickAddCashButton();

            buyingPowerAddCashModal
                .CheckBuyingPowerAddCashModal()
                .SetAddCashAmount(amountToAdd)
                .ClickConfirmButton();

            buyingPowerAddCashSuccessModal
                .CheckBuyingPowerAddCashSuccessModal()
                .VerifyDepositedAmount(amountToAdd)
                .ClickReturnButton();
        }
    }
}