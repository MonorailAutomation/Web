using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class EditWishlistItem : FunctionalTesting
    {
        private const string WishlistItemName = "Canon EOS Rebel T7 EF-S 18-55mm IS II Kit";

        private const string WishlistItemUrl =
            "https://www.target.com/p/canon-eos-rebel-t7-ef-s-18-55mm-is-ii-kit/-/A-54360840";

        private const string WishlistItemImage =
            "http://res.cloudinary.com/vimvest/image/upload/v1638872284/bwoewueguczgkumwg6kl.jpg";

        private const string WishlistItemFavicon =
            "http://res.cloudinary.com/vimvest/image/upload/v1638879350/frwhkhmtv3oszhm0hfrs.jpg";

        private const string WishlistItemDescription =
            "Read reviews and buy Canon EOS Rebel T7 EF-S 18-55mm IS II Kit at Target. Choose from contactless Same Day Delivery, Drive Up and more.";

        private const string WishlistItemPrice = "100";

        [Test(Description = "Edit Wishlist item by clicking a button")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Edit Wishlist Item")]
        [AllureStory("Edit Wishlist Item by clicking 'Edit' button")]
        public void EditWishlistItemTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);

            const string username = "autotests.mono+1.071221@gmail.com";

            const string changedItemName = "Changed Name";
            const string changedItemUrl =
                "https://www.target.com/p/canon-eos-rebel-t7-ef-s-18-55mm-is-ii-kit/-/A-changed";
            const string changedItemPrice = "200";
            const string changedItemDescription = "Changed Description";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl)
                .ClickEditButton();

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl,
                    WishlistItemPrice)
                .EditItemName(changedItemName)
                .EditItemUrl(changedItemUrl)
                .EditItemPrice(changedItemPrice)
                .EditItemDescription(changedItemDescription)
                .ClickConfirmButton();

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(changedItemName, changedItemDescription, changedItemPrice, changedItemUrl);

            var wishlistItemId = Driver.Url[^36..];
            RevertWishlistItem(username, ValidPassword, WishlistItemPrice, WishlistItemDescription, WishlistItemFavicon,
                WishlistItemImage, WishlistItemUrl, WishlistItemName, wishlistItemId);
        }
    }
}