using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using static monorail_web_v3.Commons.Waits;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals
{
    public class SpendOnboardingSuccessModal : Modal
    {
        private const string ModalHeaderText = "Account Setup";
        private const string SuccessMessageText = "Success!";
        private const string AccountMessageText = "Your checking account is being opened.";

        private const string InfoMessageText =
            "Once opened, your personalized Vimvest Debit Card will be send and arrive within 5-10 business days.";

        private const string CardImageUrl = "assets/img/banner-debit-card.svg";
        private const string SipcLogoUrl = "assets/img/fdic-logo.svg";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h3")]
        private IWebElement _accountMessage;

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

        public SpendOnboardingSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Finish' button")]
        public SpendOnboardingSuccessModal ClickFinish()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }

        [AllureStep("Check Spend onboarding success modal")]
        public SpendOnboardingSuccessModal CheckSpendOnboardingSuccessModal()
        {
            try
            {
                Wait.Until(ElementToBeClickable(ModalHeader));
                Wait.Until(ElementToBeClickable(XButton));
                Wait.Until(ElementToBeClickable(_successMessage));
                Wait.Until(ElementToBeClickable(_accountMessage));
                Wait.Until(ElementToBeClickable(_cardImage));
                Wait.Until(ElementToBeClickable(_infoMessage));
                Wait.Until(ElementToBeClickable(_fdicLogo));
                Wait.Until(ElementToBeClickable(_finishButton));

                ModalHeader.Text.Should().Be(ModalHeaderText);
                _successMessage.Text.Should().Be(SuccessMessageText);
                _accountMessage.Text.Should().Be(AccountMessageText);
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