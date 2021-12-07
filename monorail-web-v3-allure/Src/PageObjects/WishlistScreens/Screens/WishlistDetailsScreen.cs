using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Screens
{
    public class WishlistDetailsScreen : WishlistScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Edit')]")]
        private IWebElement editButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Remove')]")]
        private IWebElement removeButton;

        public WishlistDetailsScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Remove' button")]
        public WishlistDetailsScreen ClickRemoveButton()
        {
            Wait.Until(ElementToBeClickable(removeButton));
            removeButton.Click();
            return this;
        }

        [AllureStep("Click 'Edit' button")]
        public WishlistDetailsScreen ClickEditButton()
        {
            Wait.Until(ElementToBeClickable(editButton));
            editButton.Click();
            return this;
        }

        [AllureStep("Verify if Wishlist item name is: '{0}', description is: '{1}', price is: '{2}', url is: '{3}'")]
        public WishlistDetailsScreen VerifyWishlistItemDetails(string wishlistItemName, string wishlistItemDescription,
            string wishlistItemPrice, string wishlistItemUrl)
        {
            var wishlistItemNameSelector = "//div//h2[contains(text(), '" + wishlistItemName + "')]";
            var wishlistItemDescriptionSelector = "//div//p[contains(text(), '" + wishlistItemDescription + "')]";
            var wishlistItemPriceSelector = "//div//h2[contains(text(), '" + wishlistItemPrice + "')]";
            const string wishlistItemUrlSelector = "//a[@class='wishlist-details__sidebar__logo-wrapper']";

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemNameSelector))).Text.Should()
                .Contain(wishlistItemName);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemDescriptionSelector))).Text.Should()
                .Contain(wishlistItemDescription);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemPriceSelector))).Text.Should()
                .Contain(wishlistItemPrice);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemUrlSelector))).GetAttribute("href")
                .Should().Contain(wishlistItemUrl);

            return this;
        }
    }
}