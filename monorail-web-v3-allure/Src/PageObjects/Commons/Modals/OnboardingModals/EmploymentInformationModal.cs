using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals
{
    public class EmploymentInformationModal : Modal
    {
        private const string EmploymentInformationModalHeaderText = "Employment Information";
        private const string EmploymentQuestionText = "What is your current employment status?";

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][2]")]
        private IWebElement _employedAnswer;

        [FindsBy(How = How.XPath, Using = "//h2[@class='vim-modal__content__subtitle']")]
        private IWebElement _employmentQuestion;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][3]")]
        private IWebElement _retiredAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][1]")]
        private IWebElement _studentAnswer;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-checkbox-selector__item'][4]")]
        private IWebElement _unemployedAnswer;

        public EmploymentInformationModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Unemployed' answer")]
        public EmploymentInformationModal ClickUnemployedAnswer()
        {
            Wait.Until(ElementToBeVisible(_unemployedAnswer));
            _unemployedAnswer.Click();
            return this;
        }

        [AllureStep("Check 'Employment Information' modal")]
        public EmploymentInformationModal CheckEmploymentInformationModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_studentAnswer));
                Wait.Until(ElementToBeVisible(_employedAnswer));
                Wait.Until(ElementToBeVisible(_retiredAnswer));
                Wait.Until(ElementToBeVisible(_unemployedAnswer));
                Wait.Until(ElementToBeVisible(BackButtonInSpan));
                Wait.Until(ElementToBeVisible(ContinueButtonInSpan));

                ModalHeader.Text.Should().Contain(EmploymentInformationModalHeaderText);
                _employmentQuestion.Text.Should().Contain(EmploymentQuestionText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}