using NUnit.Allure.Steps;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Functions;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Menus
{
    public class SideMenu
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Log Out')]")]
        private IWebElement _logOutLink;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'Wishlist')]")]
        private IWebElement _wishlistLink;

        [FindsBy(How = How.XPath, Using = "//a[contains(@routerlink, 'my-connected-account')]")]
        private IWebElement _myConnectedAccountLink;

        public SideMenu(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'My Connected Account' link")]
        public SideMenu ClickMyConnectedAccountLink()
        {
            Wait.Until(ElementToBeClickable(_myConnectedAccountLink));
            _myConnectedAccountLink.Click();
            return this;
        }

        [AllureStep("Click 'Log Out' link")]
        public SideMenu ClickLogOutLink()
        {
            Wait.Until(ElementToBeClickable(_logOutLink));
            Thread.Sleep(1000);
            _logOutLink.Click();
            return this;
        }

        [AllureStep("Click 'Wishlist' link")]
        public SideMenu ClickWishlistLink()
        {
            Wait.Until(ElementToBeClickable(_wishlistLink));
            _wishlistLink.Click();
            return this;
        }
    }
}