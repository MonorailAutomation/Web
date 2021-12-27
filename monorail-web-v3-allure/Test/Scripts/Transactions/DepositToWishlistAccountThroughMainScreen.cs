using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class DepositToWishlistAccountThroughMainScreen : FunctionalTesting
    {
        private const string AmountToAdd = "2";
        private const string Username = "autotests.mono+3.1.161021@gmail.com"; //replace with autotests.mono+7.5

        [Test(Description = "Deposit Money to Wishlist Account from Main Wishlist Screen using 'Add Funds'")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account | Main Screen -> Add Funds")]
        public void DepositToWishlistAccountFromMainScreenTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickAddFundsButton();

            wishlistAddCashModal
                .CheckWishlistAddCashModal()
                .SetAddCashAmount(AmountToAdd)
                .ClickConfirmButton();

            wishlistAddCashSuccessModal
                .CheckWishlistAddCashSuccessModal()
                .VerifyDepositedAmount(AmountToAdd)
                .ClickFinishButton();
        }

        [Test(Description = "Deposit money to Wishlist Account through Manage Account using 'Add Cash' button")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit money to Wishlist Account | Main Screen -> Manage your Account -> Add Cash")]
        public void DepositToWishlistAccountFromManageAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickManageYourAccountButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .ClickAddCashButton();

            wishlistAddCashModal
                .CheckWishlistAddCashModal()
                .SetAddCashAmount(AmountToAdd)
                .ClickConfirmButton();

            wishlistAddCashSuccessModal
                .CheckWishlistAddCashSuccessModal()
                .VerifyDepositedAmount(AmountToAdd)
                .ClickFinishButton();
        }
    }
}