using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Modals
{
    public class BuyingPowerCashOutModal
    {
        private const string BuyingPowerCashOutHeader = "Withdraw Cash";
        private const string BuyingPowerCashOutMessage = "Choose a withdrawal amount";
        private const string AvailableToWithdrawLabel = "Available to Withdraw";
        private const string OnHoldLabel = "On Hold";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[2]")]
        private IWebElement _onHoldAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[1]")]
        private IWebElement _onHoldLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//button[contains(text(),'Confirm')]")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[1]//p[2]")]
        private IWebElement _availableToWithdrawAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[1]//p[1]")]
        private IWebElement _availableToWithdrawLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _buyingPowerCashOutHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _buyingPowerCashOutInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/p")]
        private IWebElement _buyingPowerCashOutMessage;
        
        public BuyingPowerCashOutModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if 'Withdraw Cash' modal")]
        public BuyingPowerCashOutModal CheckBuyingPowerCashOutModal()
        {
            Wait.Until(ElementToBeVisible(_buyingPowerCashOutHeader));
            Wait.Until(ElementToBeVisible(_buyingPowerCashOutMessage));
            Wait.Until(ElementToBeVisible(_buyingPowerCashOutInput));
            Wait.Until(ElementToBeVisible(_availableToWithdrawLabel));
            Wait.Until(ElementToBeVisible(_availableToWithdrawAmount));
            Wait.Until(ElementToBeVisible(_onHoldLabel));
            Wait.Until(ElementToBeVisible(_onHoldAmount));
            Wait.Until(ElementToBeVisible(_confirmButton));

            _buyingPowerCashOutHeader.Text.Should().Contain(BuyingPowerCashOutHeader);
            _buyingPowerCashOutMessage.Text.Should().Contain(BuyingPowerCashOutMessage);
            _availableToWithdrawLabel.Text.Should().Contain(AvailableToWithdrawLabel);
            _availableToWithdrawLabel.Text.Should().NotBeNullOrEmpty();
            _onHoldLabel.Text.Should().Contain(OnHoldLabel);
            _onHoldAmount.Text.Should().NotBeNullOrEmpty();

            return this;
        }

        [AllureStep("Set Buying Power withdraw cash amount to '${0}'")]
        public BuyingPowerCashOutModal SetBuyingPowerCashOutAmount(string wishlistCashOutAmount)
        {
            Wait.Until(ElementToBeVisible(_buyingPowerCashOutInput));
            _buyingPowerCashOutInput.Clear();
            _buyingPowerCashOutInput.SendKeys(wishlistCashOutAmount);
            return this;
        }

        [AllureStep("Click 'Confirm' button")]
        public BuyingPowerCashOutModal ClickConfirmButton()
        {
            Wait.Until(ElementToBeVisible(_confirmButton));
            _confirmButton.Click();
            return this;
        }
    }
}