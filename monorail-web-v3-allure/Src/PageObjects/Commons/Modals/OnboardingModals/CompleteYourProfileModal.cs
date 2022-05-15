using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals
{
    public class CompleteYourProfileModal : Modal
    {
        private const string CompleteYourProfileModalHeaderText = "Complete your Profile";

        [FindsBy(How = How.XPath, Using = "//div[@formarrayname='street'][1]//input")]
        private IWebElement _addressLine1Input;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='city']")]
        private IWebElement _cityInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='firstName']")]
        private IWebElement _firstNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='lastName']")]
        private IWebElement _lastNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@id='ssn']")]
        private IWebElement _ssnInput;

        [FindsBy(How = How.XPath, Using = "//select[@formcontrolname='state']")]
        private IWebElement _stateDropdown;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='zip']")]
        private IWebElement _zipInput;

        public CompleteYourProfileModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set 'First Name' to '${0}'")]
        public CompleteYourProfileModal SetFirstName(string firstName)
        {
            Wait.Until(ElementToBeVisible(_firstNameInput));
            _firstNameInput.SendKeys(firstName);
            return this;
        }

        [AllureStep("Set 'Last Name' to '${0}'")]
        public CompleteYourProfileModal SetLastName(string lastName)
        {
            Wait.Until(ElementToBeVisible(_lastNameInput));
            _lastNameInput.SendKeys(lastName);
            return this;
        }

        [AllureStep("Set 'Address Name' to '${0}'")]
        public CompleteYourProfileModal SetAddressLine1(string addressLine1)
        {
            Wait.Until(ElementToBeVisible(_addressLine1Input));
            _addressLine1Input.SendKeys(addressLine1);
            return this;
        }

        [AllureStep("Set 'City' to '${0}'")]
        public CompleteYourProfileModal SetCity(string city)
        {
            Wait.Until(ElementToBeVisible(_cityInput));
            _cityInput.SendKeys(city);
            return this;
        }

        [AllureStep("Set 'State' to '${0}'")]
        public CompleteYourProfileModal SetState(string state)
        {
            Wait.Until(ElementToBeVisible(_stateDropdown));
            var stateDropdown = new SelectElement(_stateDropdown);
            stateDropdown.SelectByText(state);
            return this;
        }

        [AllureStep("Set 'Zip' to '${0}'")]
        public CompleteYourProfileModal SetZip(string zip)
        {
            Wait.Until(ElementToBeVisible(_zipInput));
            _zipInput.SendKeys(zip);
            return this;
        }

        [AllureStep("Set 'SSN' to '${0}'")]
        public CompleteYourProfileModal SetSsn(string ssn)
        {
            Wait.Until(ElementToBeVisible(_ssnInput));
            _ssnInput.SendKeys(ssn);
            return this;
        }

        [AllureStep("Check 'Complete your Profile' modal")]
        public CompleteYourProfileModal CheckCompleteYourProfileModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(ConfirmButton));

                ModalHeader.Text.Should().Contain(CompleteYourProfileModalHeaderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}