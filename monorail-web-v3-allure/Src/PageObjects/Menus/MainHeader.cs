using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Menus
{
    public class MainHeader
    {
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Invest')]")]
        private IWebElement _investNavItem;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Money')]")]
        private IWebElement _moneyNavItem;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Wishlist')]")]
        private IWebElement _wishlistNavItem;

        public MainHeader(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Invest'")]
        public MainHeader ClickInvest()
        {
            Wait.Until(ElementToBeClickable(_investNavItem));
            _investNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Money'")]
        public MainHeader ClickMoney()
        {
            Wait.Until(ElementToBeClickable(_moneyNavItem));
            _moneyNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Wishlist'")]
        public MainHeader ClickWishlist()
        {
            Wait.Until(ElementToBeClickable(_wishlistNavItem));
            _wishlistNavItem.Click();
            return this;
        }
    }
}