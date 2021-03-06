using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.WishlistScreens.Modals.ItemModals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class RemoveWishlistItem : FunctionalTesting
    {
        [Test(Description = "Remove Wishlist item by clicking a button when user has a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Remove Wishlist Item")]
        [AllureStory("Remove Wishlist Item when user has a Wishlist account")]
        public void RemoveWishlistItemWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var removeWishlistItemModal = new RemoveWishlistItemModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.1.0317221@gmail.com";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistScreen
                .CheckWishlistScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl)
                .ClickRemoveButton();

            removeWishlistItemModal
                .CheckRemoveItemModal()
                .ClickRemoveButton();

            wishlistMainScreen.CheckNoWishlistItem(WishlistItemName);

            AddPersonalizedWishlistItem(username, WishlistItemUrl, WishlistItemName, WishlistItemDescription,
                WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);
        }

        [Test(Description = "Remove Wishlist item by clicking a button when user doesn't have a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Remove Wishlist Item")]
        [AllureStory("Remove Wishlist Item when user doesn't have a wishlist account")]
        public void RemoveWishlistItemWithoutWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var removeWishlistItemModal = new RemoveWishlistItemModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+1.171221@gmail.com";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistScreen
                .CheckWishlistScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding()
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl)
                .ClickRemoveButton();

            removeWishlistItemModal
                .CheckRemoveItemModal()
                .ClickRemoveButton();

            wishlistMainScreen.CheckNoWishlistItem(WishlistItemName);

            AddPersonalizedWishlistItem(username, WishlistItemUrl, WishlistItemName, WishlistItemDescription,
                WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);
        }
    }
}