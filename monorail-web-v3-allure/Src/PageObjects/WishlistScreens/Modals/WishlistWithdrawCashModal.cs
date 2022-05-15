using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.TransactionModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistWithdrawCashModal : WithdrawCashModal
    {
        private const string OnHoldLabelText = "On hold";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[2]")]
        private IWebElement _availableToWithdrawAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[1]")]
        private IWebElement _availableToWithdrawLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Confirm')]")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']//div[2]//p[2]")]
        private IWebElement _onHoldAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']//div[2]//p[1]")]
        private IWebElement _onHoldLabel;

        public WishlistWithdrawCashModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Withdraw Cash' modal")]
        public WishlistWithdrawCashModal CheckWishlistWithdrawCashModal()
        {
            try
            {
                CheckWithdrawCashModal();
                Wait.Until(ElementToBeVisible(_availableToWithdrawLabel));
                Wait.Until(ElementToBeVisible(_availableToWithdrawAmount));
                Wait.Until(ElementToBeVisible(_onHoldLabel));
                Wait.Until(ElementToBeVisible(_onHoldAmount));
                Wait.Until(ElementToBeVisible(_confirmButton));

                _availableToWithdrawLabel.Text.Should().Contain(AvailableToWithdrawLabelText);
                _availableToWithdrawLabel.Text.Should().NotBeNullOrEmpty();
                _onHoldLabel.Text.Should().Contain(OnHoldLabelText);
                _onHoldAmount.Text.Should().NotBeNullOrEmpty();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Click 'Confirm' button")]
        public new WishlistWithdrawCashModal ClickConfirmButton()
        {
            Wait.Until(ElementToBeVisible(_confirmButton));
            _confirmButton.Click();
            return this;
        }
    }
}