using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreen
{
    public class WishlistMainScreen
    {
        [FindsBy(How = How.XPath,
            Using = "//div[@class='wishlist-list__item'][1]//div[@class='empty-card__container']")]
        private IWebElement _addWishlistItemPlaceholder;

        public WishlistMainScreen(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click add Wishlist item placeholder")]
        public WishlistMainScreen ClickAddWishlistItemPlaceholder()
        {
            Wait.Until(ElementToBeClickable(_addWishlistItemPlaceholder));
            _addWishlistItemPlaceholder.Click();
            return this;
        }

        [AllureStep("Click '{0}' item")]
        public WishlistMainScreen ClickWishlistItem(string wishlistItemName)
        {
            var wishlistItemSelector = "//p[contains(text(), '" + wishlistItemName + "')]";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemSelector))).Click();
            return this;
        }
    }
}