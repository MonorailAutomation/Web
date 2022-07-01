using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Menus;
using monorail_web_v3.PageObjects.WishlistScreens.Modals.ManageModals;
using monorail_web_v3.PageObjects.WishlistScreens.Modals.TransactionModals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Transactions.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class DepositToWishlistAccountThroughMainScreen : FunctionalTesting
    {
        private const string AmountToAdd = "2";
        private const string Username = "autotests.mono+7.5.0317221@gmail.com";

        [Test(Description = "Deposit Money to Wishlist Account from Main Wishlist Screen using 'Add Cash'")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account | Main Screen -> Add Cash")]
        public void DepositToWishlistAccountFromMainScreenTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            VerifyPlaidConnection(Username);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .ExpandSideMenu();

            sideMenu
                .ClickWishlistLink();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
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

        [Test(Description = "Deposit money to Wishlist Account through Manage Account using 'Add Cash' button")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit money to Wishlist Account | Main Screen -> Manage your Account -> Add Cash")]
        public void DepositToWishlistAccountFromManageAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            VerifyPlaidConnection(Username);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .ExpandSideMenu();

            sideMenu
                .ClickWishlistLink();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickManageButton();

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