using System;
using System.Linq;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Enums;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class ChooseATrackModal
    {
        public ChooseATrackModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
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