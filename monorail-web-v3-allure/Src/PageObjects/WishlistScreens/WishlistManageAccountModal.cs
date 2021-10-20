using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.WishlistManageAccountModal
{
    public class WishlistManageAccountModal
    {
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _wishlistManageAccountHeaderItem;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Cash')]")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//button[contains(text(),'Cash Out')]")]
        private IWebElement _cashOutButton;

        public WishlistManageAccountModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if 'Manage Account Modal' is displayed")]
        public WishlistManageAccountModal CheckWishlistManageAccountModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistManageAccountHeaderItem));
            _wishlistManageAccountHeaderItem.Text.Should().Contain("Wishlist Account");
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