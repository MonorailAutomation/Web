using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Screens;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Passwords;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    public class WithdrawFromBuyingPower : FunctionalTesting
    {
        [Test(Description = "Withdraw from Buying Power")]
        [AllureEpic("Transactions")]
        [AllureFeature("Buying Power")]
        [AllureStory("Withdraw from Buying Power")]
        public void DepositAndWithdrawBuyingPowerTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainHeader = new MainHeader(Driver);
            var investHeader = new InvestMenu(Driver);
            var tradingMainScreen = new TradingMainScreen(Driver);
            var buyingPowerCashOutModal = new BuyingPowerCashOutModal(Driver);
            var buyingPowerCashOutSuccessModal = new BuyingPowerCashOutSuccessModal(Driver);

            const string username = "mp.1.042021@vimvest.com";
            const string amountToAdd = "1";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainHeader.ClickInvest();

            investHeader.ClickTrading();

            tradingMainScreen.ClickCashOutButton();

            buyingPowerCashOutModal
                .CheckBuyingPowerCashOutModal()
                .SetBuyingPowerCashOutAmount(amountToAdd)
                .ClickConfirmButton();

            buyingPowerCashOutSuccessModal
                .CheckBuyingPowerCashOutSuccessModal()
                .VerifyWithdrawnAmount(amountToAdd)
                .ClickReturnButton();
        }
    }
}