using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Modals
{
    public class BuyingPowerWithdrawCashSuccessModal : WithdrawCashSuccessModal
    {
        private const string BuyingPowerCashOutSuccessAdviceText =
            "Deposited funds will be available to withdraw 5 business days after they finish depositing.";

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _buyingPowerWithdrawCashSuccessAdvice;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h3")]
        private IWebElement _buyingPowerWithdrawCashSuccessMessage;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//h1")]
        private IWebElement _moneyAmount;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Return')]")]
        private IWebElement _returnButton;

        public BuyingPowerWithdrawCashSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Cash Out' success modal")]
        public BuyingPowerWithdrawCashSuccessModal CheckBuyingPowerCashOutSuccessModal()
        {
            Wait.Until(ElementToBeVisible(SuccessHeader));
            Wait.Until(ElementToBeVisible(_buyingPowerWithdrawCashSuccessMessage));
            Wait.Until(ElementToBeVisible(_moneyAmount));
            Wait.Until(ElementToBeVisible(_buyingPowerWithdrawCashSuccessAdvice));
            Wait.Until(ElementToBeClickable(_returnButton));

            SuccessHeader.Text.Should().Be(WithdrawCashSuccessHeaderText);
            _buyingPowerWithdrawCashSuccessMessage.Text.Should().Be(WithdrawCashSuccessMessageText);
            _moneyAmount.Text.Should().NotBeNullOrEmpty();
            _buyingPowerWithdrawCashSuccessAdvice.Text.Should().Contain(BuyingPowerCashOutSuccessAdviceText);

            return this;
        }

        [AllureStep("Check if ${0} amount was withdrawn")]
        public BuyingPowerWithdrawCashSuccessModal VerifyWithdrawnAmount(string buyingPowerCashOutAmount)
        {
            Wait.Until(ElementToBeVisible(_moneyAmount));
            _moneyAmount.Text.Should().Contain(buyingPowerCashOutAmount);
            return this;
        }

        [AllureStep("Click 'Return' button")]
        public BuyingPowerWithdrawCashSuccessModal ClickReturnButton()
        {
            Wait.Until(ElementToBeClickable(_returnButton));
            _returnButton.Click();
            return this;
        }
    }
}