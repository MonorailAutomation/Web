using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.TransactionModals
{
    public class WithdrawCashModal : Modal
    {
        private const string WithdrawCashHeaderText = "Withdraw Cash";
        private const string WithdrawCashMessageText = "Choose a withdrawal amount";
        protected const string AvailableToWithdrawLabelText = "Available to Withdraw";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _withdrawCashInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/p")]
        private IWebElement _withdrawCashMessage;

        protected WithdrawCashModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set withdraw cash amount to '${0}'")]
        public WithdrawCashModal SetWithdrawCashAmount(string wishlistCashOutAmount)
        {
            Wait.Until(ElementToBeVisible(_withdrawCashInput));
            _withdrawCashInput.Clear();
            _withdrawCashInput.SendKeys(wishlistCashOutAmount);
            return this;
        }

        protected WithdrawCashModal CheckWithdrawCashModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_withdrawCashMessage));
                Wait.Until(ElementToBeVisible(_withdrawCashInput));

                ModalHeader.Text.Should().Contain(WithdrawCashHeaderText);
                _withdrawCashMessage.Text.Should().Contain(WithdrawCashMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}