using monorail_web_v3.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Passwords;
using monorail_web_v3.PageObjects.WishlistScreens.WishlistMainScreen;
using monorail_web_v3.PageObjects.WishlistScreens.SuccessModal;
using monorail_web_v3.PageObjects.WishlistScreens.WishlistManageAccountModal;
using monorail_web_v3.PageObjects.WishlistScreens.WishlistCashOutModal;

namespace monorail_web_v3.Test.Scripts.Transactions

{
    [TestFixture]
    [AllureNUnit]
    internal class WithdrawFromWishlist : FunctionalTesting
    {
        private const string Username = "haku.vimvest+3009211@gmail.com";
        private const string wishlistCashOutAmount = "1";

        [Test(Description = "Withdraw Money from Wishlist Account")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Withdraw from Wishlist")]
        public void WithdrawFromWishlistTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var successModal = new SuccessModal(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var wishlistCashOutModal = new WishlistCashOutModal(Driver);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .ClickManageYourAccountButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .ClickCashOutButton();

            wishlistCashOutModal
                .CheckWishlistCashOutModal()
                .SetWishlistCashOutAmount(wishlistCashOutAmount)
                .ClickConfirmButton();

            successModal
                .CheckForWithdrawalSuccess()
                .CheckForWithdrawalAmount(wishlistCashOutAmount)
                .ClickFinishButton();
        }
    }
}