using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals
{
    public class MilestoneEditScheduleModal
    {
        private const string MilestoneEditScheduleHeader = "Edit Schedule";

        [FindsBy(How = How.Id, Using = "amount")]
        private IWebElement _amountInput;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Back')]")]
        private IWebElement _backButton;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(),'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Daily')]")]
        private IWebElement _dailyButton;

        [FindsBy(How = How.XPath, Using = "//select[@formcontrolname='dayToExecute']")]
        private IWebElement _daySelector;

        [FindsBy(How = How.XPath, Using = "//input[@id='vim-toggle-input']")]
        private IWebElement _enableDepositScheduleToggle;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _milestoneEditScheduleHeader;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Monthly')]")]
        private IWebElement _monthlyButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Weekly')]")]
        private IWebElement _weeklyButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-modal__header__button']")]
        private IWebElement _xButton;

        public MilestoneEditScheduleModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Milestone Details' modal")]
        public MilestoneEditScheduleModal CheckEditScheduleModal()
        {
            Wait.Until(ElementToBeVisible(_milestoneEditScheduleHeader));
            Wait.Until(ElementToBeVisible(_xButton));
            //Wait.Until(ElementToBeVisible(_enableDepositScheduleToggle));
            Wait.Until(ElementToBeVisible(_amountInput));
            Wait.Until(ElementToBeVisible(_dailyButton));
            Wait.Until(ElementToBeVisible(_weeklyButton));
            Wait.Until(ElementToBeVisible(_monthlyButton));
            Wait.Until(ElementToBeVisible(_daySelector));
            Wait.Until(ElementToBeVisible(_backButton));
            Wait.Until(ElementToBeVisible(_continueButton));

            _milestoneEditScheduleHeader.Text.Should().Contain(MilestoneEditScheduleHeader);

            return this;
        }


        [AllureStep("Click 'Continue' button")]
        public MilestoneEditScheduleModal ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }
    }
}