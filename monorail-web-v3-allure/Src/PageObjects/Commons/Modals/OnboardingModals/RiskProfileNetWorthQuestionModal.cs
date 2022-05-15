using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals
{
    public class RiskProfileNetWorthQuestionModal : Modal
    {
        private const string RiskProfileModalHeaderText = "Risk Profile";
        private const string RiskQuestionText = "What about your total net worth?";

        private const string NetWorthInfoText =
            "Net worth is the total value of all your bank and investment accounts, plus all major items like cars, houses, etc. – then subtract any debt.";

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][2]")]
        private IWebElement _between50KAnd100KAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][1]")]
        private IWebElement _lessThan50KAnswer;

        [FindsBy(How = How.XPath, Using = "//p[@class='vim-question-modal__helper-text']")]
        private IWebElement _netWorthInfo;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][3]")]
        private IWebElement _over100KAnswer;

        [FindsBy(How = How.XPath, Using = "//h2[@class='vim-modal__content__subtitle']")]
        private IWebElement _riskQuestion;

        public RiskProfileNetWorthQuestionModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Over $100K' answer")]
        public RiskProfileNetWorthQuestionModal ClickOver100K()
        {
            Wait.Until(ElementToBeVisible(_over100KAnswer));
            _over100KAnswer.Click();
            return this;
        }

        [AllureStep("Check 'Risk Profile' modal")]
        public RiskProfileNetWorthQuestionModal CheckRiskProfileNetWorthQuestionModal()
        {
            var count = 0;
            const int maxTries = 5;
            while (true)
                try
                {
                    Wait.Until(ElementToBeVisible(XButton));
                    Wait.Until(ElementToBeVisible(_lessThan50KAnswer));
                    Wait.Until(ElementToBeVisible(_between50KAnd100KAnswer));
                    Wait.Until(ElementToBeVisible(_over100KAnswer));
                    Wait.Until(ElementToBeVisible(_netWorthInfo));
                    Wait.Until(ElementToBeVisible(BackButtonInSpan));
                    Wait.Until(ElementToBeVisible(ContinueButtonInSpan));

                    ModalHeader.Text.Should().Contain(RiskProfileModalHeaderText);
                    _riskQuestion.Text.Should().Contain(RiskQuestionText);
                    _netWorthInfo.Text.Should().Contain(NetWorthInfoText);
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