using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals
{
    public class RiskProfileMarketLossQuestionModal : Modal
    {
        private const string RiskProfileModalHeaderText = "Risk Profile";
        private const string RiskQuestionText = "If the stock market lost over 30% of its value. How would you react?";

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][5]")]
        private IWebElement _iAmStraightConfusedAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][1]")]
        private IWebElement _perfectTimeToBuyAnswer;

        [FindsBy(How = How.XPath, Using = "//h2[@class='vim-modal__content__subtitle']")]
        private IWebElement _riskQuestion;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][2]")]
        private IWebElement _sellEverythingImOutAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][3]")]
        private IWebElement _sellingSomeThatsForSureAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][4]")]
        private IWebElement _takeADeepBreathAndWaitAnswer;

        public RiskProfileMarketLossQuestionModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Perfect time to buy!' answer")]
        public RiskProfileMarketLossQuestionModal ClickPerfectTimeToBuyAnswer()
        {
            Wait.Until(ElementToBeVisible(_perfectTimeToBuyAnswer));
            _perfectTimeToBuyAnswer.Click();
            return this;
        }

        [AllureStep("Check 'Risk Profile' modal")]
        public RiskProfileMarketLossQuestionModal CheckRiskProfileLossQuestionModal()
        {
            var count = 0;
            const int maxTries = 8;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(XButton));
                    Wait.Until(ElementToBeVisible(_perfectTimeToBuyAnswer));
                    Wait.Until(ElementToBeVisible(_sellEverythingImOutAnswer));
                    Wait.Until(ElementToBeVisible(_sellingSomeThatsForSureAnswer));
                    Wait.Until(ElementToBeVisible(_iAmStraightConfusedAnswer));
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