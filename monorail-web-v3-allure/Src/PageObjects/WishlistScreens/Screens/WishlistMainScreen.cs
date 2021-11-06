﻿using monorail_web_v3.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace monorail_web_v3.PageObjects.WishlistScreens.Screens
{
    public class WishlistMainScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Funds')]")]
        private IWebElement _addFundsButton;

        [FindsBy(How = How.XPath,
            Using = "//main//p[contains(text(), 'Add an Item')]")]
        private IWebElement _addWishlistItemButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='wishlist-list__item'][1]//div[@class='empty-card__container']")]
        private IWebElement _addWishlistItemPlaceholder;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Manage your Account')]")]
        private IWebElement _manageYourAccountButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-page-header__title']//h1[contains(text(),'Wishlist')]")]
        private IWebElement _wishlistHeaderItem;

        public WishlistMainScreen(IWebDriver driver)
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
            Wait.Until(Waits.ElementToBeClickable(_addFundsButton));
            _addFundsButton.Click();
            return this;
        }

        [AllureStep("Click 'Manage your Account' button")]
        public WishlistMainScreen ClickManageYourAccountButton()
        {
            Wait.Until(Waits.ElementToBeClickable(_manageYourAccountButton));
            _manageYourAccountButton.Click();
            return this;
        }

        [AllureStep("Click add Wishlist item using placeholder")]
        public WishlistMainScreen ClickAddWishlistItemPlaceholder()
        {
            Wait.Until(Waits.ElementToBeClickable(_addWishlistItemPlaceholder));
            _addWishlistItemPlaceholder.Click();
            return this;
        }

        [AllureStep("Click add Wishlist item using button")]
        public WishlistMainScreen ClickAddWishlistItemButton()
        {
            Wait.Until(Waits.ElementToBeClickable(_addWishlistItemButton));
            _addWishlistItemButton.Click();
            return this;
        }

        [AllureStep("Click '{0}' item")]
        public WishlistMainScreen ClickWishlistItem(string wishlistItemName)
        {
            var wishlistItemSelector = "//p[contains(text(), '" + wishlistItemName + "')]";
            Wait.Until(ElementIsVisible(By.XPath(wishlistItemSelector))).Click();
            return this;
        }
    }
}