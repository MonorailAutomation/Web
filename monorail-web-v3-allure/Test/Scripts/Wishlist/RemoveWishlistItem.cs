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
    internal class RemoveWishlistItem : FunctionalTesting
    {
        private const string WishlistItemName = "Canon EOS Rebel T7 EF-S 18-55mm IS II Kit";

        private const string WishlistItemUrl =
            "https://www.target.com/p/canon-eos-rebel-t7-ef-s-18-55mm-is-ii-kit/-/A-54360840";

        private const string WishlistItemImage =
            "http://res.cloudinary.com/vimvest/image/upload/v1637933870/f0nhrup1mm6dkoorejhn.jpg";

        private const string WishlistItemFavicon =
            "http://res.cloudinary.com/vimvest/image/upload/v1637933870/fm6sqbztwbqql1gpmmot.jpg";

        private const string WishlistItemDescription =
            "Read reviews and buy Canon EOS Rebel T7 EF-S 18-55mm IS II Kit at Target. Choose from contactless Same Day Delivery, Drive Up and more.";

        private const string WishlistItemPrice = "100";

        [Test(Description = "Remove Wishlist item by clicking a button")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Remove Wishlist Item")]
        [AllureStory("Remove Wishlist Item by clicking 'Remove' button")]
        public void RemoveWishlistItemTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var removeWishlistItemModal = new RemoveWishlistItemModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.1.0711211@gmail.com";

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
                .ClickRemoveButton();

            removeWishlistItemModal
                .CheckRemoveItemModal()
                .ClickRemoveButton();

            wishlistMainScreen.CheckNoWishlistItem(WishlistItemName);

            AddWishlistItem(username, ValidPassword, WishlistItemPrice, WishlistItemDescription, WishlistItemFavicon,
                WishlistItemImage, WishlistItemUrl, WishlistItemName);
        }
    }
}