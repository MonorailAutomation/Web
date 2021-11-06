using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.CreateAccountModals
{
    public class TermsOfUseModal : OnboardingModal
    {
        private const string Step3SubheaderText = "STEP 3";
        private const string TermsOfUseHeaderText = "Terms of use";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Agree and Continue')]")]
        private IWebElement _agreeAndContinueButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Skip to bottom')]")]
        private IWebElement _skipToBottomButton;

        public TermsOfUseModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Terms of use' modal")]
        public TermsOfUseModal CheckTermsOfUseModal()
        {
            CheckOnboardingModal();
            Wait.Until(ElementToBeVisible(_skipToBottomButton));
            Wait.Until(ElementToBeVisible(_agreeAndContinueButton));

            StepHeader.Text.Should().Be(TermsOfUseHeaderText);
            StepSubheader.Text.Should().Be(Step3SubheaderText);

            _agreeAndContinueButton.Enabled.Should().BeFalse();
            return this;
        }

        [AllureStep("Click 'Skip to bottom' button")]
        public TermsOfUseModal ClickSkipToBottomButton()
        {
            Wait.Until(ElementToBeVisible(_skipToBottomButton));
            _skipToBottomButton.Click();
            return this;
        }

        [AllureStep("Click 'Agree and Continue' button")]
        public TermsOfUseModal ClickAgreeAndContinueButton()
        {
            Wait.Until(ElementToBeNotVisible(_skipToBottomButton));
            Wait.Until(ElementToBeClickable(_agreeAndContinueButton));
            _agreeAndContinueButton.Click();
            return this;
        }
    }
}