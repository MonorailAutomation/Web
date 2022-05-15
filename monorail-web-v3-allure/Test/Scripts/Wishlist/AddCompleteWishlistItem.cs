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
    [TestFixture, AllureNUnit]
    internal class AddCompleteWishlistItem : FunctionalTesting
    {
        private const string WishlistItemUrl =
            "https://www.amazon.com/Sceptre-E248W-19203R-Monitor-Speakers-Metallic/dp/B0773ZY26F/ref=lp_16225007011_1_4";

        private const string WishlistItemName = "Sceptre 24\" Professional";
        private const string WishlistItemPrice = "$1";
        private const string WishlistItemDescription = "24\" Ultra slim profile";

        [Test(Description = "Add complete Wishlist item by clicking a button when user has a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add complete Wishlist Item")]
        [AllureStory("Add complete Wishlist Item by clicking 'Add an item' button when user has a wishlist account")]
        public void AddCompleteWishlistItemByButtonWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemIsBeingAddedModal = new WishlistItemIsBeingAddedModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+2.310122@gmail.com";

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
                .ClickAddWishlistItemButton();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemIsBeingAddedModal
                .CheckWishlistItemIsBeingAddedModal()
                .ClickCloseButton();

            wishlistMainScreen
                .ClickLetsGoButton()
                .CheckItemBeingAddedBarDisappeared()
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, wishlistItemId);
        }

        [Test(Description = "Add complete Wishlist item by clicking placeholder when user has a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add complete Wishlist Item")]
        [AllureStory("Add complete Wishlist Item by clicking placeholder when user has a wishlist account")]
        public void AddCompleteWishlistItemByPlaceholderWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemIsBeingAddedModal = new WishlistItemIsBeingAddedModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.1.031722@gmail.com";

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
                .ClickAddWishlistItemPlaceholder();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemIsBeingAddedModal
                .CheckWishlistItemIsBeingAddedModal()
                .ClickCloseButton();

            wishlistMainScreen
                .ClickLetsGoButton()
                .CheckItemBeingAddedBarDisappeared()
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .CheckWishlistItemDetailsScreenForNotReadyToBuyItemStatus()
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, wishlistItemId);
        }

        [Test(Description =
            "Add complete Wishlist item by clicking a button when user doesn't have a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add complete Wishlist Item")]
        [AllureStory(
            "Add complete Wishlist Item by clicking 'Add an item' button when user doesn't have a wishlist account")]
        public void AddCompleteWishlistItemByButtonWithoutWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemIsBeingAddedModal = new WishlistItemIsBeingAddedModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+2.010222@gmail.com";

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
                .ClickAddWishlistItemButton();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemIsBeingAddedModal
                .CheckWishlistItemIsBeingAddedModal()
                .ClickCloseButton();

            wishlistMainScreen
                .ClickLetsGoButton()
                .CheckItemBeingAddedBarDisappeared()
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, wishlistItemId);
        }

        [Test(Description =
            "Add complete Wishlist item by clicking placeholder when user doesn't have a wishlist account")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add complete Wishlist Item")]
        [AllureStory("Add complete Wishlist Item by clicking placeholder when user doesn't have a wishlist account")]
        public void AddCompleteWishlistItemByPlaceholderWithoutWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemIsBeingAddedModal = new WishlistItemIsBeingAddedModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+3.010222@gmail.com";

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
                .ClickAddWishlistItemPlaceholder();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemIsBeingAddedModal
                .CheckWishlistItemIsBeingAddedModal()
                .ClickCloseButton();

            wishlistMainScreen
                .ClickLetsGoButton()
                .CheckItemBeingAddedBarDisappeared()
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    WishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, wishlistItemId);
        }
    }
}