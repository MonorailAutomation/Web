using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals
{
    public class SpendAddCashModal : AddCashModal
    {
        private const string TransferCompleteDateLabelText = "Transfer Complete Date (Est.)";
        private const string AvailableToWithdrawLabelText = "Available to Withdraw (Est.)";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/div/div[2]/p[2]")]
        private IWebElement _availableToWithdrawAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/div/div[2]/p[1]")]
        private IWebElement _availableToWithdrawLabel;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']/div[1]/p[2]")]
        private IWebElement _transferCompleteDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']/div[1]/p[1]")]
        private IWebElement _transferCompleteLabel;

        public SpendAddCashModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add Cash' modal")]
        public SpendAddCashModal CheckSpendAddCashModal()
        {
            try
            {
                CheckAddCashModal();
                Wait.Until(ElementToBeVisible(_transferCompleteLabel));
                Wait.Until(ElementToBeVisible(_transferCompleteDate));
                Wait.Until(ElementToBeVisible(_availableToWithdrawLabel));
                Wait.Until(ElementToBeVisible(_availableToWithdrawAmount));

                _transferCompleteLabel.Text.Should().Be(TransferCompleteDateLabelText);
                _transferCompleteDate.Text.Should().NotBeNullOrEmpty();
                _availableToWithdrawLabel.Text.Should().Be(AvailableToWithdrawLabelText);
                _availableToWithdrawAmount.Text.Should().NotBeNullOrEmpty();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}