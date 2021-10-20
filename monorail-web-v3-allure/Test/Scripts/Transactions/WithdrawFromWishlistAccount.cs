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
    internal class WithdrawFromWishlistAccount : FunctionalTesting
    {
        [Test(Description = "Withdraw money from Wishlist Account")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Withdraw money from Wishlist")]
        public void WithdrawMoneyFromWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistCashOutSuccessModal = new WishlistCashOutSuccessModal(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var wishlistCashOutModal = new WishlistCashOutModal(Driver);

            const string username = "autotests.mono+3.1.161021@gmail.com";
            const string wishlistCashOutAmount = "1";

            loginPage
                .PassCredentials(username, ValidPassword)
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

            wishlistCashOutSuccessModal
                .CheckWishlistCashOutSuccessModal()
                .CheckForWithdrawnAmount(wishlistCashOutAmount)
                .ClickFinishButton();
        }
    }
}