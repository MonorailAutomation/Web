using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class RiskProfileStockMarketQuestionModal : Modal
    {
        private const string RiskProfileModalHeaderText = "Risk Profile";
        private const string RiskQuestionText = "Do you know how the stock market does its thing?";

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][2]")]
        private IWebElement _notReallyAnswer;

        [FindsBy(How = How.XPath, Using = "//h2[@class='vim-modal__content__subtitle']")]
        private IWebElement _riskQuestion;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][1]")]
        private IWebElement _yesIDoAnswer;

        public RiskProfileStockMarketQuestionModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Yes, I do!' answer")]
        public RiskProfileStockMarketQuestionModal ClickYesIDoAnswer()
        {
            Wait.Until(ElementToBeVisible(_yesIDoAnswer));
            _yesIDoAnswer.Click();
            return this;
        }

        [AllureStep("Check 'Risk Profile' modal")]
        public RiskProfileStockMarketQuestionModal CheckRiskProfileStockMarketQuestionModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_yesIDoAnswer));
                Wait.Until(ElementToBeVisible(_notReallyAnswer));
                Wait.Until(ElementToBeVisible(BackButtonInSpan));
                Wait.Until(ElementToBeVisible(ContinueButtonInSpan));

                ModalHeader.Text.Should().Contain(RiskProfileModalHeaderText);
                _riskQuestion.Text.Should().Contain(RiskQuestionText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}