using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.TransactionModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals
{
    public class SpendAddCashSuccessModal : AddCashSuccessModal
    {
        private const string SpendAddCashSuccessAdviceText =
            "Short-term goals take between 1-3 business days to transfer. Deposited funds will be available to withdraw 5 business days after they finish depositing.";

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//div//div//p")]
        private IWebElement _amountDeposited;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']/div/p[2]")]
        private IWebElement _spendAddCashSuccessAdvice;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/div/p[1]")]
        private IWebElement _spendAddCashSuccessMessage;

        public SpendAddCashSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if ${0} amount was deposited")]
        public SpendAddCashSuccessModal VerifyDepositedAmount(string wishlistAddCashAmount)
        {
            Wait.Until(ElementToBeVisible(_amountDeposited));
            _amountDeposited.Text.Should().Be('$' + wishlistAddCashAmount);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public SpendAddCashSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }

        [AllureStep("Check 'Add Cash' success modal")]
        public SpendAddCashSuccessModal CheckSpendAddCashSuccessModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(SuccessHeader));
                Wait.Until(ElementToBeVisible(_spendAddCashSuccessMessage));
                Wait.Until(ElementToBeVisible(_amountDeposited));
                Wait.Until(ElementToBeVisible(_spendAddCashSuccessAdvice));
                Wait.Until(ElementToBeClickable(_finishButton));

                SuccessHeader.Text.Should().Be(AddCashSuccessHeaderText);
                _spendAddCashSuccessMessage.Text.Should().Be(AddCashSuccessMessageText);
                _amountDeposited.Text.Should().NotBeNullOrEmpty();
                _spendAddCashSuccessAdvice.Text.Should().Be(SpendAddCashSuccessAdviceText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}