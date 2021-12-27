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

namespace monorail_web_v3.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class AddWishlistItem : FunctionalTesting
    {
        [Test(Description = "Add Wishlist item by clicking a button when user has a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add Wishlist Item")]
        [AllureStory("Add Wishlist Item by clicking 'Add an item' button when user has a wishlist account")]
        public void AddWishlistItemByButtonWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var addWishlistItemFinishModal = new AddWishlistItemSuccessModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+2.071221@gmail.com";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistScreen
                .CheckWishlistScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickAddWishlistItemButton();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl)
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickConfirmButton();

            addWishlistItemFinishModal
                .CheckAddWishlistItemSuccessModalAfterOnboarding()
                .VerifyWishlistItemName(WishlistItemName)
                .ClickFinishButton();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        }

        [Test(Description = "Add Wishlist item by clicking placeholder when user has a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add Wishlist Item")]
        [AllureStory("Add Wishlist Item by clicking placeholder when user has a wishlist account")]
        public void AddWishlistItemByPlaceholderWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var addWishlistItemFinishModal = new AddWishlistItemSuccessModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.1.161021@gmail.com";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistScreen
                .CheckWishlistScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickAddWishlistItemPlaceholder();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl)
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickConfirmButton();

            addWishlistItemFinishModal
                .CheckAddWishlistItemSuccessModalAfterOnboarding()
                .VerifyWishlistItemName(WishlistItemName)
                .ClickFinishButton();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        }

        // [Test(Description = "Add Wishlist item by clicking a button when user doesn't have a wishlist account")]
        // [AllureEpic("Wishlist")]
        // [AllureFeature("Add Wishlist Item")]
        // [AllureStory("Add Wishlist Item by clicking 'Add an item' button when user doesn't have a wishlist account")]
        // public void AddWishlistItemByButtonWithoutWishlistAccountTest()
        // {
        //     var loginPage = new LoginPage(Driver);
        //     var mainScreen = new MainScreen(Driver);
        //     var wishlistScreen = new WishlistScreen(Driver);
        //     var wishlistMainScreen = new WishlistMainScreen(Driver);
        //     var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
        //     var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
        //     var addWishlistItemFinishModal = new AddWishlistItemSuccessModal(Driver);
        //     var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
        //
        //     const string username = "autotests.mono+2.141221@gmail.com";
        //
        //     loginPage
        //         .PassCredentials(username, ValidPassword)
        //         .ClickSignInButton();
        //
        //     mainScreen
        //         .CheckMainScreen();
        //
        //     wishlistScreen
        //         .CheckWishlistScreen();
        //
        //     wishlistMainScreen
        //         .CheckWishlistCreateAccountButton()
        //         .ClickAddWishlistItemButton();
        //
        //     addNewWishlistItemModal
        //         .CheckAddNewItemModal()
        //         .PasteLink(WishlistItemUrl)
        //         .ClickContinueButton();
        //
        //     wishlistItemDetailsModal
        //         .CheckItemDetailsModal()
        //         .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl)
        //         .SetWishlistItemPrice(WishlistItemPrice)
        //         .ClickConfirmButton();
        //
        //     addWishlistItemFinishModal
        //         .CheckAddWishlistItemSuccessModalBeforeOnboarding()
        //         .VerifyWishlistItemName(WishlistItemName)
        //         .ClickFinishButton();
        //
        //     wishlistMainScreen
        //         .ClickWishlistItem(WishlistItemName);
        //
        //     wishlistDetailsScreen
        //         .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
        //             WishlistItemUrl);
        //
        //     var wishlistItemId = Driver.Url[^36..];
        //
        //     DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        // }

        // [Test(Description = "Add Wishlist item by clicking placeholder when user doesn't have a wishlist account")]
        // [AllureEpic("Wishlist")]
        // [AllureFeature("Add Wishlist Item")]
        // [AllureStory("Add Wishlist Item by clicking placeholder when user doesn't have a wishlist account")]
        // public void AddWishlistItemByPlaceholderWithoutWishlistAccountTest()
        // {
        //     var loginPage = new LoginPage(Driver);
        //     var mainScreen = new MainScreen(Driver);
        //     var wishlistScreen = new WishlistScreen(Driver);
        //     var wishlistMainScreen = new WishlistMainScreen(Driver);
        //     var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
        //     var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
        //     var addWishlistItemFinishModal = new AddWishlistItemSuccessModal(Driver);
        //     var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
        //
        //     const string username = "autotests.mono+3.141221@gmail.com";
        //
        //     loginPage
        //         .PassCredentials(username, ValidPassword)
        //         .ClickSignInButton();
        //
        //     mainScreen
        //         .CheckMainScreen();
        //
        //     wishlistScreen
        //         .CheckWishlistScreen();
        //
        //     wishlistMainScreen
        //         .CheckWishlistCreateAccountButton()
        //         .ClickAddWishlistItemPlaceholder();
        //
        //     addNewWishlistItemModal
        //         .CheckAddNewItemModal()
        //         .PasteLink(WishlistItemUrl)
        //         .ClickContinueButton();
        //
        //     wishlistItemDetailsModal
        //         .CheckItemDetailsModal()
        //         .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl)
        //         .SetWishlistItemPrice(WishlistItemPrice)
        //         .ClickConfirmButton();
        //
        //     addWishlistItemFinishModal
        //         .CheckAddWishlistItemSuccessModalAfterOnboarding()
        //         .VerifyWishlistItemName(WishlistItemName)
        //         .ClickFinishButton();
        //
        //     wishlistMainScreen
        //         .ClickWishlistItem(WishlistItemName);
        //
        //     wishlistDetailsScreen
        //         .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
        //             WishlistItemUrl);
        //
        //     var wishlistItemId = Driver.Url[^36..];
        //
        //     DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        // }
    }
}