using System;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen
{
    public class ChooseAMilestoneModal
    {
        public ChooseAMilestoneModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click '{0}' Milestone Type")]
        public ChooseAMilestoneModal ClickMilestoneType(MilestoneType milestoneType)
        {
            var milestoneTypeSelector = "//p[contains(text(), '" + MilestoneTypeToString(milestoneType) + "')]";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(milestoneTypeSelector))).Click();
            return this;
        }

        private static string MilestoneTypeToString(MilestoneType milestoneType)
        {
            var milestoneTypeString = Enum.GetName(typeof(MilestoneType), milestoneType);
            //Console.WriteLine(milestoneTypeString);

            return milestoneTypeString.Replace("_", " ");
        }
    }
}