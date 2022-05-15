using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals.TransactionModals
{
    public class TransferringSuccessModal : Modal
    {
        private const string TransferringMessageText = "Transferring";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _transferringMessage;

        public TransferringSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Transferring' modal")]
        public TransferringSuccessModal CheckTransferringModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_transferringMessage));
                Wait.Until(ElementToBeVisible(_finishButton));

                _transferringMessage.Text.Should().Be(TransferringMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public TransferringSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeVisible(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}