using System;
using System.Linq;
using FluentAssertions;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Enums;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class ChooseATrackModal
    {
        private const string ChooseATrackHeader = "Choose a Track";

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Cancel')]")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _chooseATrackHeader;

        [FindsBy(How = How.XPath,
            Using = "//button[@class='vim-modal__header__button']")]
        private IWebElement _xButton;

        public ChooseATrackModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Choose a Track' modal")]
        public ChooseATrackModal CheckChooseATrackModal()
        {
            Wait.Until(ElementToBeVisible(_chooseATrackHeader));
            Wait.Until(ElementToBeClickable(_xButton));
            Wait.Until(ElementToBeClickable(_cancelButton));

            _chooseATrackHeader.Text.Should().Contain(ChooseATrackHeader);

            return this;
        }

        [AllureStep("Click '{0}' Track Type")]
        public ChooseATrackModal ClickMilestoneType(TrackType trackType)
        {
            var milestoneTypeSelector = "//p[contains(text(), '" + TrackTypeToString(trackType) + "')]";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(milestoneTypeSelector))).Click();
            return this;
        }

        private static string TrackTypeToString(TrackType milestoneType)
        {
            var trackTypeString = Enum.GetName(typeof(TrackType), milestoneType);
            return string.Concat(trackTypeString.Select(x => char.IsUpper(x) ? " " + x : x.ToString()))
                .TrimStart(' ');
        }
    }
}