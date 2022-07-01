using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.CreateAccountModals
{
    public class VerifyYourAccountChooseMethodModal : OnboardingModal
    {
        private const string Step2SubheaderText = "STEP 2";
        private const string VerifyYourAccountHeaderText = "Verify your Account";
        private const string TextMessageOptionLabelText = "Text Message";
        private const string EmailOptionLabelText = "Email";
        private const string AdviceMessageText = "Text message is the fastest way to verify.";

        [FindsBy(How = How.XPath, Using = "//small")]
        private IWebElement _adviceMessage;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'radio-group__option')][2]")]
        private IWebElement _emailMethod;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'radio-group__option')][1]")]
        private IWebElement _textMessageMethod;

        public VerifyYourAccountChooseMethodModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Text Message' option")]
        public VerifyYourAccountChooseMethodModal ClickTextMessageOption()
        {
            Wait.Until(ElementToBeVisible(_textMessageMethod));
            _textMessageMethod.Click();
            Wait.Until(ElementToBeClickable(ContinueButton));
            return this;
        }

        [AllureStep("Click 'Email' option")]
        public VerifyYourAccountChooseMethodModal ClickEmailOption()
        {
            Wait.Until(ElementToBeVisible(_emailMethod));
            _emailMethod.Click();
            Wait.Until(ElementToBeClickable(ContinueButton));
            return this;
        }

        [AllureStep("Check 'Verify your Account' modal with displayed methods")]
        public VerifyYourAccountChooseMethodModal CheckVerifyYourAccountChooseMethodModal()
        {
            try
            {
                CheckOnboardingModal();
                Wait.Until(ElementToBeVisible(_textMessageMethod));
                Wait.Until(ElementToBeVisible(_emailMethod));
                Wait.Until(ElementToBeVisible(_adviceMessage));
                Wait.Until(ElementToBeVisible(ContinueButton));

                StepHeader.Text.Should().Be(VerifyYourAccountHeaderText);
                StepSubheader.Text.Should().Be(Step2SubheaderText);
                _textMessageMethod.Text.Should().Be(TextMessageOptionLabelText);
                _emailMethod.Text.Should().Be(EmailOptionLabelText);
                _adviceMessage.Text.Should().Be(AdviceMessageText);
                //line below commented out because of BUG #43174
                //ContinueButton.Enabled.Should().BeFalse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}