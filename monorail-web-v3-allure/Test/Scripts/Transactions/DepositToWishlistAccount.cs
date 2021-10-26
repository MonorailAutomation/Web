using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Passwords;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class DepositToWishlistAccount : FunctionalTesting
    {
        private const string WishlistAddCashAmount = "2";

        [Test(Description = "Deposit Money to Wishlist Account from Main Wishlist Screen")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account from Main Screen")]
        public void DepositToWishlistAccountFromMainScreenTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            const string username = "autotests.mono+3.1.161021@gmail.com";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .CheckWishlistHeader()
                .ClickAddFundsButton();

            wishlistAddCashModal
                .CheckWishlistAddCashModal()
                .SetWishlistAddCashAmount(WishlistAddCashAmount)
                .ClickConfirmButton();

            wishlistAddCashSuccessModal
                .CheckWishlistAddCashSuccessModal()
                .CheckForDepositAmount(WishlistAddCashAmount)
                .ClickFinishButton();
        }

        [Test(Description = "Deposit Money to Wishlist Account using Manage Account")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account using Manage Account")]
        public void DepositToWishlistAccountFromManageAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            const string username = "autotests.mono+3.1.161021@gmail.com";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .CheckWishlistHeader()
                .ClickManageYourAccountButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .ClickAddCashButton();

            wishlistAddCashModal
                .CheckWishlistAddCashModal()
                .SetWishlistAddCashAmount(WishlistAddCashAmount)
                .ClickConfirmButton();

            wishlistAddCashSuccessModal
                .CheckWishlistAddCashSuccessModal()
                .CheckForDepositAmount(WishlistAddCashAmount)
                .ClickFinishButton();
        }
    }
}