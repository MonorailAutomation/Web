using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen
{
    public class MilestonesMainScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Add a Milestone')]")]
        private IWebElement _addAMilestoneButton;

        public MilestonesMainScreen(IWebDriver driver)
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

        private static void VerifyIfProgressBarIsNotVisible(string milestoneName)
        {
            var progressBarSelector =
                By.XPath("//h3[contains(text(),'" + milestoneName + "')]//following-sibling::div");
            try
            {
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(progressBarSelector));
                Console.WriteLine("Progress Bar was not found for \'" + milestoneName + "\'" + " Milestone.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Progress Bar was found for \'" + milestoneName + "\'" + " Milestone.");
                throw e;
            }
        }

        private static void VerifyIfProgressBarIsVisible(string milestoneName)
        {
            var progressBarSelector =
                By.XPath("//h3[contains(text(),'" + milestoneName + "')]//following-sibling::div");
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(progressBarSelector));
                Console.WriteLine("Progress Bar was found for \'" + milestoneName + "\'" + " Milestone.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Progress Bar was not found for \'" + milestoneName + "\'" + " Milestone.");
                throw e;
            }
        }

        private static void VerifyIfTargetAmountIsVisible(string milestoneName, string milestoneTargetAmount)
        {
            var expectedMilestoneAmount = "$0 of $" + milestoneTargetAmount;
            var milestoneTargetAmountSelector =
                By.XPath("//h3[contains(text(),'" + milestoneName + "')]//following-sibling::p");
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(milestoneTargetAmountSelector));
                var actualMilestoneAmount = Driver.FindElement(milestoneTargetAmountSelector).Text;
                actualMilestoneAmount.Should().Be(expectedMilestoneAmount);
                Console.WriteLine("$" + milestoneTargetAmount + "was found for " + milestoneName + "Milestone.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\'" + milestoneTargetAmount + "\'" + " Target Amount was not found for \'" +
                                  milestoneName + "\'" + " Milestone.");
                throw e;
            }
        }

        private static void VerifyIfMilestoneIsVisible(string milestoneName)
        {
            var milestoneItemSelector = By.XPath("//h3[contains(text(),'" + milestoneName + "')]");
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(milestoneItemSelector));
                Console.WriteLine("\'" + milestoneName + "\'" + " Milestone was found.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\'" + milestoneName + "\'" + " Milestone was not found.");
                throw e;
            }
        }
    }
}