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
    public class ActivateYourCardCreatePinModal : Modal
    {
        private const string ActivateYourCardHeaderText = "Activate your card";
        private const string PinMessageText = "Create your pin";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _pinMessage;

        public ActivateYourCardCreatePinModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Enter PIN: ${0}")]
        public ActivateYourCardCreatePinModal EnterPin(string pin)
        {
            const string codeFieldFrontSelector = "//code-input//span[";
            const string codeFieldEndSelector = "]//input";
            var pinArray = pin.ToCharArray();

            for (var i = 1; i < pinArray.Length + 1; i++)
            {
                var codeFieldSelector = codeFieldFrontSelector + i + codeFieldEndSelector;
                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(codeFieldSelector)))
                    .SendKeys(pinArray[i - 1].ToString());
            }

            Wait.Until(ElementToBeClickable(ContinueButton));
            return this;
        }

        [AllureStep("Check 'Activate your card' modal")]
        public ActivateYourCardCreatePinModal CheckActivateYourCardCreatePinModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_pinMessage));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Be(ActivateYourCardHeaderText);
                _pinMessage.Text.Should().Be(PinMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}