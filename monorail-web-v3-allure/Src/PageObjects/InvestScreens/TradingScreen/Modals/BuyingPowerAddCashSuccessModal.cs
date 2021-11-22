using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Modals
{
    public class BuyingPowerAddCashSuccessModal : AddCashSuccessModal
    {
        private const string BuyingPowerAddCashSuccessAdviceText =
            "Once complete, this amount will be added to your buying power total and will be able to be used for buying orders.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h1")]
        private IWebElement _amountDeposited;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _buyingPowerAddCashSuccessAdvice;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h3")]
        private IWebElement _buyingPowerAddCashSuccessMessage;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Return')]")]
        private IWebElement _returnButton;

        public BuyingPowerAddCashSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add Cash' success modal")]
        public BuyingPowerAddCashSuccessModal CheckBuyingPowerAddCashSuccessModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(SuccessHeader));
                Wait.Until(ElementToBeVisible(_buyingPowerAddCashSuccessMessage));
                Wait.Until(ElementToBeVisible(_amountDeposited));
                Wait.Until(ElementToBeVisible(_buyingPowerAddCashSuccessAdvice));
                Wait.Until(ElementToBeVisible(_returnButton));

                SuccessHeader.Text.Should().Be(AddCashSuccessHeaderText);
                _buyingPowerAddCashSuccessMessage.Text.Should().Be(AddCashSuccessMessageText);
                _amountDeposited.Text.Should().NotBeNullOrEmpty();
                _buyingPowerAddCashSuccessAdvice.Text.Should().Be(BuyingPowerAddCashSuccessAdviceText);   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }

        [AllureStep("Verify if ${0} amount is shown in Success Modal")]
        public BuyingPowerAddCashSuccessModal VerifyDepositedAmount(string amountToAdd)
        {
            Wait.Until(ElementToBeVisible(_amountDeposited));
            _amountDeposited.Text.Should().Contain(amountToAdd);
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