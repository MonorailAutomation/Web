using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class AddATrustedContactModal : Modal
    {
        private const string AddATrustedContactModalHeaderText = "Add a Trusted Contact";

        [FindsBy(How = How.XPath, Using = "//div[@formarrayname='street'][1]//input")]
        private IWebElement _addressLine1Input;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='city']")]
        private IWebElement _cityInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement _emailInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='firstName']")]
        private IWebElement _firstNameInput;

        [FindsBy(How = How.XPath, Using = "//form//button")]
        private IWebElement _iDontWantToAddATrustedContactButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='lastName']")]
        private IWebElement _lastNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='phoneNumber']")]
        private IWebElement _phoneNumberInput;

        [FindsBy(How = How.XPath, Using = "//select[@formcontrolname='state']")]
        private IWebElement _stateDropdown;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='zip']")]
        private IWebElement _zipInput;

        public AddATrustedContactModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'I don't want to add a Trusted Contact'")]
        public AddATrustedContactModal ClickIDontWantToAddATrustedContactModal()
        {
            Wait.Until(ElementToBeClickable(_iDontWantToAddATrustedContactButton));
            _iDontWantToAddATrustedContactButton.Click();
            return this;
        }

        [AllureStep("Set 'First Name' to '${0}'")]
        public AddATrustedContactModal SetFirstName(string firstName)
        {
            Wait.Until(ElementToBeVisible(_firstNameInput));
            _firstNameInput.SendKeys(firstName);
            return this;
        }

        [AllureStep("Set 'Last Name' to '${0}'")]
        public AddATrustedContactModal SetLastName(string lastName)
        {
            Wait.Until(ElementToBeVisible(_lastNameInput));
            _lastNameInput.SendKeys(lastName);
            return this;
        }

        [AllureStep("Set 'Email' to '${0}'")]
        public AddATrustedContactModal SetEmail(string email)
        {
            Wait.Until(ElementToBeVisible(_emailInput));
            _emailInput.SendKeys(email);
            return this;
        }

        [AllureStep("Set 'Address Name' to '${0}'")]
        public AddATrustedContactModal SetAddressLine1(string addressLine1)
        {
            Wait.Until(ElementToBeVisible(_addressLine1Input));
            _addressLine1Input.SendKeys(addressLine1);
            return this;
        }

        [AllureStep("Set 'City' to '${0}'")]
        public AddATrustedContactModal SetCity(string city)
        {
            Wait.Until(ElementToBeVisible(_cityInput));
            _cityInput.SendKeys(city);
            return this;
        }

        [AllureStep("Set 'State' to '${0}'")]
        public AddATrustedContactModal SetState(string state)
        {
            Wait.Until(ElementToBeVisible(_stateDropdown));
            var stateDropdown = new SelectElement(_stateDropdown);
            stateDropdown.SelectByText(state);
            return this;
        }

        [AllureStep("Set 'Zip' to '${0}'")]
        public AddATrustedContactModal SetZip(string zip)
        {
            Wait.Until(ElementToBeVisible(_zipInput));
            _zipInput.SendKeys(zip);
            return this;
        }

        [AllureStep("Set 'SSN' to '${0}'")]
        public AddATrustedContactModal SetPhoneNumber(string phoneNumber)
        {
            Wait.Until(ElementToBeVisible(_phoneNumberInput));
            _phoneNumberInput.SendKeys(phoneNumber);
            return this;
        }

        [AllureStep("Check 'Add a Trusted Contact' modal")]
        public AddATrustedContactModal CheckAddATrustedContactModal()
        {
            try
            {
                CheckAddTrustedContactModal();
                Wait.Until(ElementToBeVisible(_iDontWantToAddATrustedContactButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check 'Add a Trusted Contact' modal for >55 yo user")]
        public AddATrustedContactModal CheckAddATrustedContactOver55YoModal()
        {
            try
            {
                CheckAddTrustedContactModal();
                Wait.Until(ElementToBeNotVisible(_iDontWantToAddATrustedContactButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        private void CheckAddTrustedContactModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_firstNameInput));
                Wait.Until(ElementToBeVisible(_lastNameInput));
                Wait.Until(ElementToBeVisible(_emailInput));
                Wait.Until(ElementToBeVisible(_addressLine1Input));
                Wait.Until(ElementToBeVisible(_cityInput));
                Wait.Until(ElementToBeVisible(_stateDropdown));
                Wait.Until(ElementToBeVisible(_zipInput));
                Wait.Until(ElementToBeVisible(_phoneNumberInput));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(ConfirmButton));

                ModalHeader.Text.Should().Contain(AddATrustedContactModalHeaderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}