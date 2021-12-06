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
    internal class DepositToWishlistAccountThroughViewAllScreen : FunctionalTesting
    {
        private const string AmountToAdd = "2";
        private const string Username = "autotests.mono+7.5.061221@gmail.com";

        [Test(Description = "Deposit Money to Wishlist Account through 'View All' screen using 'Add Funds' button")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account | View All -> Add Funds")]
        public void DepositToWishlistAccountThroughViewAllScreenUsingAddFundsButtonTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistViewAllScreen = new WishlistViewAllScreen(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistHeader()
                .ClickViewAllButton();

            wishlistViewAllScreen
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

        [Test(Description =
            "Deposit Money to Wishlist Account through 'View All' screen using 'Add Cash' on 'Manage your Account' modal")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account | View All -> Manage your Account -> Add Cash")]
        public void DepositToWishlistAccountThroughViewAllScreenUsingAddCashOnManageYourAccountModalTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistViewAllScreen = new WishlistViewAllScreen(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistHeader()
                .ClickViewAllButton();

            wishlistViewAllScreen
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