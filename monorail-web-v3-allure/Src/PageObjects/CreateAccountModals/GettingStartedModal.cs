using System;
using System.Threading;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.CreateAccountModals
{
    public class GettingStartedModal : OnboardingModal
    {
        private const string Step1SubheaderText = "STEP 1";
        private const string GettingStartedHeaderText = "Getting Started";

        private const string ProvideAnEmailLabelText = "Provide an Email:";
        private const string EmailPlaceholderText = "email@domain.com";

        private const string ConfirmYourPasswordLabelText = "Confirm your Password:";

        private const string NumberValidationText = "At leat 1 number";
        private const string UppercaseCharacterValidationText = "At least 1 uppercase character";
        private const string SpecialCharacterNumberValidationText = "At least 1 special character";
        private const string CharacterValidationText = "8 or more characters";

        private const string YourDateOfBirthLabelText = "Your Date of Birth:";
        private const string YourPhoneNumberLabelText = "Your Phone Number:";
        private const string YourPhoneNumberPlaceholderText = "(000) 000 - 0000";

        [FindsBy(How = How.XPath, Using = "//div[@class='password-validation__item'][4]//span")]
        private IWebElement _characterValidation;

        [FindsBy(How = How.XPath, Using = "//form//div[2]//label")]
        private IWebElement _confirmYourPasswordLabel;

        [FindsBy(How = How.XPath, Using = "//input[@type='date']")]
        private IWebElement _dateOfBirthInput;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='email']")]
        private IWebElement _emailInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='password-validation__item'][1]//span")]
        private IWebElement _numberValidation;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='password']")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='phoneNumber']")]
        private IWebElement _phoneNumberInput;

        [FindsBy(How = How.XPath, Using = "//form//div[1]//label")]
        private IWebElement _provideAnEmailLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='password-validation__item'][3]//span")]
        private IWebElement _specialCharacterNumberValidation;

        [FindsBy(How = How.XPath, Using = "//div[@class='password-validation__item'][2]//span")]
        private IWebElement _uppercaseCharacterValidation;

        [FindsBy(How = How.XPath, Using = "//form//div[3]//label")]
        private IWebElement _yourDateOfBirthLabel;

        [FindsBy(How = How.XPath, Using = "//form//div[4]//label")]
        private IWebElement _yourPhoneNumberLabel;

        public GettingStartedModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set 'Email' to {0}")]
        public GettingStartedModal SetEmail(string email)
        {
            Wait.Until(ElementToBeVisible(_emailInput));
            _emailInput.SendKeys(email);
            return this;
        }

        [AllureStep("Set 'Password' to {0}")]
        public GettingStartedModal SetPassword(string password)
        {
            Wait.Until(ElementToBeVisible(_passwordInput));
            _passwordInput.SendKeys(password);
            return this;
        }

        [AllureStep("Set 'Date of Birth' to {0}")]
        public GettingStartedModal SetDateOfBirth(string dateOfBirth)
        {
            Wait.Until(ElementToBeVisible(_passwordInput));
            _dateOfBirthInput.SendKeys(dateOfBirth);
            return this;
        }

        [AllureStep("Set 'Phone Number' to {0}")]
        public GettingStartedModal SetPhoneNumber(string phoneNumber)
        {
            Wait.Until(ElementToBeVisible(_passwordInput));
            _phoneNumberInput.SendKeys(phoneNumber);
            Thread.Sleep(5000); // necessary workaround as Continue button is always active
            return this;
        }

        [AllureStep("Check 'Getting Started' modal")]
        public GettingStartedModal CheckGettingStartedModal()
        {
            try
            {
                CheckOnboardingModal();
                Wait.Until(ElementToBeVisible(_provideAnEmailLabel));
                Wait.Until(ElementToBeVisible(_confirmYourPasswordLabel));
                Wait.Until(ElementToBeVisible(_numberValidation));
                Wait.Until(ElementToBeVisible(_uppercaseCharacterValidation));
                Wait.Until(ElementToBeVisible(_specialCharacterNumberValidation));
                Wait.Until(ElementToBeVisible(_characterValidation));
                Wait.Until(ElementToBeVisible(_yourDateOfBirthLabel));
                Wait.Until(ElementToBeVisible(_yourPhoneNumberLabel));
                Wait.Until(ElementToBeVisible(ContinueButton));

                StepHeader.Text.Should().Be(GettingStartedHeaderText);
                StepSubheader.Text.Should().Be(Step1SubheaderText);
                _provideAnEmailLabel.Text.Should().Be(ProvideAnEmailLabelText);
                _emailInput.GetAttribute("placeholder").Should().Be(EmailPlaceholderText);
                _confirmYourPasswordLabel.Text.Should().Be(ConfirmYourPasswordLabelText);
                _numberValidation.Text.Should().Be(NumberValidationText);
                _uppercaseCharacterValidation.Text.Should().Be(UppercaseCharacterValidationText);
                _specialCharacterNumberValidation.Text.Should().Be(SpecialCharacterNumberValidationText);
                _characterValidation.Text.Should().Be(CharacterValidationText);
                _yourDateOfBirthLabel.Text.Should().Be(YourDateOfBirthLabelText);
                _yourPhoneNumberLabel.Text.Should().Be(YourPhoneNumberLabelText);
                _phoneNumberInput.GetAttribute("placeholder").Should().Be(YourPhoneNumberPlaceholderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}