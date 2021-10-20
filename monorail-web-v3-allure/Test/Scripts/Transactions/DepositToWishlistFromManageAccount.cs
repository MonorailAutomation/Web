using monorail_web_v3.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Passwords;
using monorail_web_v3.PageObjects.WishlistScreens.WishlistMainScreen;
using monorail_web_v3.PageObjects.WishlistScreens.WishlistAddCashModal;
using monorail_web_v3.PageObjects.WishlistScreens.SuccessModal;
using monorail_web_v3.PageObjects.WishlistScreens.WishlistManageAccountModal;

namespace monorail_web_v3.Test.Scripts.Transactions

{
    [TestFixture]
    [AllureNUnit]
    internal class DepositToWishlistFromManageAccount : FunctionalTesting
    {
        private const string Username = "haku.vimvest+3009211@gmail.com";
        private const string wishlistAddCashAmount = "1";

        [Test(Description = "Deposit Money to Wishlist Account Using Manage Account")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist using Manage Account")]
        public void DepositToWishlistFromManageAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var successModal = new SuccessModal(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .CheckWishlistMainScreen()
                .ClickManageYourAccountButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .ClickAddCashButton();

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