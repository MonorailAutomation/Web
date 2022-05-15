using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.TransactionModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals.TransactionModals
{
    public class WishlistWithdrawCashSuccessModal : WithdrawCashSuccessModal
    {
        private const string WishlistWithdrawCashSuccessAdvicePartOneText =
            "Transfers can take between 3-7 business days to transfer.";

        private const string WishlistWithdrawCashSuccessAdvicePartTwoText =
            "Deposited funds will be available to withdraw 5 business days after they finish depositing.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//div//div//p")]
        private IWebElement _moneyAmount;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']/div/p[2]")]
        private IWebElement _wishlistWithdrawCashSuccessAdvice;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/div/p[1]")]
        private IWebElement _wishlistWithdrawCashSuccessMessage;

        public WishlistWithdrawCashSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Cash Out' success modal")]
        public WishlistWithdrawCashSuccessModal CheckWishlistCashOutSuccessModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(SuccessHeader));
                Wait.Until(ElementToBeVisible(_wishlistWithdrawCashSuccessMessage));
                Wait.Until(ElementToBeVisible(_moneyAmount));
                Wait.Until(ElementToBeVisible(_wishlistWithdrawCashSuccessAdvice));
                Wait.Until(ElementToBeClickable(_finishButton));

                SuccessHeader.Text.Should().Be(WithdrawCashSuccessHeaderText);
                _wishlistWithdrawCashSuccessMessage.Text.Should().Be(WithdrawCashSuccessMessageText);
                _moneyAmount.Text.Should().NotBeNullOrEmpty();
                _wishlistWithdrawCashSuccessAdvice.Text.Should().Contain(WishlistWithdrawCashSuccessAdvicePartOneText);
                _wishlistWithdrawCashSuccessAdvice.Text.Should().Contain(WishlistWithdrawCashSuccessAdvicePartTwoText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check if ${0} amount was withdrawn")]
        public WishlistWithdrawCashSuccessModal VerifyWithdrawnAmount(string wishlistCashOutAmount)
        {
            Wait.Until(ElementToBeVisible(_moneyAmount));
            _moneyAmount.Text.Should().Contain(wishlistCashOutAmount);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public WishlistWithdrawCashSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}