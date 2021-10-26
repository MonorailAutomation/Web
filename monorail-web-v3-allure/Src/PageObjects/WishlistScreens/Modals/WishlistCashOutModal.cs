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
        private const string WishlistCashOutMessage = "Choose a withdrawal amount";
        private const string AvailableToWithdrawLabel = "Available to Withdraw";
        private const string OnHoldLabel = "On hold";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[2]")]
        private IWebElement _availableToWithdrawAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[1]")]
        private IWebElement _availableToWithdrawLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//button[contains(text(),'Confirm')]")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[3]//p[2]")]
        private IWebElement _onHoldAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[3]//p[1]")]
        private IWebElement _onHoldLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _wishlistCashOutHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _wishlistCashOutInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/p")]
        private IWebElement _wishlistCashOutMessage;

        public WishlistCashOutModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if 'Withdraw Cash' modal")]
        public WishlistCashOutModal CheckWishlistCashOutModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistCashOutHeader));
            Wait.Until(ElementToBeVisible(_wishlistCashOutMessage));
            Wait.Until(ElementToBeVisible(_wishlistCashOutInput));
            Wait.Until(ElementToBeVisible(_availableToWithdrawLabel));
            Wait.Until(ElementToBeVisible(_availableToWithdrawAmount));
            Wait.Until(ElementToBeVisible(_onHoldLabel));
            Wait.Until(ElementToBeVisible(_onHoldAmount));
            Wait.Until(ElementToBeClickable(_confirmButton));

            _wishlistCashOutHeader.Text.Should().Contain(WishlistCashOutHeader);
            _wishlistCashOutMessage.Text.Should().Contain(WishlistCashOutMessage);
            _availableToWithdrawLabel.Text.Should().Contain(AvailableToWithdrawLabel);
            _availableToWithdrawLabel.Text.Should().NotBeNullOrEmpty();
            _onHoldLabel.Text.Should().Contain(OnHoldLabel);
            _onHoldAmount.Text.Should().NotBeNullOrEmpty();

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