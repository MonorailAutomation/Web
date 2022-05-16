using System;
using System.Globalization;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.ItemModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals
{
    public class MilestoneItemDetailsModal : ItemDetailsModal
    {
        private const string MilestoneDetailsHeaderText = "Milestone Details";

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='targetBalance']")]
        private IWebElement _milestoneTargetAmountInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='text']")]
        private IWebElement _milestoneTargetDateInput;

        public MilestoneItemDetailsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set Milestone Target Amount to '${0}'")]
        public MilestoneItemDetailsModal SetMilestoneTargetAmount(string milestoneTargetAmount)
        {
            Wait.Until(ElementToBeVisible(_milestoneTargetAmountInput));
            _milestoneTargetAmountInput.Clear();
            _milestoneTargetAmountInput.SendKeys(milestoneTargetAmount);
            return this;
        }

        [AllureStep("Set Milestone Target Date to '{0}'")]
        public MilestoneItemDetailsModal SetMilestoneTargetDate(string milestoneTargetDate)
        {
            Wait.Until(ElementToBeVisible(_milestoneTargetDateInput));
            _milestoneTargetDateInput.Clear();
            _milestoneTargetDateInput.SendKeys(milestoneTargetDate);
            return this;
        }

        [AllureStep("Verify if 'Target Date' is '{0}'")]
        public MilestoneItemDetailsModal VerifyTargetDate(string expectedTargetDate)
        {
            Wait.Until(ElementToBeVisible(_milestoneTargetDateInput));
            var actualMilestoneTargetDate = _milestoneTargetDateInput.GetAttribute("value");
            var parsedDate = DateTime.ParseExact(actualMilestoneTargetDate, "yyyy-MM-dd",
                CultureInfo.InvariantCulture).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            parsedDate.Should().Be(expectedTargetDate);
            return this;
        }

        [AllureStep("Check 'Milestone Details' modal")]
        public MilestoneItemDetailsModal CheckMilestoneDetailsModal()
        {
            try
            {
                CheckItemDetailsModal(MilestoneDetailsHeaderText);
                Wait.Until(ElementToBeVisible(ItemDescriptionInput));
                Wait.Until(ElementToBeVisible(ContinueButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}