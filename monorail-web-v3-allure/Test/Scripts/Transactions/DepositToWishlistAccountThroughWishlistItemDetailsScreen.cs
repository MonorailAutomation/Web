using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class DepositToWishlistAccountThroughWishlistItemDetailsScreen : FunctionalTesting
    {
        [Test(Description =
            "Deposit Money to Wishlist Account from Wishlist Item Details screen using 'Fund your Wishlist' button")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Deposit to Wishlist Account | Wishlist Item Details Screen -> Fund your Wishlist")]
        public void DepositToWishlistAccountThroughWishlistItemDetailsScreenTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistAddCashSuccessModal = new WishlistAddCashSuccessModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+7.5.091221@gmail.com";
            const string amountToAdd = "1";
            const string wishlistItemName = "LEGO Marvel Avengers";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickWishlistItem(wishlistItemName);

            wishlistDetailsScreen
                .ClickFundYourWishlistButton();

            wishlistAddCashModal
                .CheckWishlistAddCashModal()
                .SetAddCashAmount(amountToAdd)
                .ClickConfirmButton();

            wishlistAddCashSuccessModal
                .CheckWishlistAddCashSuccessModal()
                .VerifyDepositedAmount(amountToAdd)
                .ClickFinishButton();
        }
    }
}