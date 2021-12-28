using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Screens
{
    public class MilestonesMainScreen : InvestScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Add a Milestone')]")]
        private IWebElement _addAMilestoneButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='empty-card__container'][1]")]
        private IWebElement _firstPlaceholderCard;

        [FindsBy(How = How.XPath, Using = "//div[@class='empty-card__container'][2]")]
        private IWebElement _secondPlaceholderCard;

        public MilestonesMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add a Milestone' button")]
        public MilestonesMainScreen ClickAddAMilestoneButton()
        {
            Wait.Until(ElementToBeClickable(_addAMilestoneButton));
            _addAMilestoneButton.Click();
            return this;
        }

        [AllureStep("Click '+' placeholder card")]
        public MilestonesMainScreen ClickPlaceholderCard()
        {
            Wait.Until(ElementToBeClickable(_firstPlaceholderCard));
            _firstPlaceholderCard.Click();
            return this;
        }

        [AllureStep("Verify if '{0}' milestone exists")]
        public MilestonesMainScreen VerifyIfMilestoneExists(string milestoneName)
        {
            VerifyIfMilestoneIsVisible(milestoneName);
            return this;
        }

        [AllureStep("Verify if '{0}' milestone exists with ${1} target amount")]
        public MilestonesMainScreen VerifyIfMilestoneExists(string milestoneName, string milestoneTargetAmount)
        {
            VerifyIfMilestoneIsVisible(milestoneName);
            VerifyIfTargetAmountIsVisible(milestoneName, milestoneTargetAmount);
            VerifyIfProgressBarIsVisible(milestoneName);
            return this;
        }

        [AllureStep("Click '{0}' Milestone")]
        public MilestonesMainScreen ClickMilestone(string milestoneName)
        {
            var milestoneItemSelector = By.XPath("//h3[contains(text(),'" + milestoneName + "')]");
            VerifyIfMilestoneIsVisible(milestoneName);
            Driver.FindElement(milestoneItemSelector).Click();
            return this;
        }

        private static void VerifyIfProgressBarIsVisible(string milestoneName)
        {
            var progressBarSelector =
                By.XPath("//h3[contains(text(),'" + milestoneName + "')]//following-sibling::div");

            Wait.Until(ExpectedConditions.ElementIsVisible(progressBarSelector));
        }

        private static void VerifyIfTargetAmountIsVisible(string milestoneName, string milestoneTargetAmount)
        {
            var expectedMilestoneAmount = "$0 of $" + milestoneTargetAmount;
            var milestoneTargetAmountSelector =
                By.XPath("//h3[contains(text(),'" + milestoneName + "')]//following-sibling::p");

            Wait.Until(ExpectedConditions.ElementIsVisible(milestoneTargetAmountSelector));
            var actualMilestoneAmount = Driver.FindElement(milestoneTargetAmountSelector).Text;
            actualMilestoneAmount.Should().Be(expectedMilestoneAmount);
        }

        private static void VerifyIfMilestoneIsVisible(string milestoneName)
        {
            var milestoneItemSelector = By.XPath("//h3[contains(text(),'" + milestoneName + "')]");
            Wait.Until(ExpectedConditions.ElementIsVisible(milestoneItemSelector));
        }
    }
}