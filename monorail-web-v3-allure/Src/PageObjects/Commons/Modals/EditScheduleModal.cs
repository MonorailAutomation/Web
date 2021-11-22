using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class EditScheduleModal : Modal
    {
        private const string EditScheduleHeader = "Edit Schedule";

        [FindsBy(How = How.Id, Using = "amount")]
        private IWebElement _amountInput;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Daily')]")]
        private IWebElement _dailyButton;

        [FindsBy(How = How.XPath, Using = "//select[@formcontrolname='dayToExecute']")]
        private IWebElement _daySelector;

        [FindsBy(How = How.XPath, Using = "//input[@id='vim-toggle-input']")]
        private IWebElement _enableDepositScheduleToggle;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Monthly')]")]
        private IWebElement _monthlyButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Weekly')]")]
        private IWebElement _weeklyButton;

        public EditScheduleModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Edit Schedule' modal")]
        public EditScheduleModal CheckEditScheduleModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(XButton));
                //Wait.Until(ElementToBeVisible(_enableDepositScheduleToggle));
                Wait.Until(ElementToBeVisible(_amountInput));
                Wait.Until(ElementToBeVisible(_dailyButton));
                Wait.Until(ElementToBeVisible(_weeklyButton));
                Wait.Until(ElementToBeVisible(_monthlyButton));
                Wait.Until(ElementToBeVisible(_daySelector));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Contain(EditScheduleHeader);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }
    }
}