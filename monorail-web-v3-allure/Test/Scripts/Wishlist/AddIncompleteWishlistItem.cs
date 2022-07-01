using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.Menus;
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
    internal class AddIncompleteWishlistItem : FunctionalTesting
    {
        private const string IncompleteWishlistItemUrl =
            "https://www.monorail.com/blog/how-to-organize-your-finances";

        [Test(Description = "Add incomplete Wishlist item when user has Wishlist Account - each field is missing")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add incomplete Wishlist Item")]
        [AllureStory("Add incomplete Wishlist item when user has Wishlist Account- each field is missing")]
        public void AddIncompleteWishlistItemWithWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var completeYourItemInfoEntryModal = new CompleteYourItemInfoEntryModal(Driver);
            var completeYourItemInfoNameModal = new CompleteYourItemInfoNameModal(Driver);
            var completeYourItemInfoImageModal = new CompleteYourItemInfoImageModal(Driver);
            var completeYourItemInfoPriceModal = new CompleteYourItemInfoPriceModal(Driver);
            var completeYourItemInfoDescriptionModal = new CompleteYourItemInfoDescriptionModal(Driver);
            var completeYourItemInfoSuccessModal = new CompleteYourItemInfoSuccessModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+2.0317221@gmail.com";

            VerifyPlaidConnection(username);

            AddEmptyWishlistItem(username, IncompleteWishlistItemUrl);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            mainScreen
                .ExpandSideMenu();

            sideMenu
                .ClickWishlistLink();

            wishlistScreen
                .CheckWishlistScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickTapToCompleteInfoPill();

            completeYourItemInfoEntryModal
                .CheckCompleteYourItemInfoEntryModal()
                .ClickContinueButton();

            completeYourItemInfoNameModal
                .CheckCompleteYourItemInfoNameModal()
                .SetWishlistItemName(WishlistItemName)
                .ClickContinueButton();

            completeYourItemInfoImageModal
                .CheckCompleteYourItemInfoImageModal()
                .ClickFirstImageOnCarousel()
                .ClickContinueButton();

            completeYourItemInfoPriceModal
                .CheckCompleteYourItemInfoPriceModal()
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickContinueButton();

            completeYourItemInfoDescriptionModal
                .CheckCompleteYourItemInfoDescriptionModalModal()
                .SetWishlistItemDescription(WishlistItemDescription)
                .ClickContinueButton();

            completeYourItemInfoSuccessModal
                .CheckAddWishlistItemSuccessModal()
                .VerifyWishlistItemName(WishlistItemName)
                .ClickFinish();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    IncompleteWishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, wishlistItemId);
        }

        [Test(Description =
            "Add incomplete Wishlist item when user doesn't have Wishlist Account - each field is missing")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Add incomplete Wishlist Item")]
        [AllureStory("Add incomplete Wishlist item when user doesn't have Wishlist Account- each field is missing")]
        public void AddIncompleteWishlistItemWithoutWishlistAccountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var completeYourItemInfoEntryModal = new CompleteYourItemInfoEntryModal(Driver);
            var completeYourItemInfoNameModal = new CompleteYourItemInfoNameModal(Driver);
            var completeYourItemInfoImageModal = new CompleteYourItemInfoImageModal(Driver);
            var completeYourItemInfoPriceModal = new CompleteYourItemInfoPriceModal(Driver);
            var completeYourItemInfoDescriptionModal = new CompleteYourItemInfoDescriptionModal(Driver);
            var completeYourItemInfoSuccessModal = new CompleteYourItemInfoSuccessModal(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);

            const string username = "autotests.mono+2.141221@gmail.com";

            VerifyPlaidConnection(username);

            AddEmptyWishlistItem(username, IncompleteWishlistItemUrl);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            mainScreen
                .ExpandSideMenu();

            sideMenu
                .ClickWishlistLink();

            wishlistScreen
                .CheckWishlistScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding()
                .ClickTapToCompleteInfoPill();

            completeYourItemInfoEntryModal
                .CheckCompleteYourItemInfoEntryModal()
                .ClickContinueButton();

            completeYourItemInfoNameModal
                .CheckCompleteYourItemInfoNameModal()
                .SetWishlistItemName(WishlistItemName)
                .ClickContinueButton();

            completeYourItemInfoImageModal
                .CheckCompleteYourItemInfoImageModal()
                .ClickFirstImageOnCarousel()
                .ClickContinueButton();

            completeYourItemInfoPriceModal
                .CheckCompleteYourItemInfoPriceModal()
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickContinueButton();

            completeYourItemInfoDescriptionModal
                .CheckCompleteYourItemInfoDescriptionModalModal()
                .SetWishlistItemDescription(WishlistItemDescription)
                .ClickContinueButton();

            completeYourItemInfoSuccessModal
                .CheckAddWishlistItemSuccessModal()
                .VerifyWishlistItemName(WishlistItemName)
                .ClickFinish();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .VerifyWishlistItemDetails(WishlistItemName, WishlistItemDescription, WishlistItemPrice,
                    IncompleteWishlistItemUrl);

            var wishlistItemId = Driver.Url[^36..];

            DeleteWishlistItem(username, wishlistItemId);
        }
    }
}