using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class RegulatoryInformationPoliticallyExposedQuestionModal : Modal
    {
        private const string RegulatoryInformationModalHeaderText = "Regulatory Information";
        private const string QuestionText = "Are you, or family, politically exposed or a public official?";

        private const string HelperText =
            "Politically exposed means one who has been entrusted with a prominent public function.";

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath, Using = "//p[@class='vim-question-modal__helper-text']")]
        private IWebElement _helperText;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][2]")]
        private IWebElement _nopeAnswer;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__content']//h2")]
        private IWebElement _question;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][1]")]
        private IWebElement _yesAnswer;

        public RegulatoryInformationPoliticallyExposedQuestionModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Nope!' answer")]
        public RegulatoryInformationPoliticallyExposedQuestionModal ClickNopeAnswer()
        {
            Wait.Until(ElementToBeVisible(_nopeAnswer));
            _nopeAnswer.Click();
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public RegulatoryInformationPoliticallyExposedQuestionModal ClickContinueButton()
        {
            Wait.Until(ElementToBeVisible(_continueButton));
            _continueButton.Click();
            return this;
        }

        [AllureStep("Check 'Regulatory Information' modal")]
        public RegulatoryInformationPoliticallyExposedQuestionModal
            CheckRegulatoryInformationPoliticallyExposedQuestionModal()
        {
            var count = 0;
            const int maxTries = 5;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(XButton));
                    Wait.Until(ElementToBeVisible(_question));
                    Wait.Until(ElementToBeVisible(_yesAnswer));
                    Wait.Until(ElementToBeVisible(_nopeAnswer));
                    Wait.Until(ElementToBeVisible(BackButtonInSpan));
                    Wait.Until(ElementToBeVisible(ContinueButtonInSpan));

                    ModalHeader.Text.Should().Contain(RegulatoryInformationModalHeaderText);
                    _question.Text.Should().Be(QuestionText);
                    _helperText.Text.Should().Be(HelperText);
                    break;
                }
                catch (Exception e)
                {
                    if (++count == maxTries) throw e;
                }

            return this;
        }
    }
}