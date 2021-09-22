using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen
{
    public class MilestoneDetailsModal
    {
        [FindsBy(How = How.XPath, Using = "//vim-milestone-details-modal//button[contains(text(),'Continue')]")]
        private IWebElement ContinueButton;

        [FindsBy(How = How.Id, Using = "itemDescription")]
        private IWebElement MilestoneDescriptionInput;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement MilestoneNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='targetBalance']")]
        private IWebElement MilestoneTargetAmountInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='date']")]
        private IWebElement MilestoneTargetDateInput;

        public MilestoneDetailsModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set Milestone name to '{0}'")]
        public MilestoneDetailsModal SetMilestoneName(string milestoneName)
        {
            Wait.Until(ElementToBeVisible(MilestoneNameInput));
            MilestoneNameInput.Clear();
            MilestoneNameInput.SendKeys(milestoneName);
            return this;
        }

        [AllureStep("Set Milestone description to '{0}'")]
        public MilestoneDetailsModal SetMilestoneDescription(string milestoneDescription)
        {
            Wait.Until(ElementToBeVisible(MilestoneDescriptionInput));
            MilestoneDescriptionInput.Clear();
            MilestoneDescriptionInput.SendKeys(milestoneDescription);
            return this;
        }

        [AllureStep("Set Milestone Target Amount to '${0}'")]
        public MilestoneDetailsModal SetMilestoneTargetAmount(string milestoneTargetAmount)
        {
            Wait.Until(ElementToBeVisible(MilestoneTargetAmountInput));
            MilestoneTargetAmountInput.Clear();
            MilestoneTargetAmountInput.SendKeys(milestoneTargetAmount);
            return this;
        }

        [AllureStep("Set Milestone Target Date to '{0}'")]
        public MilestoneDetailsModal SetMilestoneTargetDate(string milestoneTargetDate)
        {
            Wait.Until(ElementToBeVisible(MilestoneTargetDateInput));
            MilestoneTargetDateInput.Clear();
            MilestoneTargetDateInput.SendKeys(milestoneTargetDate);
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public MilestoneDetailsModal ClickContinueButton()
        {
            Wait.Until(ElementToBeVisible(ContinueButton));
            ContinueButton.Click();
            return this;
        }
    }
}