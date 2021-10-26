using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Modals
{
    public class BuyingPowerAddCashSuccessModal
    {
        private const string BuyingPowerAddCashSuccessHeader = "Success!";
        private const string BuyingPowerAddCashSuccessMessage = "Funds are on their way to Monorail";
        private const string BuyingPowerAddCashSuccessAdvice = "Once complete, this amount will be added to your buying power total and will be able to be used for buying orders.";
        
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _buyingPowerAddCashSuccessHeader;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h3")]
        private IWebElement _buyingPowerAddCashSuccessMessage;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h1")]
        private IWebElement _amountAdded;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _buyingPowerAddCashSuccessAdvice;
        
        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Return')]")]
        private IWebElement _returnButton;

        public BuyingPowerAddCashSuccessModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        
        [AllureStep("Check 'Add Cash' success modal")]
        public BuyingPowerAddCashSuccessModal CheckBuyingPowerAddCashSuccessModal()
        {
            Wait.Until(ElementToBeVisible(_buyingPowerAddCashSuccessHeader));
            Wait.Until(ElementToBeVisible(_buyingPowerAddCashSuccessMessage));
            Wait.Until(ElementToBeVisible(_amountAdded));
            Wait.Until(ElementToBeVisible(_buyingPowerAddCashSuccessAdvice));
            Wait.Until(ElementToBeVisible(_returnButton));
            
            _buyingPowerAddCashSuccessHeader.Text.Should().Be(BuyingPowerAddCashSuccessHeader);
            _buyingPowerAddCashSuccessMessage.Text.Should().Be(BuyingPowerAddCashSuccessMessage);
            _amountAdded.Text.Should().NotBeNullOrEmpty();
            _buyingPowerAddCashSuccessAdvice.Text.Should().Be(BuyingPowerAddCashSuccessAdvice);
            
            return this;
        }
        
        [AllureStep("Verify if ${0} amount is shown in Success Modal")]
        public BuyingPowerAddCashSuccessModal VerifyAddedAmount(string amountToAdd)
        {
            Wait.Until(ElementToBeVisible(_amountAdded));
            _amountAdded.Text.Should().Contain(amountToAdd);
            return this;
        }
        
        [AllureStep("Click 'Return' button")]
        public BuyingPowerAddCashSuccessModal ClickReturnButton()
        {
            Wait.Until(ElementToBeClickable(_returnButton));
            _returnButton.Click();
            return this;
        }
    }
}