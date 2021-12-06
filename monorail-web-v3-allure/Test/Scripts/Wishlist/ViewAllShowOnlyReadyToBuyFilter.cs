using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class ViewAllShowOnlyReadyToBuyFilter : FunctionalTesting
    {
        [Test(Description = "Apply 'Ready to Buy' filter on 'View All' screen")]
        [AllureEpic("Wishlist")]
        [AllureFeature("View All")]
        [AllureStory("Apply 'Ready to Buy' filter on 'View All' screen")]
        public void ApplyReadyToBuyFilterOnViewAllScreenTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistViewAllScreen = new WishlistViewAllScreen(Driver);

            const string username = "haku.vimvest+28102116@gmail.com";
            //TO DO: replace with as funds appear on account autotests.mono+21.051221@gmail.com

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen();

            wishlistMainScreen
                .ClickViewAllButton();

            wishlistViewAllScreen
                .ClickShowOnlyReadyToBuySwitch()
                .CheckItemsOnViewAllScreen(2, "Item 3", "Item 4");
        }
    }
}