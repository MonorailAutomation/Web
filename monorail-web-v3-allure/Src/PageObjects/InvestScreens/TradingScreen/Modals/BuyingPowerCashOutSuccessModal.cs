using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Modals
{
    public class BuyingPowerCashOutSuccessModal
    {
        private const string BuyingPowerCashOutSuccessHeader = "Success!";
        private const string BuyingPowerCashOutSuccessMessage = "Funds are on their way to your connected account";
        private const string BuyingPowerCashOutSuccessAdvicePartOne =
            "Deposited funds will be available to withdraw 5 business days after they finish depositing.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _buyingPowerCashOutSuccessHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h3")]
        private IWebElement _buyingPowerCashOutSuccessMessage;
        
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//h1")]
        private IWebElement _moneyAmount;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _buyingPowerCashOutSuccessAdvice;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Return')]")]
        private IWebElement _returnButton;

        public BuyingPowerCashOutSuccessModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Cash Out' success modal")]
        public BuyingPowerCashOutSuccessModal CheckBuyingPowerCashOutSuccessModal()
        {
            Wait.Until(ElementToBeVisible(_buyingPowerCashOutSuccessHeader));
            Wait.Until(ElementToBeVisible(_buyingPowerCashOutSuccessMessage));
            Wait.Until(ElementToBeVisible(_moneyAmount));
            Wait.Until(ElementToBeVisible(_buyingPowerCashOutSuccessAdvice));
            Wait.Until(ElementToBeClickable(_returnButton));

            _buyingPowerCashOutSuccessHeader.Text.Should().Be(BuyingPowerCashOutSuccessHeader);
            _buyingPowerCashOutSuccessMessage.Text.Should().Be(BuyingPowerCashOutSuccessMessage);
            _moneyAmount.Text.Should().NotBeNullOrEmpty();
            _buyingPowerCashOutSuccessAdvice.Text.Should().Contain(BuyingPowerCashOutSuccessAdvicePartOne);

            return this;
        }

        [AllureStep("Check if ${0} amount was withdrawn")]
        public BuyingPowerCashOutSuccessModal VerifyWithdrawnAmount(string wishlistCashOutAmount)
        {
            Wait.Until(ElementToBeVisible(_moneyAmount));
            _moneyAmount.Text.Should().Contain(wishlistCashOutAmount);
            return this;
        }

        [AllureStep("Click 'Return' button")]
        public BuyingPowerCashOutSuccessModal ClickReturnButton()
        {
            Wait.Until(ElementToBeClickable(_returnButton));
            _returnButton.Click();
            return this;
        }
    }
}