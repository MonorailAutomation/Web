using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class TrackAddCashModal : AddCashModal
    {
        private const string AvailableToWithdrawLabelText = "Available to Withdraw (Est.)";

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']//div[2]//p[2]")]
        private IWebElement _availableToWithdrawAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']//div[2]//p[1]")]
        private IWebElement _availableToWithdrawLabel;

        public TrackAddCashModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add Cash' modal")]
        public TrackAddCashModal CheckTrackAddCashModal()
        {
            try
            {
                CheckAddCashModal();
                Wait.Until(ElementToBeVisible(_availableToWithdrawLabel));
                Wait.Until(ElementToBeVisible(_availableToWithdrawAmount));

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