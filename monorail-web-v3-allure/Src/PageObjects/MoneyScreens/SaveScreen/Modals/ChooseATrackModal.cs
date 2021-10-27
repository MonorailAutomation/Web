using System;
using System.Linq;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Enums;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class ChooseATrackModal : ChooseATypeModal
    {
        private const string ChooseATrackHeaderText = "Choose a Track";

        public ChooseATrackModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Choose a Track' modal")]
        public ChooseATrackModal CheckChooseATrackModal()
        {
            CheckChooseATypeModal(ChooseATrackHeaderText);
            return this;
        }

        [AllureStep("Click '{0}' Track Type")]
        public ChooseATrackModal ClickMilestoneType(TrackType trackType)
        {
            var trackTypeSelector = "//p[contains(text(), '" + TrackTypeToString(trackType) + "')]";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(trackTypeSelector))).Click();
            return this;
        }

        private static string TrackTypeToString(TrackType trackType)
        {
            var trackTypeString = Enum.GetName(typeof(TrackType), trackType);
            return string.Concat(trackTypeString.Select(x => char.IsUpper(x) ? " " + x : x.ToString()))
                .TrimStart(' ');
        }
    }
}