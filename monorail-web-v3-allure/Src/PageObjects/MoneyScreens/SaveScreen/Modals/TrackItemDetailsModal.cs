using System;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Enums;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class TrackItemDetailsModal : ItemDetailsModal
    {
        private const string TrackDetailsHeaderText = "Track Details";

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='targetBalance']")]
        private IWebElement _trackTargetAmountInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='date']")]
        private IWebElement _trackTargetDateInput;

        public TrackItemDetailsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Track Details' modal")]
        public TrackItemDetailsModal CheckTrackDetailsModal()
        {
            try
            {
                CheckItemDetailsModal(TrackDetailsHeaderText);
                Wait.Until(ElementToBeVisible(ItemDescriptionInput));
                Wait.Until(ElementToBeVisible(_trackTargetAmountInput));
                Wait.Until(ElementToBeVisible(_trackTargetDateInput));
                Wait.Until(ElementToBeVisible(ContinueButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }

        [AllureStep("Set Track icon to {0}'")]
        public TrackItemDetailsModal SetTrackIcon(TrackIcon trackIcon)
        {
            const string allTrackIconSelector = "//drag-scroll//div[contains(@class,'track-detail__icon-container')]";
            var trackIconNumber = (int) trackIcon;
            var particularTrackIconSelector = allTrackIconSelector + "[" + trackIconNumber + "]";
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(particularTrackIconSelector))).Click();
            return this;
        }

        [AllureStep("Set Track main color to {0}'")]
        public TrackItemDetailsModal SetTrackMainColor(TrackColor trackColor)
        {
            const string allTrackColorSelector = "//div[contains(@class,'track-detail__color')]";
            var trackColorNumber = (int) trackColor;
            var particularTrackColorSelector = allTrackColorSelector + "[" + trackColorNumber + "]";
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(particularTrackColorSelector))).Click();
            return this;
        }

        [AllureStep("Set Track Target Amount to '${0}'")]
        public TrackItemDetailsModal SetTrackTargetAmount(string trackTargetAmount)
        {
            Wait.Until(ElementToBeVisible(_trackTargetAmountInput));
            _trackTargetAmountInput.Clear();
            _trackTargetAmountInput.SendKeys(trackTargetAmount);
            return this;
        }

        [AllureStep("Set Track Target Date to '{0}'")]
        public TrackItemDetailsModal SetTrackTargetDate(string trackTargetDate)
        {
            Wait.Until(ElementToBeVisible(_trackTargetDateInput));
            _trackTargetDateInput.Clear();
            _trackTargetDateInput.SendKeys(trackTargetDate);
            return this;
        }
    }
}