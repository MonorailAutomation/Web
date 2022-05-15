using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals.ActivateYourCardModals
{
    public class ActivateYourCardBirthdayModal : Modal
    {
        private const string ActivateYourCardHeaderText = "Activate your card";
        private const string BirthdayQuestionText = "What is your birthday?";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _birthdayInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//label")]
        private IWebElement _birthdayQuestion;

        public ActivateYourCardBirthdayModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Enter birthday: ${0}")]
        public ActivateYourCardBirthdayModal EnterBirthday(string last4Numbers)
        {
            Wait.Until(ElementToBeVisible(_birthdayInput));
            _birthdayInput.SendKeys(last4Numbers);
            return this;
        }

        [AllureStep("Check 'Activate your card' modal")]
        public ActivateYourCardBirthdayModal CheckActivateYourCardBirthdayModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_birthdayQuestion));
                Wait.Until(ElementToBeVisible(_birthdayInput));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Be(ActivateYourCardHeaderText);
                _birthdayQuestion.Text.Should().Be(BirthdayQuestionText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}