using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistAddCashSuccessModal : AddCashSuccessModal
    {
        private const string WishlistAddCashSuccessAdviceText =
            "Once completed, this amount will be added to your Wishlist Account total and will be able to be used to power your purchases.";

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//div//div//p")]
        private IWebElement _amountDeposited;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']/div/p[2]")]
        private IWebElement _wishlistAddCashSuccessAdvice;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/div/p[1]")]
        private IWebElement _wishlistAddCashSuccessMessage;

        public WishlistAddCashSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add Cash' success modal")]
        public WishlistAddCashSuccessModal CheckWishlistAddCashSuccessModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(SuccessHeader));
                Wait.Until(ElementToBeVisible(_wishlistAddCashSuccessMessage));
                Wait.Until(ElementToBeVisible(_amountDeposited));
                Wait.Until(ElementToBeVisible(_wishlistAddCashSuccessAdvice));
                Wait.Until(ElementToBeClickable(_finishButton));

                SuccessHeader.Text.Should().Be(AddCashSuccessHeaderText);
                _wishlistAddCashSuccessMessage.Text.Should().Be(AddCashSuccessMessageText);
                _amountDeposited.Text.Should().NotBeNullOrEmpty();
                _wishlistAddCashSuccessAdvice.Text.Should().Be(WishlistAddCashSuccessAdviceText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check if ${0} amount was deposited")]
        public WishlistAddCashSuccessModal VerifyDepositedAmount(string wishlistAddCashAmount)
        {
            Wait.Until(ElementToBeVisible(_amountDeposited));
            _amountDeposited.Text.Should().Be('$' + wishlistAddCashAmount);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public WishlistAddCashSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}