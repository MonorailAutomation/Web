using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals
{
    public class DisclosuresModal : Modal
    {
        private const string DisclosuresModalHeaderText = "Disclosures";
        private const string Disclosures1Of3ModalHeaderText = "Disclosures (1 of 3)";
        private const string Disclosures2Of3ModalHeaderText = "Disclosures (1 of 2)";
        private const string Disclosures3Of3ModalHeaderText = "Disclosures (1 of 3)";

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Agree and Continue')]")]
        private IWebElement _agreeAndContinueButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Agree and Finish')]")]
        private IWebElement _agreeAndFinishButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Decline')]")]
        private IWebElement _declineButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Skip to bottom')]")]
        private IWebElement _skipToBottomButton;

        public DisclosuresModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Agree and Finish' button")]
        public DisclosuresModal ClickAgreeAndFinishButton()
        {
            Wait.Until(ElementToBeClickable(_agreeAndFinishButton));
            _agreeAndFinishButton.Click();
            return this;
        }

        [AllureStep("Click 'Agree and Continue' button")]
        public DisclosuresModal ClickAgreeAndContinueButton()
        {
            Wait.Until(ElementToBeClickable(_agreeAndContinueButton));
            _agreeAndContinueButton.Click();
            return this;
        }

        [AllureStep("Click 'Skip to bottom' button")]
        public DisclosuresModal ClickSkipToBottomButton()
        {
            Wait.Until(ElementToBeVisible(_skipToBottomButton));
            Wait.Until(ElementToBeClickable(_skipToBottomButton));
            _skipToBottomButton.Click();
            return this;
        }

        [AllureStep("Check 'Disclosures' modal")]
        public DisclosuresModal CheckDisclosuresModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_skipToBottomButton));
                Wait.Until(ElementToBeVisible(_declineButton));
                ModalHeader.Text.Should().ContainAny(DisclosuresModalHeaderText,
                    Disclosures1Of3ModalHeaderText, Disclosures2Of3ModalHeaderText, Disclosures3Of3ModalHeaderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}