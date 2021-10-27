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
    internal class DepositToBuyingPower : FunctionalTesting
    {
        [Test(Description = "Deposit to Buying Power")]
        [AllureEpic("Transactions")]
        [AllureFeature("Buying Power")]
        [AllureStory("Deposit to Buying Power")]
        public void DepositAndWithdrawBuyingPowerTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainHeader = new MainHeader(Driver);
            var investHeader = new InvestMenu(Driver);
            var tradingMainScreen = new TradingMainScreen(Driver);
            var buyingPowerAddCashModal = new BuyingPowerAddCashModal(Driver);
            var buyingPowerAddCashSuccessModal = new BuyingPowerAddCashSuccessModal(Driver);

            const string username = "mp.1.042021@vimvest.com";
            const string amountToAdd = "1";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainHeader.ClickInvest();

            investHeader.ClickTrading();

            tradingMainScreen.ClickAddCashButton();

            buyingPowerAddCashModal
                .CheckBuyingPowerAddCashModal()
                .SetBuyingPowerAddCashAmount(amountToAdd)
                .ClickConfirmButton();

            buyingPowerAddCashSuccessModal
                .CheckBuyingPowerAddCashSuccessModal()
                .VerifyAddedAmount(amountToAdd)
                .ClickReturnButton();
        }
    }
}