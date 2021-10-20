using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.WishlistCashOutModal
{ 
    public class WishlistCashOutModal
    {
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _wishlistCashOutHeaderItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _wishlistCashOutInput;

        [FindsBy(How = How.XPath, Using = "//button//span[contains(text(),'Confirm')]")]
        private IWebElement _confirmButton;

        public WishlistCashOutModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if 'Cash Out Modal' is displayed")]
        public WishlistCashOutModal CheckWishlistCashOutModal()
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElement(_wishlistCashOutHeaderItem, "Withdraw Cash"));
            return this;
        }

        [AllureStep("Set Wishlist Withdraw Cash Amount to '${0}'")]
        public WishlistCashOutModal SetWishlistCashOutAmount(string wishlistCashOutAmount)
        {
            Wait.Until(ElementToBeVisible(_wishlistCashOutInput));
            _wishlistCashOutInput.Clear();
            _wishlistCashOutInput.SendKeys(wishlistCashOutAmount);
            return this;
        }

        [AllureStep("Click 'Confirm' button")]
        public WishlistCashOutModal ClickConfirmButton()
        {
            Wait.Until(ElementToBeVisible(_confirmButton));
            _confirmButton.Click();
            return this;
        }
    }
}