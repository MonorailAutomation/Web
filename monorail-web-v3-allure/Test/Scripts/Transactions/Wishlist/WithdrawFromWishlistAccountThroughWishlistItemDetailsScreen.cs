using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.WishlistScreens.Modals.TransactionModals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_web_v3.DataGenerator.StringGenerator;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Transactions.Wishlist
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
            "Withdraw money (internal) from Wishlist Account using 'Ready to Buy' button on 'Wishlist Item Details' screen")]
        public void WithdrawFromWishlistAccountThroughWishlistItemDetailsScreenInternalTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
            var transferYourFunds = new TransferYourFunds(Driver);
            var transferringSuccessModal = new TransferringSuccessModal(Driver);

            const string username = "autotests.mono+7.5.040121@gmail.com";

            var wishlistItemName = "Test Item " + GenerateStringWithNumber();

            AddPersonalizedWishlistItem(username, WishlistItemUrl, wishlistItemName, WishlistItemDescription,
                WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
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
                .CheckWishlistItemDetailsScreenForInternalPurchaseItemStatus(WishlistItemPrice)
                .ClickBackButton();

            wishlistMainScreen
                .CheckStatusForItem(wishlistItemName, "Purchase Item");
        }

        [Test(Description =
            "Withdraw money (external) from Wishlist Account using 'Ready to Buy' button on 'Wishlist Item Details' screen")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory(
            "Withdraw money (external) from Wishlist Account using 'Ready to Buy' button on 'Wishlist Item Details' screen")]
        public void WithdrawFromWishlistAccountThroughWishlistItemDetailsScreenExternalTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
            var transferYourFunds = new TransferYourFunds(Driver);
            var transferringSuccessModal = new TransferringSuccessModal(Driver);

            const string username = "autotests.mono+8.5.040121@gmail.com";

            var wishlistItemName = "Test Item " + GenerateStringWithNumber();

            AddPersonalizedWishlistItem(username, WishlistItemUrl, wishlistItemName, WishlistItemDescription,
                WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding()
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
                .CheckWishlistItemDetailsScreenForExternalFundsTransferringStatus(WishlistItemPrice)
                .ClickBackButton();

            wishlistMainScreen
                .CheckStatusForItem(wishlistItemName, "Funds Transferring");
        }
    }
}