using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_web_v3.Commons.Passwords;

namespace monorail_web_v3.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class AddWishlistItem : FunctionalTesting
    {
        [Test(Description = "Add Wishlist item by clicking placeholder")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add Wishlist Item")]
        [AllureStory("Add Wishlist Item by clicking placeholder")]
        public void AddWishlistItemByPlaceholderTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var addWishlistItemFinishModal = new AddWishlistItemSuccessModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.1.161021@gmail.com";
            const string wishlistItemName = "Canon EOS Rebel T7 EF-S 18-55mm IS II Kit";
            const string wishlistItemUrl =
                "https://www.target.com/p/canon-eos-rebel-t7-ef-s-18-55mm-is-ii-kit/-/A-54360840";
            const string wishlistItemDescription =
                "Read reviews and buy Canon EOS Rebel T7 EF-S 18-55mm IS II Kit at Target. Choose from contactless Same Day Delivery, Drive Up and more.";
            const string wishlistItemPrice = "55";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .ClickAddWishlistItemPlaceholder();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(wishlistItemUrl)
                .ClickContinueButton();

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(wishlistItemName, wishlistItemDescription, wishlistItemUrl)
                .SetWishlistItemPrice(wishlistItemPrice)
                .ClickConfirmButton();

            addWishlistItemFinishModal
                .CheckAddWishlistItemSuccessModal()
                .VerifyWishlistItemName(wishlistItemName)
                .ClickFinishButton();

            wishlistMainScreen
                .ClickWishlistItem(wishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(wishlistItemName, wishlistItemDescription, wishlistItemPrice);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        }
    }
}