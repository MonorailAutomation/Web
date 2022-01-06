using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_web_v3.Commons.RandomGenerator;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class WithdrawFromWishlistAccountThroughWishlistItemDetailsScreen : FunctionalTesting
    {
        [Test(Description =
            "Withdraw money (internal) from Wishlist Account using 'Ready to Buy' button on 'Wishlist Item Details' screen")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory(
            "Withdraw money from Wishlist Account | View All -> Wishlist Item Details -> Ready to Buy (internal)")]
        public void WithdrawFromWishlistAccountThroughWishlistItemDetailsScreenInternalTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistViewAllScreen = new WishlistViewAllScreen(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
            var transferYourFunds = new TransferYourFunds(Driver);
            var transferringSuccessModal = new TransferringSuccessModal(Driver);

            const string username = "haku.vimvest+2712211@gmail.com";
            //TO DO: replace with as funds appear on account autotests.mono+7.5.040121@gmail.com

            var wishlistItemName = "Test Item " + GenerateRandomString();

            AddWishlistItem(username, ValidPassword, WishlistItemPrice, WishlistItemDescription, WishlistItemFavicon,
                WishlistItemImage, WishlistItemUrl, wishlistItemName);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickViewAllButton();

            wishlistViewAllScreen
                .ClickShowOnlyReadyToBuySwitch()
                .CheckStatusForItem(wishlistItemName, "Ready to Buy")
                .ClickWishlistItem(wishlistItemName);

            wishlistDetailsScreen
                .ClickReadyToBuyButton();

            transferYourFunds
                .CheckTransferYourFundsModal()
                .ClickMonorailSpendingCardOption()
                .ClickContinueButton();

            transferringSuccessModal
                .CheckTransferringModal()
                .ClickFinishButton();

            wishlistDetailsScreen
                .ExpandTransferringStatus()
                .CheckWishlistItemDetailsScreenForInternalPurchaseItemStatus(WishlistItemPrice)
                .ClickBackButton();

            wishlistViewAllScreen
                .ClickShowOnlyReadyToBuySwitch()
                .CheckStatusForItem(wishlistItemName, "Purchase Item");
        }

        [Test(Description =
            "Withdraw money (external) from Wishlist Account using 'Ready to Buy' button on 'Wishlist Item Details' screen")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory(
            "Withdraw money from Wishlist Account | View All -> Wishlist Item Details -> Ready to Buy (external)")]
        public void WithdrawFromWishlistAccountThroughWishlistItemDetailsScreenExternalTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistViewAllScreen = new WishlistViewAllScreen(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
            var transferYourFunds = new TransferYourFunds(Driver);
            var transferringSuccessModal = new TransferringSuccessModal(Driver);

            const string username = "haku.vimvest+2712211@gmail.com";
            //TO DO: replace with as funds appear on account autotests.mono+8.5.040121@gmail.com

            var wishlistItemName = "Test Item " + GenerateRandomString();

            AddWishlistItem(username, ValidPassword, WishlistItemPrice, WishlistItemDescription, WishlistItemFavicon,
                WishlistItemImage, WishlistItemUrl, wishlistItemName);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
                .ClickViewAllButton();

            wishlistViewAllScreen
                .ClickShowOnlyReadyToBuySwitch()
                .CheckStatusForItem(wishlistItemName, "Ready to Buy")
                .ClickWishlistItem(wishlistItemName);

            wishlistDetailsScreen
                .ClickReadyToBuyButton();

            transferYourFunds
                .CheckTransferYourFundsModal()
                .ClickExternalBankAccountOption()
                .ClickContinueButton();

            transferringSuccessModal
                .CheckTransferringModal()
                .ClickFinishButton();

            wishlistDetailsScreen
                .ExpandTransferringStatus()
                .CheckWishlistItemDetailsScreenForExternalFundsTransferringStatus(WishlistItemPrice)
                .ClickBackButton();

            wishlistViewAllScreen
                .ClickShowOnlyReadyToBuySwitch()
                .CheckStatusForItem(wishlistItemName, "Funds Transferring");
        }
    }
}