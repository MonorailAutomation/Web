using System.Threading;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistManageAccountModal
    {
        private const string WishlistManageAccountHeader = "Wishlist Account";

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _wishlistManageAccountHeader;
        
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Cash')]")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//button[contains(text(),'Cash Out')]")]
        private IWebElement _cashOutButton;

        [FindsBy(How = How.XPath,
            Using = "//vim-modal-footer//button[contains(text(), 'Dismiss')]")]
        private IWebElement _dismissButton;

        public WishlistManageAccountModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Wishlist Account' modal")]
        public WishlistManageAccountModal CheckWishlistManageAccountModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistManageAccountHeader));
            Wait.Until(ElementToBeVisible(_addCashButton));
            Wait.Until(ElementToBeVisible(_cashOutButton));
            Wait.Until(ElementToBeVisible(_dismissButton));

            _wishlistManageAccountHeader.Text.Should().Contain(WishlistManageAccountHeader);
            return this;
        }

        [AllureStep("Click 'Add Cash' button")]
        public WishlistManageAccountModal ClickAddCashButton()
        {
            Wait.Until(ElementToBeClickable(_addCashButton));
            Thread.Sleep(2000); // necessary workaround
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Cash Out' button")]
        public WishlistManageAccountModal ClickCashOutButton()
        {
            Wait.Until(ElementToBeClickable(_cashOutButton));
            Thread.Sleep(2000); // necessary workaround
            _cashOutButton.Click();
            return this;
        }
    }
}