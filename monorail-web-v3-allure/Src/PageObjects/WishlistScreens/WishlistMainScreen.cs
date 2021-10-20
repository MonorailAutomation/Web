using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.WishlistMainScreen
{
    public class WishlistMainScreen 
    {
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-page-header__title']//child::h1[contains(text(),'Wishlist')]")]
        private IWebElement _wishlistHeaderItem;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Funds')]")]
        private IWebElement _addFundsButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Manage your Account')]")]
        private IWebElement _manageYourAccountButton;
        public WishlistMainScreen(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if 'Main Wishlist Screen' is displayed")]
        public WishlistMainScreen CheckWishlistMainScreen()
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

    }
        }