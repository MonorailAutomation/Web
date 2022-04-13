using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class RiskProfileEarningsQuestionModal : Modal
    {
        private const string RiskProfileModalHeaderText = "Risk Profile";
        private const string RiskQuestionText = "How much do you make in a year?";

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][2]")]
        private IWebElement _between25KAnd50KAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][3]")]
        private IWebElement _between50KAnd100KAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][1]")]
        private IWebElement _lessThan25KAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][4]")]
        private IWebElement _over100KAnswer;

        [FindsBy(How = How.XPath, Using = "//h2[@class='vim-modal__content__subtitle']")]
        private IWebElement _riskQuestion;

        public RiskProfileEarningsQuestionModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Over $100K' answer")]
        public RiskProfileEarningsQuestionModal ClickOver100K()
        {
            Wait.Until(ElementToBeVisible(_over100KAnswer));
            _over100KAnswer.Click();
            return this;
        }

        [AllureStep("Check 'Risk Profile' modal")]
        public RiskProfileEarningsQuestionModal CheckRiskProfileEarningsQuestionModal()
        {
            var count = 0;
            const int maxTries = 5;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(XButton));
                    Wait.Until(ElementToBeVisible(_lessThan25KAnswer));
                    Wait.Until(ElementToBeVisible(_between25KAnd50KAnswer));
                    Wait.Until(ElementToBeVisible(_between50KAnd100KAnswer));
                    Wait.Until(ElementToBeVisible(_over100KAnswer));
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