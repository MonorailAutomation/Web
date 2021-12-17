﻿using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class WithdrawFromWishlistAccountThroughMainScreen : FunctionalTesting
    {
        [Test(Description = "Withdraw money from Wishlist Account through Manage Account using 'Cash Out' button")]
        [AllureEpic("Transactions")]
        [AllureFeature("Wishlist")]
        [AllureStory("Withdraw money from Wishlist Account | Main Screen -> Manage your Account -> Cash Out")]
        public void WithdrawFromWishlistAccountThroughMainScreenTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var wishlistWithdrawCashModal = new WishlistWithdrawCashModal(Driver);
            var wishlistWithdrawCashSuccessModal = new WishlistWithdrawCashSuccessModal(Driver);

            const string username = "haku.vimvest+2110219@gmail.com";
            const string amountToWithdraw = "1";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .ClickManageYourAccountButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .ClickCashOutButton();

            wishlistWithdrawCashModal
                .CheckWishlistWithdrawCashModal()
                .SetWithdrawCashAmount(amountToWithdraw);

            wishlistWithdrawCashModal
                .ClickConfirmButton();

            wishlistWithdrawCashSuccessModal
                .CheckWishlistCashOutSuccessModal()
                .VerifyWithdrawnAmount(amountToWithdraw)
                .ClickFinishButton();
        }
    }
}