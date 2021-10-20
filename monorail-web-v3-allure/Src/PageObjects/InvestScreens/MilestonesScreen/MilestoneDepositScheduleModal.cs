using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen
{
    public class MilestoneDepositScheduleModal
    {
        [FindsBy(How = How.XPath, Using = "//vim-deposit-schedule-modal//button[contains(text(),'Continue')]")]
        private IWebElement _continueButton;

        public MilestoneDepositScheduleModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public MilestoneDepositScheduleModal ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }
    }
}