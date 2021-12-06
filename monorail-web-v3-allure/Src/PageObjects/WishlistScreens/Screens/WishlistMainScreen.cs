using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Screens
{
    public class WishlistMainScreen : WishlistScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Funds')]")]
        private IWebElement _addFundsButton;

        [FindsBy(How = How.XPath,
            Using = "//main//p[contains(text(), 'Add an Item')]")]
        public IWebElement _addWishlistItemButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='wishlist-list__item'][1]//div[@class='empty-card__container']")]
        private IWebElement _addWishlistItemPlaceholder;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Manage your Account')]")]
        private IWebElement _manageYourAccountButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-page-header__title']//h1[contains(text(),'Wishlist')]")]
        private IWebElement _wishlistHeaderItem;
        
        [FindsBy(How = How.XPath,
            Using = "//button[contains(text(),'View All')]")]
        private IWebElement _viewAllButton;

        public WishlistMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if 'Wishlist' header is displayed on page")]
        public WishlistMainScreen CheckWishlistHeader()
        {
            Wait.Until(ElementToBeVisible(_wishlistHeaderItem));
            return this;
        }

        [AllureStep("Click 'Add Funds' button")]
        public WishlistMainScreen ClickAddFundsButton()
        {
            Wait.Until(ElementToBeClickable(_addFundsButton));
            _addFundsButton.Click();
            return this;
        }

        [AllureStep("Click 'Manage your Account' button")]
        public WishlistMainScreen ClickManageYourAccountButton()
        {
            Wait.Until(ElementToBeClickable(_manageYourAccountButton));
            _manageYourAccountButton.Click();
            return this;
        }

        [AllureStep("Click add Wishlist item using placeholder")]
        public WishlistMainScreen ClickAddWishlistItemPlaceholder()
        {
            Wait.Until(ElementToBeClickable(_addWishlistItemPlaceholder));
            _addWishlistItemPlaceholder.Click();
            return this;
        }

        [AllureStep("Click add Wishlist item using button")]
        public WishlistMainScreen ClickAddWishlistItemButton()
        {
            Wait.Until(ElementToBeClickable(_addWishlistItemButton));
            _addWishlistItemButton.Click();
            return this;
        }
        
        [AllureStep("Click 'View All' button")]
        public WishlistMainScreen ClickViewAllButton()
        {
            Wait.Until(ElementToBeClickable(_viewAllButton));
            _viewAllButton.Click();
            return this;
        }

        [AllureStep("Click '{0}' item")]
        public WishlistMainScreen ClickWishlistItem(string wishlistItemName)
        {
            var wishlistItemSelector = "//p[contains(text(), '" + wishlistItemName + "')]";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemSelector))).Click();
            return this;
        }

        [AllureStep("Check if item is no longer displayed in the wishlist")]
        public WishlistMainScreen CheckNoWishlistItem(string wishlistItemName)
        {
            var wishlistItemSelector = "//p[contains(text(), '" + wishlistItemName + "')]";
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(wishlistItemSelector)));
            return this;
        }
    }
}