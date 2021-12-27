using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class RiskProfileLiquidQuestionModal : Modal
    {
        private const string RiskProfileModalHeaderText = "Risk Profile";
        private const string RiskQuestionText = "How much of that is liquid?";

        private const string LiquidInfoText =
            "Liquid means money that is readily available. Money in your bank account is liquid. Money tied up in a car isn’t.";

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][2]")]
        private IWebElement _between50KAnd100KAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][1]")]
        private IWebElement _lessThan50KAnswer;

        [FindsBy(How = How.XPath, Using = "//p[@class='vim-question-modal__helper-text']")]
        private IWebElement _liquidInfo;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][3]")]
        private IWebElement _over100KAnswer;


        [FindsBy(How = How.XPath, Using = "//h2[@class='vim-modal__content__subtitle']")]
        private IWebElement _riskQuestion;

        public RiskProfileLiquidQuestionModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Over $100K' answer")]
        public RiskProfileLiquidQuestionModal ClickOver100K()
        {
            Wait.Until(ElementToBeVisible(_over100KAnswer));
            _over100KAnswer.Click();
            return this;
        }

        [AllureStep("Check 'Risk Profile' modal")]
        public RiskProfileLiquidQuestionModal CheckRiskProfileLiquidQuestionModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_lessThan50KAnswer));
                Wait.Until(ElementToBeVisible(_between50KAnd100KAnswer));
                Wait.Until(ElementToBeVisible(_over100KAnswer));
                Wait.Until(ElementToBeVisible(_liquidInfo));
                Wait.Until(ElementToBeVisible(BackButtonInSpan));
                Wait.Until(ElementToBeVisible(ContinueButtonInSpan));

                ModalHeader.Text.Should().Contain(RiskProfileModalHeaderText);
                _riskQuestion.Text.Should().Contain(RiskQuestionText);
                _liquidInfo.Text.Should().Contain(LiquidInfoText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}