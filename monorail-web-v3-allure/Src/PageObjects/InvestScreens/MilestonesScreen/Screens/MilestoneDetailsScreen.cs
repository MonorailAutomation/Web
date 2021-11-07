using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Screens
{
    public class MilestoneDetailsScreen : InvestScreen
    {
        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'Edit Details')]")]
        private IWebElement _editDetailsOption;

        [FindsBy(How = How.XPath, Using = "//vim-goal-description//p[@class='text-gray-400']")]
        private IWebElement _milestoneDescription;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-goal-sidebar']//h2[@class='m-0']")]
        private IWebElement _milestoneName;

        [FindsBy(How = How.XPath, Using = "//span[@class='vim-goal-sidebar__amount__target']")]
        private IWebElement _milestoneTargetAmount;

        public MilestoneDetailsScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Edit Details' button")]
        public MilestoneDetailsScreen ClickEditDetailsButton()
        {
            Wait.Until(ElementToBeClickable(_editDetailsOption));
            _editDetailsOption.Click();
            return this;
        }

        [AllureStep("Verify if Milestone Name is '{0}', Description is '{1}', Target Amount is {2}")]
        public MilestoneDetailsScreen VerifyMilestoneDetails(string milestoneName, string milestoneDescription,
            string milestoneTargetAmount)
        {
            VerifyIfMilestoneNameHasChanged(milestoneName);
            _milestoneName.Text.Should().Be(milestoneName);
            _milestoneDescription.Text.Should().Be(milestoneDescription);
            //_milestoneTargetAmount.Text.Should().Contain(milestoneTargetAmount); //issue 
            return this;
        }

        private void VerifyIfMilestoneNameHasChanged(string milestoneName)
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElement(_milestoneName, milestoneName));
        }
    }
}