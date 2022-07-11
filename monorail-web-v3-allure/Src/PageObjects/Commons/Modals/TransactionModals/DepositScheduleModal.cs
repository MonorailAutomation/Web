using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using FluentAssertions;
using static monorail_web_v3.Commons.Functions;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.TransactionModals
{
    public class DepositScheduleModal : Modal
    {
        private const string TargetAndScheduleHeaderText = "Target & Schedule";
        private const string DepositScheduleHeaderText = "Deposit Schedule";
        private const string DayOfTheWeekOrMonthLabelXPath = "//form//div[3]//label";
        private const string DayOfTheWeekOrMonthSelectorXPath = "//select[@formcontrolname='dayToExecute']";

        private const string DepositAmountLabelText = "Deposit Amount";
        private const string FrequencyLabelText = "Frequency";
        private const string DayOfTheWeekLabelText = "Day of the Week";
        private const string DayOfTheMonthLabelText = "Day of the Month";

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Daily')]")]
        private IWebElement _dailyButton;

        [FindsBy(How = How.XPath, Using = DayOfTheWeekOrMonthLabelXPath)]
        private IWebElement _dayOfTheWeekOrMonthLabel;

        [FindsBy(How = How.XPath, Using = DayOfTheWeekOrMonthSelectorXPath)]
        private IWebElement _dayOfTheWeekOrMonthSelector;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement _depositAmountInput;

        [FindsBy(How = How.XPath, Using = "//form//div[1]//label")]
        private IWebElement _depositAmountLabel;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//vim-toggle")]
        private IWebElement _depositScheduleSwitch;

        [FindsBy(How = How.XPath, Using = "//form//div[2]//label")]
        private IWebElement _frequencyLabel;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Monthly')]")]
        private IWebElement _monthlyButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Weekly')]")]
        private IWebElement _weeklyButton;

        public DepositScheduleModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Daily' button")]
        public DepositScheduleModal ClickDailyButton()
        {
            Wait.Until(ElementToBeVisible(_dailyButton));
            _dailyButton.Click();
            return this;
        }

        [AllureStep("Click 'Weekly' button")]
        public DepositScheduleModal ClickWeeklyButton()
        {
            Wait.Until(ElementToBeVisible(_weeklyButton));
            _weeklyButton.Click();
            return this;
        }

        [AllureStep("Click 'Monthly' button")]
        public DepositScheduleModal ClickMonthlyButton()
        {
            Wait.Until(ElementToBeVisible(_monthlyButton));
            _monthlyButton.Click();
            return this;
        }

        [AllureStep("Set 'Deposit Amount' to ${0}")]
        public DepositScheduleModal SetDepositAmount(string depositAmount)
        {
            Wait.Until(ElementToBeVisible(_depositAmountInput));
            _depositAmountInput.Clear();
            _depositAmountInput.SendKeys(depositAmount);
            return this;
        }

        [AllureStep("Set Day to: ${0}")]
        public DepositScheduleModal SetDepositDayFromDropdown(string depositDay)
        {
            Wait.Until(ElementToBeVisible(_dayOfTheWeekOrMonthSelector));
            var dayDropdown = new SelectElement(_dayOfTheWeekOrMonthSelector);
            dayDropdown.SelectByText(depositDay);
            return this;
        }

        [AllureStep("Check 'Deposit Schedule' modal for: ${0} frequency")]
        public DepositScheduleModal CheckDepositScheduleModal(string depositFrequency)
        {
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_depositAmountInput));
                Wait.Until(ElementToBeVisible(_dailyButton));
                Wait.Until(ElementToBeVisible(_weeklyButton));
                Wait.Until(ElementToBeVisible(_monthlyButton));

                switch (depositFrequency)
                {
                    case "Daily":
                        IsElementNotVisibleByXpath(DayOfTheWeekOrMonthLabelXPath, Driver).Should().BeTrue();
                        IsElementNotVisibleByXpath(DayOfTheWeekOrMonthSelectorXPath, Driver).Should().BeTrue();
                        break;
                    case "Weekly":
                        Wait.Until(ElementToBeVisible(_dayOfTheWeekOrMonthLabel));
                        Wait.Until(ElementToBeVisible(_dayOfTheWeekOrMonthSelector));
                        _dayOfTheWeekOrMonthLabel.Text.Should().Be(DayOfTheWeekLabelText);
                        break;
                    case "Monthly":
                        Wait.Until(ElementToBeVisible(_dayOfTheWeekOrMonthLabel));
                        Wait.Until(ElementToBeVisible(_dayOfTheWeekOrMonthSelector));
                        _dayOfTheWeekOrMonthLabel.Text.Should().Be(DayOfTheMonthLabelText);
                        break;
                }

                ModalHeader.Text.Should().ContainAny(TargetAndScheduleHeaderText, DepositScheduleHeaderText);
                _depositAmountLabel.Text.Should().Be(DepositAmountLabelText);
                _frequencyLabel.Text.Should().Be(FrequencyLabelText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}