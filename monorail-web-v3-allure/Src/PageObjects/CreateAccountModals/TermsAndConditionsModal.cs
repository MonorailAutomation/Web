using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.CreateAccountModals
{
    public class TermsAndConditionsModal : OnboardingModal
    {
        private const string Step3SubheaderText = "STEP 3";
        private const string TermsOfUseHeaderText = "Terms and Conditions";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Agree and Finish')]")]
        private IWebElement _agreeAndFinishButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Skip to bottom')]")]
        private IWebElement _skipToBottomButton;

        public TermsAndConditionsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Skip to bottom' button")]
        public TermsAndConditionsModal ClickSkipToBottomButton()
        {
            Wait.Until(ElementToBeVisible(_skipToBottomButton));
            _skipToBottomButton.Click();
            return this;
        }

        [AllureStep("Click 'Agree and Finish' button")]
        public TermsAndConditionsModal ClickAgreeAndFinishButton()
        {
            Wait.Until(ElementToBeNotVisible(_skipToBottomButton));
            Wait.Until(ElementToBeClickable(_agreeAndFinishButton));
            _agreeAndFinishButton.Click();
            return this;
        }

        [AllureStep("Check 'Terms of use' modal")]
        public TermsAndConditionsModal CheckTermsAndConditionsModal()
        {
            try
            {
                CheckOnboardingModal();
                Wait.Until(ElementToBeVisible(_skipToBottomButton));
                Wait.Until(ElementToBeVisible(_agreeAndFinishButton));

                StepHeader.Text.Should().Be(TermsOfUseHeaderText);
                StepSubheader.Text.Should().Be(Step3SubheaderText);

                _agreeAndFinishButton.Enabled.Should().BeFalse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}