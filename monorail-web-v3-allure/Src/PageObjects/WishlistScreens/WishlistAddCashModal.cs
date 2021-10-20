using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.WishlistAddCashModal
{ 
    public class WishlistAddCashModal
    {
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _wishlistAddCashHeaderItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _wishlistAddCashInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//button[contains(text(),'Confirm')]")]
        private IWebElement _confirmButton;

        public WishlistAddCashModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if 'Add Cash Modal' is displayed")]
        public WishlistAddCashModal CheckWishlistAddCashModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistAddCashHeaderItem));
            Wait.Until(ExpectedConditions.TextToBePresentInElement(_wishlistAddCashHeaderItem, "Add Cash"));
            return this;
        }

        [AllureStep("Set Wishlist Add Cash Amount to '${0}'")]
        public WishlistAddCashModal SetWishlistAddCashAmount(string wishlistAddCashAmount)
        {
            Wait.Until(ElementToBeVisible(_wishlistAddCashInput));
            _wishlistAddCashInput.Clear();
            _wishlistAddCashInput.SendKeys(wishlistAddCashAmount);
            return this;
        }

        [AllureStep("Click 'Confirm' button")]
        public WishlistAddCashModal ClickConfirmButton()
        {
            Wait.Until(ElementToBeVisible(_confirmButton));
            _confirmButton.Click();
            return this;
        }
    }
}