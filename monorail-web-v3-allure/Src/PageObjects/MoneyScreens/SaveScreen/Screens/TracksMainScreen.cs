using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens
{
    public class TracksMainScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Add Saving Track')]")]
        private IWebElement _addSavingTrackButton;

        public TracksMainScreen(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add Saving Track' button")]
        public TracksMainScreen ClickAddSavingTrackButton()
        {
            Wait.Until(ElementToBeClickable(_addSavingTrackButton));
            _addSavingTrackButton.Click();
            return this;
        }

        [AllureStep("Verify if '{0}' track exists with ${1} target amount")]
        public TracksMainScreen VerifyIfTrackExists(string trackName, string trackTargetAmount)
        {
            VerifyIfTrackIsVisible(trackName);
            VerifyIfTargetAmountIsVisible(trackName, trackTargetAmount);
            VerifyIfProgressBarIsVisible(trackName);
            return this;
        }

        private static void VerifyIfProgressBarIsVisible(string trackName)
        {
            var progressBarSelector =
                By.XPath("//h3[contains(text(),'" + trackName + "')]//following-sibling::div");
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(progressBarSelector));
                Console.WriteLine("Progress Bar was found for \'" + trackName + "\'" + " Track.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Progress Bar was not found for \'" + trackName + "\'" + " Track.");
                throw e;
            }
        }

        private static void VerifyIfTargetAmountIsVisible(string trackName, string trackTargetAmount)
        {
            var expectedTrackAmount = "$0 of $" + trackTargetAmount;
            var trackTargetAmountSelector =
                By.XPath("//h3[contains(text(),'" + trackName + "')]//following-sibling::p");
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(trackTargetAmountSelector));
                var actualTrackAmount = Driver.FindElement(trackTargetAmountSelector).Text;
                actualTrackAmount.Should().Be(expectedTrackAmount);
                Console.WriteLine("$" + trackTargetAmount + " Target Amount was found for '" + trackName +
                                  "' Track.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\'" + trackTargetAmount + "\'" + " Target Amount was not found for \'" +
                                  trackName + "\'" + " Track.");
                throw e;
            }
        }

        private static void VerifyIfTrackIsVisible(string trackName)
        {
            var trackItemSelector = By.XPath("//h3[contains(text(),'" + trackName + "')]");
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(trackItemSelector));
                Console.WriteLine("\'" + trackName + "\'" + " Track was found.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\'" + trackName + "\'" + " Track was not found.");
                throw e;
            }
        }
    }
}