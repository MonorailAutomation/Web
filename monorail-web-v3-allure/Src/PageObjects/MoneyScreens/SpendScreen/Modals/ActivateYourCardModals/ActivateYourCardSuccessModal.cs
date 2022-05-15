using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using static monorail_web_v3.Commons.Waits;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals.ActivateYourCardModals
{
    public class ActivateYourCardSuccessModal : Modal
    {
        private const string ModalHeaderText = "Activate your card";
        private const string SuccessMessageText = "Success!";
        private const string CardActivationMessageText = "Your debit card has been activated.";

        private const string InfoMessageText =
            "If your card is ever lost or stolen, report it to our support team. We can help!";

        private const string CardImageUrl = "assets/img/banner-debit-card.svg";
        private const string SipcLogoUrl = "assets/img/fdic-logo.svg";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h3")]
        private IWebElement _cardActivationMessageText;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//img")]
        private IWebElement _cardImage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//svg-icon")]
        private IWebElement _fdicLogo;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _infoMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _successMessage;

        public ActivateYourCardSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Finish' button")]
        public ActivateYourCardSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }

        [AllureStep("Check 'Activate your card' success modal")]
        public ActivateYourCardSuccessModal CheckActivateYourCardSuccessModal()
        {
            try
            {
                Wait.Until(ElementToBeClickable(ModalHeader));
                Wait.Until(ElementToBeClickable(XButton));
                Wait.Until(ElementToBeVisible(_successMessage));
                Wait.Until(ElementToBeVisible(_cardActivationMessageText));
                Wait.Until(ElementToBeVisible(_cardImage));
                Wait.Until(ElementToBeVisible(_infoMessage));
                Wait.Until(ElementToBeVisible(_fdicLogo));
                Wait.Until(ElementToBeClickable(_finishButton));

                ModalHeader.Text.Should().Be(ModalHeaderText);
                _successMessage.Text.Should().Be(SuccessMessageText);
                _cardActivationMessageText.Text.Should().Be(CardActivationMessageText);
                _infoMessage.Text.Should().Be(InfoMessageText);
                return this;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}