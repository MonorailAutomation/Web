using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Menus
{
    public class SideMenu
    {
        [FindsBy(How = How.XPath,
            Using = "//button[@class='vim-header__sidenav-toggle']/svg-icon[contains(@src, 'menu')]")]
        private IWebElement HamburgerMenu;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Log Out')]")]
        private IWebElement LogOutButton;

        public SideMenu(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Expand side menu")]
        public SideMenu ExpandSideMenu()
        {
            Wait.Until(ElementToBeClickable(HamburgerMenu));
            HamburgerMenu.Click();
            return this;
        }

        [AllureStep("Click 'Log Out' option")]
        public SideMenu Logout()
        {
            Wait.Until(ElementToBeClickable(LogOutButton));
            LogOutButton.Click();
            return this;
        }
    }
}