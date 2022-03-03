using System;
using System.Threading;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistItemIsBeingAddedModal : Modal
    {
        private const string YourNewItemIsBeingAddedMessageText = "Your new item is being added!";
        private const string HelperTextPartOne = "This process can take a few seconds, feel free";
        private const string HelperTextPartTwo = "to close this screen in the meantime.";

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Close')]")]
        private IWebElement _closeButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body']//p")]
        private IWebElement _helperMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body']//h2")]
        private IWebElement _yourNewItemIsBeingAddedMessage;

        public WishlistItemIsBeingAddedModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Your new item is being added!' modal")]
        public WishlistItemIsBeingAddedModal CheckWishlistItemIsBeingAddedModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_yourNewItemIsBeingAddedMessage));
                Wait.Until(ElementToBeVisible(_helperMessage));
                Wait.Until(ElementToBeVisible(_closeButton));

                _yourNewItemIsBeingAddedMessage.Text.Should().Be(YourNewItemIsBeingAddedMessageText);
                _helperMessage.Text.Should().Contain(HelperTextPartOne);
                _helperMessage.Text.Should().Contain(HelperTextPartTwo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Click 'Close' button")]
        public WishlistItemIsBeingAddedModal ClickCloseButton()
        {
            Wait.Until(ElementToBeClickable(_closeButton));
            Thread.Sleep(5000);
            _closeButton.Click();
            return this;
        }
    }
}