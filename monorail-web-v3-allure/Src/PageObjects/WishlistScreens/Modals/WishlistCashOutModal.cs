using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistCashOutModal
    {
        private const string WishlistCashOutHeader = "Withdraw Cash";

        [FindsBy(How = How.XPath, Using = "//button//span[contains(text(),'Confirm')]")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _wishlistCashOutHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _wishlistCashOutInput;

        public WishlistCashOutModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if 'Cash Out Modal' is displayed")]
        public WishlistCashOutModal CheckWishlistCashOutModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistCashOutHeader));
            Wait.Until(ElementToBeVisible(_wishlistCashOutInput));
            Wait.Until(ElementToBeClickable(_confirmButton));

            _wishlistCashOutHeader.Text.Should().Contain(WishlistCashOutHeader);
            return this;
        }

        [AllureStep("Set Wishlist withdraw cash amount to '${0}'")]
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