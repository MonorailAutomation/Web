using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class CompleteYourAccountModal : Modal
    {
        private const string CompleteYourAccountModalHeaderText = "Complete your Account";
        private const string PersonalInformationMessageText = "Personal Information";

        private const string InformationalMessageText =
            "In order to finish setting up your account, we need more information about you.";

        private const string TimeMessageText = "This will take about 1 minute.";


        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Get Started')]")]
        private IWebElement _getStartedButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p[1]")]
        private IWebElement _informationalMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _personalInformationMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p[2]")]
        private IWebElement _timeMessage;

        public CompleteYourAccountModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Complete your Account' modal")]
        public CompleteYourAccountModal CheckCompleteYourAccountModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_personalInformationMessage));
                Wait.Until(ElementToBeVisible(_informationalMessage));
                Wait.Until(ElementToBeVisible(_timeMessage));
                Wait.Until(ElementToBeVisible(CancelButton));
                Wait.Until(ElementToBeVisible(_getStartedButton));

                ModalHeader.Text.Should().Contain(CompleteYourAccountModalHeaderText);
                _personalInformationMessage.Should().Be(PersonalInformationMessageText);
                _informationalMessage.Should().Be(InformationalMessageText);
                _timeMessage.Should().Be(TimeMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Click 'Get Started' button")]
        public CompleteYourAccountModal ClickGetStartedButton()
        {
            Wait.Until(ElementToBeClickable(_getStartedButton));
            _getStartedButton.Click();
            return this;
        }
    }
}