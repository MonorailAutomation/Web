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
    public class BuyingPowerAddCashModal : AddCashModal
    {
        private const string CurrentBuyingPowerLabelText = "Current Buying Power";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[2]")]
        private IWebElement _currentBuyingPowerAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[1]")]
        private IWebElement _currentBuyingPowerLabel;

        public BuyingPowerAddCashModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add Cash' modal")]
        public BuyingPowerAddCashModal CheckBuyingPowerAddCashModal()
        {
            try
            {
                CheckAddCashModal();
                Wait.Until(ElementToBeVisible(_currentBuyingPowerLabel));
                Wait.Until(ElementToBeVisible(_currentBuyingPowerAmount));

                _currentBuyingPowerLabel.Text.Should().Be(CurrentBuyingPowerLabelText);
                _currentBuyingPowerAmount.Text.Should().NotBeNullOrEmpty();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}