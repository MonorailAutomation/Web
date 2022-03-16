using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.CreateAccountModals
{
    public class VerifyYourAccountVerificationCodeModal : OnboardingModal
    {
        private const string Step2SubheaderText = "STEP 2";
        private const string VerifyYourAccountHeaderText = "Verify your Account";
        private const string EnterVerificationCodeMessageText = "Please enter your verification code";
        private const string ResendOptionText = "Resend";

        private const string ExpectedInvalidCodeHeader = "An error happened";
        private const string ExpectedInvalidCodeMessage = "The code you entered does not match our records. Please enter a valid verification code.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//span[contains(@class,'header')]")]
        private IWebElement _enterVerificationCodeMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//a")]
        private IWebElement _resendOption;

        [FindsBy(How = How.ClassName, Using = "vim-flash-message__dismiss")]
        private IWebElement _flashMessageDismissButton;

        [FindsBy(How = How.ClassName, Using = "vim-flash-message__text")]
        private IWebElement _flashMessageText;

        [FindsBy(How = How.ClassName, Using = "vim-flash-message__title")]
        private IWebElement _flashMessageTitle;

        public VerifyYourAccountVerificationCodeModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Enter verification code: {0}")]
        public VerifyYourAccountVerificationCodeModal EnterVerificationCode(string verificationCode)
        {
            const string codeFieldFrontSelector = "//code-input//span[";
            const string codeFieldEndSelector = "]//input";
            var verificationCodeArray = verificationCode.ToCharArray();

            for (var i = 1; i < verificationCodeArray.Length + 1; i++)
            {
                var codeFieldSelector = codeFieldFrontSelector + i + codeFieldEndSelector;
                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(codeFieldSelector)))
                    .SendKeys(verificationCodeArray[i - 1].ToString());
            }

            Wait.Until(ElementToBeClickable(ContinueButton));
            return this;
        }

        [AllureStep("Check 'Verify your Account' modal with displayed methods")]
        public VerifyYourAccountVerificationCodeModal CheckYourAccountVerificationCodeModal()
        {
            try
            {
                CheckOnboardingModal();

                Wait.Until(ElementToBeVisible(_resendOption));
                Wait.Until(ElementToBeVisible(ContinueButton));

                StepHeader.Text.Should().Be(VerifyYourAccountHeaderText);
                StepSubheader.Text.Should().Be(Step2SubheaderText);
                _resendOption.Text.Should().Be(ResendOptionText);
                _enterVerificationCodeMessage.Text.Should().Be(EnterVerificationCodeMessageText);

                ContinueButton.Enabled.Should().BeFalse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Verify that 'The code you entered does not match our records.' message is displayed")]
        public VerifyYourAccountVerificationCodeModal VerifyIfIncorrectVerificationCodeMessageIsDisplayed()
        {
            Wait.Until(ElementToBeVisible(_flashMessageTitle));
            Wait.Until(ElementToBeVisible(_flashMessageText));
            Wait.Until(ElementToBeClickable(_flashMessageDismissButton));

            var actualHeader = _flashMessageTitle.Text;
            var actualMessage = _flashMessageText.Text;

            actualHeader.Should().Be(ExpectedInvalidCodeHeader);
            actualMessage.Should().Be(ExpectedInvalidCodeMessage);

            return this;
        }
    }
}