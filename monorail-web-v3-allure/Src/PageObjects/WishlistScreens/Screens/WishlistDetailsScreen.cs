using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace monorail_web_v3.PageObjects.WishlistScreens.Screens
{
    public class WishlistDetailsScreen
    {
        public WishlistDetailsScreen(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Verify if Wishlist item name is: '{0}', description is: '{1}', price is: '{2}'")]
        public WishlistDetailsScreen VerifyWishlistItemDetails(string wishlistItemName, string wishlistItemDescription,
            string wishlistItemPrice)
        {
            var wishlistItemNameSelector = "//div//h2[contains(text(), '" + wishlistItemName + "')]";
            var wishlistItemDescriptionSelector = "//div//p[contains(text(), '" + wishlistItemDescription + "')]";
            var wishlistItemPriceSelector = "//div//h2[contains(text(), '" + wishlistItemPrice + "')]";

            Wait.Until(ElementIsVisible(By.XPath(wishlistItemNameSelector))).Text.Should()
                .Contain(wishlistItemName);
            Wait.Until(ElementIsVisible(By.XPath(wishlistItemDescriptionSelector))).Text.Should()
                .Contain(wishlistItemDescription);
            Wait.Until(ElementIsVisible(By.XPath(wishlistItemPriceSelector))).Text.Should()
                .Contain(wishlistItemPrice);
            return this;
        }
    }
}