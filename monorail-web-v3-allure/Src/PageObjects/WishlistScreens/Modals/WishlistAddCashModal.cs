using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistAddCashModal
    {
        private const string WishlistAddCashHeader = "Add Cash";
        private const string WishlistAddCashMessage = "Choose an amount to add";
        private const string TransferCompleteDateLabel = "Transfer Complete Date (Est.)";
        private const string AvailableToWithdrawLabel = "Available to Withdraw (Est.)";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[2]")]
        private IWebElement _availableToWithdrawAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[1]")]
        private IWebElement _availableToWithdrawLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//button[contains(text(),'Confirm')]")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[1]//p[2]")]
        private IWebElement _transferCompleteDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[1]//p[1]")]
        private IWebElement _transferCompleteLabel;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _wishlistAddCashHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _wishlistAddCashInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/p")]
        private IWebElement _wishlistAddCashMessage;

        public WishlistAddCashModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add Cash' modal")]
        public WishlistAddCashModal CheckWishlistAddCashModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistAddCashHeader));
            Wait.Until(ElementToBeVisible(_wishlistAddCashMessage));
            Wait.Until(ElementToBeVisible(_wishlistAddCashInput));
            Wait.Until(ElementToBeVisible(_transferCompleteLabel));
            Wait.Until(ElementToBeVisible(_transferCompleteDate));
            Wait.Until(ElementToBeVisible(_availableToWithdrawLabel));
            Wait.Until(ElementToBeVisible(_availableToWithdrawAmount));
            Wait.Until(ElementToBeVisible(_wishlistAddCashMessage));

            _wishlistAddCashHeader.Text.Should().Be(WishlistAddCashHeader);
            _wishlistAddCashMessage.Text.Should().Be(WishlistAddCashMessage);
            _transferCompleteLabel.Text.Should().Be(TransferCompleteDateLabel);
            _transferCompleteDate.Text.Should().NotBeNullOrEmpty();
            _availableToWithdrawLabel.Text.Should().Be(AvailableToWithdrawLabel);
            _availableToWithdrawAmount.Text.Should().NotBeNullOrEmpty();

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