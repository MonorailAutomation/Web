using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
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
    internal class EditWishlistItem : FunctionalTesting
    {
        private const string ChangedItemName = "Changed Name";
        private const string ChangedItemPrice = "200";
        private const string ChangedItemDescription = "Changed Description";

        [Test(Description = "Edit Wishlist item by clicking a button when user has a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Edit Wishlist Item")]
        [AllureStory("Edit Wishlist Item when user has a wishlist account")]
        public void EditWishlistItemWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);

            const string username = "autotests.mono+1.071221@gmail.com";

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
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice)
                .ClickEditButton();

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl,
                    WishlistItemPrice)
                .EditItemName(ChangedItemName)
                .EditItemPrice(ChangedItemPrice)
                .EditItemDescription(ChangedItemDescription)
                .ClickConfirmButton();

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(ChangedItemName, ChangedItemDescription, ChangedItemPrice);

            var wishlistItemId = Driver.Url[^36..];

            UpdateWishlistItem(username, WishlistItemPrice, WishlistItemDescription, WishlistItemFavicon,
                WishlistItemImage, WishlistItemUrl, WishlistItemName, wishlistItemId);
        }

        [Test(Description = "Edit Wishlist item by clicking a button when user doesn't have a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Edit Wishlist Item")]
        [AllureStory("Edit Wishlist Item when user doesn't have a wishlist account")]
        public void EditWishlistItemWithoutWishlistAccountTest()
        {
            /*
             *  This test is affected by BUG: 40198
             */

            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);

            const string username = "autotests.mono+2.171221@gmail.com";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding()
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice)
                .ClickEditButton();

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl,
                    WishlistItemPrice)
                .EditItemName(ChangedItemName)
                .EditItemPrice(ChangedItemPrice)
                .EditItemDescription(ChangedItemDescription)
                .ClickConfirmButton();

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(ChangedItemName, ChangedItemDescription, ChangedItemPrice);

            var wishlistItemId = Driver.Url[^36..];

            UpdateWishlistItem(username, WishlistItemPrice, WishlistItemDescription, WishlistItemFavicon,
                WishlistItemImage, WishlistItemUrl, WishlistItemName, wishlistItemId);
        }
    }
}