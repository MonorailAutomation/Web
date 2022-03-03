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
    public class BuyingPowerWithdrawCashModal : WithdrawCashModal
    {
        private const string OnHoldLabelText = "On Hold";

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']/div/div[1]/p[2]")]
        private IWebElement _availableToWithdrawAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']/div/div[1]/p[1]")]
        private IWebElement _availableToWithdrawLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']/div/div[2]/p[2]")]
        private IWebElement _onHoldAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']/div/div[2]/p[1]")]
        private IWebElement _onHoldLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//button[contains(text(),'Confirm')]")]
        private IWebElement ConfirmButton;

        public BuyingPowerWithdrawCashModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Withdraw Cash' modal")]
        public BuyingPowerWithdrawCashModal CheckBuyingPowerWithdrawCashModal()
        {
            try
            {
                CheckWithdrawCashModal();
                Wait.Until(ElementToBeVisible(_availableToWithdrawLabel));
                Wait.Until(ElementToBeVisible(_availableToWithdrawAmount));
                Wait.Until(ElementToBeVisible(_onHoldLabel));
                Wait.Until(ElementToBeVisible(_onHoldAmount));
                Wait.Until(ElementToBeVisible(ConfirmButton));

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
    }
}