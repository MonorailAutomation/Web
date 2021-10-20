using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.WishlistScreen;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.RestRequests.Helpers.WishlistHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class AddWishlistItem : FunctionalTesting
    {
        private const string Password = "Test123!!";

        [Test(Description = "Add Wishlist item by clicking placeholder")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add Wishlist Item")]
        [AllureStory("Add Wishlist Item by clicking placeholder")]
        public void AddWishlistItemByPlaceholderTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewItemModal = new AddNewItemModal(Driver);
            var itemDetailsModal = new ItemDetailsModal(Driver);
            var finishModal = new FinishModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.1.161021@gmail.com";
            const string wishlistItemName = "Buy iPhone 13 Pro and iPhone 13 Pro Max";
            const string wishlistItemUrl = "https://www.apple.com/shop/buy-iphone/iphone-13-pro";
            const string wishlistItemDescription =
                "Get credit toward iPhone 13 Pro and iPhone 13 Pro Max when you trade in a smartphone. Make low monthly payments at 0% APR. Buy now with free shipping.";
            const string wishlistItemPrice = "55";

            loginPage
                .PassCredentials(username, Password)
                .ClickSignInButton();

            wishlistMainScreen
                .ClickAddWishlistItemPlaceholder();

            addNewItemModal
                .PasteLink(wishlistItemUrl)
                .ClickContinueButton();

            itemDetailsModal
                .VerifyDataOnItemDetailsModal(wishlistItemName, wishlistItemDescription, wishlistItemUrl)
                .SetWishlistItemPrice(wishlistItemPrice)
                .ClickConfirmButton();

            finishModal
                .VerifyWishlistItemName(wishlistItemName)
                .ClickFinishButton();

            wishlistMainScreen
                .ClickWishlistItem(wishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(wishlistItemName, wishlistItemDescription, wishlistItemPrice);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, Password, wishlistItemId);
        }
    }
}