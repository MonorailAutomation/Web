using System;
using System.Collections.Generic;
using System.Data;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Screens
{
    public class WishlistViewAllScreen : WishlistScreen
    {
        [FindsBy(How = How.XPath,
            Using = "//button[contains(text(),'Add Funds')]")]
        private IWebElement _addFundsButton;

        [FindsBy(How = How.XPath,
            Using = "//button[contains(text(),'Manage your Account')]")]
        private IWebElement _manageYourAccountButton;

        [FindsBy(How = How.XPath,
            Using = "//div[contains(@class, 'rtb-only')]//vim-toggle")]
        private IWebElement _showOnlyReadyToBuySwitch;

        [FindsBy(How = How.XPath,
            Using = "//div[contains(@class, 'wishlist-list-item__details')]//p")]
        private IList<IWebElement> ListOfAllWishlistItems;

        public WishlistViewAllScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Manage your Account' button")]
        public WishlistViewAllScreen ClickManageYourAccountButton()
        {
            Wait.Until(ElementToBeVisible(_manageYourAccountButton));
            _manageYourAccountButton.Click();
            return this;
        }

        [AllureStep("Click 'Add Funds' button")]
        public WishlistViewAllScreen ClickAddFundsButton()
        {
            Wait.Until(ElementToBeClickable(_addFundsButton));
            _addFundsButton.Click();
            return this;
        }

        [AllureStep("Click 'Show Only Ready to Buy' switch")]
        public WishlistViewAllScreen ClickShowOnlyReadyToBuySwitch()
        {
            Wait.Until(ElementToBeVisible(_showOnlyReadyToBuySwitch));
            _showOnlyReadyToBuySwitch.Click();
            return this;
        }

        [AllureStep("Check Items on 'View All' screen")]
        public WishlistViewAllScreen CheckItemsOnViewAllScreen(int wishlistItemAmount, params string[] wishlistItems)
        {
            if (ListOfAllWishlistItems.Count == wishlistItemAmount)
                for (var i = 0; i < wishlistItemAmount; i++)
                {
                    var wishlistItemSelector = "//p[contains(text(), '" + wishlistItems[i] + "')]";
                    var wishlistItem = Driver.FindElement(By.XPath(wishlistItemSelector));
                    if (!ListOfAllWishlistItems.Contains(wishlistItem))
                        throw new Exception("Wishlist item was not found on the list");
                }
            else
                throw new DataException("Wishlist Item amount doesn't match expected amount");

            return this;
        }
    }
}