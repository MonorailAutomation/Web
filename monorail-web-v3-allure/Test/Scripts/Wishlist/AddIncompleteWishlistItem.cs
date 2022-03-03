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
    internal class AddIncompleteWishlistItem : FunctionalTesting
    {
        [Test(Description = "Add incomplete Wishlist item by clicking a button when user has a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add incomplete Wishlist Item")]
        [AllureStory("Add incomplete Wishlist Item by clicking 'Add an item' button when user has a wishlist account")]
        public void AddIncompleteWishlistItemByButtonWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemIsBeingAddedModal = new WishlistItemIsBeingAddedModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+2.071221@gmail.com"; //created

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

            wishlistItemIsBeingAddedModal
                .CheckWishlistItemIsBeingAddedModal()
                .ClickCloseButton();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickConfirmButton();

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice, WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        }

        [Test(Description = "Add incomplete Wishlist item by clicking placeholder when user has a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add incomplete Wishlist Item")]
        [AllureStory("Add incomplete Wishlist Item by clicking placeholder when user has a wishlist account")]
        public void AddIncompleteWishlistItemByPlaceholderWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemIsBeingAddedModal = new WishlistItemIsBeingAddedModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.1.161021@gmail.com"; //created

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

            wishlistItemIsBeingAddedModal
                .CheckWishlistItemIsBeingAddedModal()
                .ClickCloseButton();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickConfirmButton();

            wishlistDetailsScreen
                .CheckWishlistItemDetailsScreenForNotReadyToBuyItemStatus()
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice, WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        }

        [Test(Description =
            "Add incomplete Wishlist item by clicking a button when user doesn't have a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add incomplete Wishlist Item")]
        [AllureStory(
            "Add incomplete Wishlist Item by clicking 'Add an item' button when user doesn't have a wishlist account")]
        public void AddIncompleteWishlistItemByButtonWithoutWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemIsBeingAddedModal = new WishlistItemIsBeingAddedModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+2.141221@gmail.com"; //created

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistScreen
                .CheckWishlistScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding()
                .ClickAddWishlistItemButton();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemIsBeingAddedModal
                .CheckWishlistItemIsBeingAddedModal()
                .ClickCloseButton();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickConfirmButton();

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice, WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        }

        [Test(Description =
            "Add incomplete Wishlist item by clicking placeholder when user doesn't have a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add incomplete Wishlist Item")]
        [AllureStory("Add incomplete Wishlist Item by clicking placeholder when user doesn't have a wishlist account")]
        public void AddIncompleteWishlistItemByPlaceholderWithoutWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemIsBeingAddedModal = new WishlistItemIsBeingAddedModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.141221@gmail.com"; //created

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistScreen
                .CheckWishlistScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding()
                .ClickAddWishlistItemPlaceholder();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemIsBeingAddedModal
                .CheckWishlistItemIsBeingAddedModal()
                .ClickCloseButton();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl)
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickConfirmButton();

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice, WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, ValidPassword, wishlistItemId);
        }
    }
}