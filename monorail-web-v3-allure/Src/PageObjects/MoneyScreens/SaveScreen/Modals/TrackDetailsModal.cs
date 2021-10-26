using FluentAssertions;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Enums;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class TrackDetailsModal
    {
        private const string TrackDetailsHeader = "Track Details";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Back')]")]
        private IWebElement _backButton;

        [FindsBy(How = How.Id, Using = "choosePictureDropdown")]
        private IWebElement _changeImageButton;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(),'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "itemDescription")]
        private IWebElement _trackDescriptionInput;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _trackDetailsHeader;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement _trackNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='targetBalance']")]
        private IWebElement _trackTargetAmountInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='date']")]
        private IWebElement _trackTargetDateInput;

        [FindsBy(How = How.XPath,
            Using = "//button[@class='vim-modal__header__button']")]
        private IWebElement _xButton;

        public TrackDetailsModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Track Details' modal")]
        public TrackDetailsModal CheckTrackDetailsModal()
        {
            Wait.Until(ElementToBeVisible(_trackDetailsHeader));
            Wait.Until(ElementToBeVisible(_xButton));
            Wait.Until(ElementToBeVisible(_changeImageButton));
            Wait.Until(ElementToBeVisible(_backButton));
            Wait.Until(ElementToBeVisible(_continueButton));

            _trackDetailsHeader.Text.Should().Contain(TrackDetailsHeader);

            return this;
        }

        [AllureStep("Set Track icon to {0}'")]
        public TrackDetailsModal SetTrackIcon(TrackIcon trackIcon)
        {
            const string allTrackIconSelector = "//drag-scroll//div[contains(@class,'track-detail__icon-container')]";
            var trackIconNumber = (int) trackIcon;
            var particularTrackIconSelector = allTrackIconSelector + "[" + trackIconNumber + "]";
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(particularTrackIconSelector))).Click();
            return this;
        }

        [AllureStep("Set Track main color to {0}'")]
        public TrackDetailsModal SetTrackMainColor(TrackColor trackColor)
        {
            const string allTrackColorSelector = "//div[contains(@class,'track-detail__color')]";
            var trackColorNumber = (int) trackColor;
            var particularTrackColorSelector = allTrackColorSelector + "[" + trackColorNumber + "]";
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(particularTrackColorSelector))).Click();
            return this;
        }

        [AllureStep("Set Track name to '{0}'")]
        public TrackDetailsModal SetTrackName(string trackName)
        {
            Wait.Until(ElementToBeVisible(_trackNameInput));
            _trackNameInput.Clear();
            _trackNameInput.SendKeys(trackName);
            return this;
        }

        [AllureStep("Set Track description to '{0}'")]
        public TrackDetailsModal SetTrackDescription(string trackDescription)
        {
            Wait.Until(ElementToBeVisible(_trackDescriptionInput));
            _trackDescriptionInput.Clear();
            _trackDescriptionInput.SendKeys(trackDescription);
            return this;
        }

        [AllureStep("Set Track Target Amount to '${0}'")]
        public TrackDetailsModal SetTrackTargetAmount(string trackTargetAmount)
        {
            Wait.Until(ElementToBeVisible(_trackTargetAmountInput));
            _trackTargetAmountInput.Clear();
            _trackTargetAmountInput.SendKeys(trackTargetAmount);
            return this;
        }

        [AllureStep("Set Track Target Date to '{0}'")]
        public TrackDetailsModal SetTrackTargetDate(string trackTargetDate)
        {
            Wait.Until(ElementToBeVisible(_trackTargetDateInput));
            _trackTargetDateInput.Clear();
            _trackTargetDateInput.SendKeys(trackTargetDate);
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public TrackDetailsModal ClickContinueButton()
        {
            Wait.Until(ElementToBeVisible(_continueButton));
            _continueButton.Click();
            return this;
        }
    }
}