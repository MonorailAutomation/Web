using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals
{
    public class MilestoneDetailsModal
    {
        private const string MilestoneDetailsHeader = "Milestone Details";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Back')]")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "choosePictureDropdown")]
        private IWebElement _changeImageButton;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(),'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "itemDescription")]
        private IWebElement _milestoneDescriptionInput;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _milestoneDetailsHeader;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement _milestoneNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='targetBalance']")]
        private IWebElement _milestoneTargetAmountInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='date']")]
        private IWebElement _milestoneTargetDateInput;

        [FindsBy(How = How.XPath,
            Using = "//button[@class='vim-modal__header__button']")]
        private IWebElement _xButton;

        public MilestoneDetailsModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Milestone Details' modal")]
        public MilestoneDetailsModal CheckMilestoneDetailsModal()
        {
            Wait.Until(ElementToBeVisible(_milestoneDetailsHeader));
            Wait.Until(ElementToBeVisible(_xButton));
            Wait.Until(ElementToBeVisible(_changeImageButton));
            Wait.Until(ElementToBeVisible(_backButton));
            Wait.Until(ElementToBeVisible(_continueButton));

            _milestoneDetailsHeader.Text.Should().Contain(MilestoneDetailsHeader);

            return this;
        }

        [AllureStep("Set Milestone name to '{0}'")]
        public MilestoneDetailsModal SetMilestoneName(string milestoneName)
        {
            Wait.Until(ElementToBeVisible(_milestoneNameInput));
            _milestoneNameInput.Clear();
            _milestoneNameInput.SendKeys(milestoneName);
            return this;
        }

        [AllureStep("Set Milestone description to '{0}'")]
        public MilestoneDetailsModal SetMilestoneDescription(string milestoneDescription)
        {
            Wait.Until(ElementToBeVisible(_milestoneDescriptionInput));
            _milestoneDescriptionInput.Clear();
            _milestoneDescriptionInput.SendKeys(milestoneDescription);
            return this;
        }

        [AllureStep("Set Milestone Target Amount to '${0}'")]
        public MilestoneDetailsModal SetMilestoneTargetAmount(string milestoneTargetAmount)
        {
            Wait.Until(ElementToBeVisible(_milestoneTargetAmountInput));
            _milestoneTargetAmountInput.Clear();
            _milestoneTargetAmountInput.SendKeys(milestoneTargetAmount);
            return this;
        }

        [AllureStep("Set Milestone Target Date to '{0}'")]
        public MilestoneDetailsModal SetMilestoneTargetDate(string milestoneTargetDate)
        {
            Wait.Until(ElementToBeVisible(_milestoneTargetDateInput));
            _milestoneTargetDateInput.Clear();
            _milestoneTargetDateInput.SendKeys(milestoneTargetDate);
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public MilestoneDetailsModal ClickContinueButton()
        {
            Wait.Until(ElementToBeVisible(_continueButton));
            _continueButton.Click();
            return this;
        }

        [AllureStep("Verify if 'Target Date' is '{0}'")]
        public MilestoneDetailsModal VerifyTargetDate(string expectedTargetDate)
        {
            Wait.Until(ElementToBeVisible(_milestoneTargetDateInput));
            var actualMilestoneTargetDate = _milestoneTargetDateInput.GetAttribute("value");
            var parsedDate = DateTime.ParseExact(actualMilestoneTargetDate, "yyyy-MM-dd",
                CultureInfo.InvariantCulture).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            parsedDate.Should().Be(expectedTargetDate);
            return this;
        }
    }
}