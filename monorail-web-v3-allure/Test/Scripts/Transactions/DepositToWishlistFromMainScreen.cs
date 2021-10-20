using monorail_web_v3.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Passwords;
using monorail_web_v3.PageObjects.WishlistScreens.WishlistMainScreen;
using monorail_web_v3.PageObjects.WishlistScreens.WishlistAddCashModal;
using monorail_web_v3.PageObjects.WishlistScreens.SuccessModal;

namespace monorail_web_v3.Test.Scripts.Transactions

{
    [TestFixture]
    [AllureNUnit]
    internal class DepositToWishlistFromMainScreen : FunctionalTesting
    {
        private const string Username = "haku.vimvest+3009211@gmail.com";
        private const string wishlistAddCashAmount = "1";

        [Test(Description = "Deposit Money to Wishlist Account From Main Wishlist Screen")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist from Main Screen")]
        public void DepositToWishlistFromMainScreenTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var successModal = new SuccessModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .CheckWishlistMainScreen()
                .ClickAddFundsButton();

            wishlistAddCashModal
                .CheckWishlistAddCashModal()
                .SetWishlistAddCashAmount(wishlistAddCashAmount)
                .ClickConfirmButton();

            successModal
                .CheckForDepositSuccess()
                .CheckForDepositAmount(wishlistAddCashAmount)
                .ClickFinishButton();

        }
    }
}