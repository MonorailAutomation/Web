using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals
{
    public class ActivateYourCardLastDigitsModal : Modal
    {
        private const string ActivateYourCardHeaderText = "Activate your card";
        private const string EnterLast4NumbersMessageText = "Enter the last 4 numbers on your card";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _enterLast4NumbersMessage;

        public ActivateYourCardLastDigitsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Enter last 4 numbers on card: ${0}")]
        public ActivateYourCardLastDigitsModal EnterLast4NumbersOnCard(string last4Numbers)
        {
            const string codeFieldFrontSelector = "//code-input//span[";
            const string codeFieldEndSelector = "]//input";
            var last4NumbersArray = last4Numbers.ToCharArray();

            for (var i = 1; i < last4NumbersArray.Length + 1; i++)
            {
                var codeFieldSelector = codeFieldFrontSelector + i + codeFieldEndSelector;
                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(codeFieldSelector)))
                    .SendKeys(last4NumbersArray[i - 1].ToString());
            }

            Wait.Until(ElementToBeClickable(ContinueButton));
            return this;
        }

        [AllureStep("Check 'Activate your card' modal")]
        public ActivateYourCardLastDigitsModal CheckActivateYourCardLastDigitsModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_enterLast4NumbersMessage));
                Wait.Until(ElementToBeVisible(CancelButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Be(ActivateYourCardHeaderText);
                _enterLast4NumbersMessage.Text.Should().Be(EnterLast4NumbersMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}