using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals
{
    public class RiskProfileInvestingExperienceQuestion : Modal
    {
        private const string RiskProfileModalHeaderText = "Risk Profile";
        private const string RiskQuestionText = "Pick the one that best describes your investing experience level.";

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][3]")]
        private IWebElement _dabblingIsTheRightWordForMeAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][2]")]
        private IWebElement _iAmARegularInvestorAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][4]")]
        private IWebElement _neverInvestedOneDollarAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][1]")]
        private IWebElement _peopleCallMeAProAnswer;

        [FindsBy(How = How.XPath, Using = "//h2[@class='vim-modal__content__subtitle']")]
        private IWebElement _riskQuestion;

        public RiskProfileInvestingExperienceQuestion(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'People call me a pro.' answer")]
        public RiskProfileInvestingExperienceQuestion ClickPeopleCallMeAProAnswer()
        {
            Wait.Until(ElementToBeVisible(_peopleCallMeAProAnswer));
            _peopleCallMeAProAnswer.Click();
            return this;
        }

        [AllureStep("Check 'Risk Profile' modal")]
        public RiskProfileInvestingExperienceQuestion CheckRiskProfileInvestingExperienceQuestionModal()
        {
            var count = 0;
            const int maxTries = 5;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(XButton));
                    Wait.Until(ElementToBeVisible(_peopleCallMeAProAnswer));
                    Wait.Until(ElementToBeVisible(_iAmARegularInvestorAnswer));
                    Wait.Until(ElementToBeVisible(_dabblingIsTheRightWordForMeAnswer));
                    Wait.Until(ElementToBeVisible(_neverInvestedOneDollarAnswer));
                    Wait.Until(ElementToBeVisible(BackButtonInSpan));
                    Wait.Until(ElementToBeVisible(ContinueButtonInSpan));

                    ModalHeader.Text.Should().Contain(RiskProfileModalHeaderText);
                    _riskQuestion.Text.Should().Contain(RiskQuestionText);
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