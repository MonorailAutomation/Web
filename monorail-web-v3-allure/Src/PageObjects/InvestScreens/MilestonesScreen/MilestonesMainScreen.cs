using System;
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
        private IWebElement AddAMilestoneButton;

        public MilestonesMainScreen(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add a Milestone' button")]
        public MilestonesMainScreen ClickAddAMilestoneButton()
        {
            Wait.Until(ElementToBeClickable(AddAMilestoneButton));
            AddAMilestoneButton.Click();
            return this;
        }

        [AllureStep("Verify if '{0}' milestone exists")]
        public MilestonesMainScreen VerifyIfMilestoneExists(string milestoneName)
        {
            var milestoneItemSelector = "//h3[contains(text(),'" + milestoneName + "')]";
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(milestoneItemSelector)));
                Console.WriteLine("\'" + milestoneName + "\'" + " Milestone was found.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\'" + milestoneName + "\'" + " Milestone was not found.");
                throw e;
            }

            return this;
        }
    }
}