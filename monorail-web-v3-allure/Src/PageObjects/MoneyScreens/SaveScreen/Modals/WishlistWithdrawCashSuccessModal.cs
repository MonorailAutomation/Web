using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.TransactionModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class TrackWithdrawCashSuccessModal : WithdrawCashSuccessModal
    {
        private const string TrackWithdrawCashSuccessAdvicePartOneText =
            "Short-term goals can take between 1-3 business days to transfer.";

        private const string TrackWithdrawCashSuccessAdvicePartTwoText =
            "Deposited funds will be available to withdraw 5 business days after they finish depositing.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//div//div//p")]
        private IWebElement _moneyAmount;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']/div/p[2]")]
        private IWebElement _trackWithdrawCashSuccessAdvice;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/div/p[1]")]
        private IWebElement _trackWithdrawCashSuccessMessage;

        public TrackWithdrawCashSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Withdraw' success modal")]
        public TrackWithdrawCashSuccessModal CheckTrackWithdrawSuccessModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(SuccessHeader));
                Wait.Until(ElementToBeVisible(_trackWithdrawCashSuccessMessage));
                Wait.Until(ElementToBeVisible(_moneyAmount));
                Wait.Until(ElementToBeVisible(_trackWithdrawCashSuccessAdvice));
                Wait.Until(ElementToBeClickable(_finishButton));

                SuccessHeader.Text.Should().Be(WithdrawCashSuccessHeaderText);
                _trackWithdrawCashSuccessMessage.Text.Should().Be(WithdrawCashSuccessMessageText);
                _moneyAmount.Text.Should().NotBeNullOrEmpty();
                _trackWithdrawCashSuccessAdvice.Text.Should().Contain(TrackWithdrawCashSuccessAdvicePartOneText);
                _trackWithdrawCashSuccessAdvice.Text.Should().Contain(TrackWithdrawCashSuccessAdvicePartTwoText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public TrackWithdrawCashSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}