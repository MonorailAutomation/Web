using System;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons
{
    public class MainScreen
    {
        [FindsBy(How = How.XPath,
            Using = "//button[@class='vim-header__sidenav-toggle']/svg-icon[contains(@src, 'menu')]")]
        private IWebElement _hamburgerMenu;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Invest')]")]
        private IWebElement _investNavItem;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Money')]")]
        private IWebElement _moneyNavItem;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Wishlist')]")]
        private IWebElement _wishlistNavItem;

        public MainScreen(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Expand side menu")]
        public MainScreen ExpandSideMenu()
        {
            Wait.Until(ElementToBeClickable(_hamburgerMenu));
            _hamburgerMenu.Click();
            return this;
        }

        [AllureStep("Click 'Invest'")]
        public MainScreen ClickInvest()
        {
            Wait.Until(ElementToBeClickable(_investNavItem));
            _investNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Money'")]
        public MainScreen ClickMoney()
        {
            Wait.Until(ElementToBeClickable(_moneyNavItem));
            _moneyNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Wishlist'")]
        public MainScreen ClickWishlist()
        {
            Wait.Until(ElementToBeClickable(_wishlistNavItem));
            _wishlistNavItem.Click();
            return this;
        }

        [AllureStep("Check Main Screen")]
        public MainScreen CheckMainScreen()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_wishlistNavItem));
                Wait.Until(ElementToBeVisible(_moneyNavItem));
                Wait.Until(ElementToBeVisible(_investNavItem));
                Wait.Until(ElementToBeVisible(_hamburgerMenu));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}