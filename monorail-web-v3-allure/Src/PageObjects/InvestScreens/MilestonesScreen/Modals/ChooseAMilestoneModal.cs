using System;
using System.Linq;
using FluentAssertions;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Enums;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals
{
    public class ChooseAMilestoneModal
    {
        private const string ChooseAMilestoneHeader = "Choose a Milestone";

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Cancel')]")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _chooseAMilestoneHeader;

        [FindsBy(How = How.XPath,
            Using = "//button[@class='vim-modal__header__button']")]
        private IWebElement _xButton;

        public ChooseAMilestoneModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Choose a Milestone' modal")]
        public ChooseAMilestoneModal CheckChooseAMilestoneModal()
        {
            Wait.Until(ElementToBeVisible(_chooseAMilestoneHeader));
            Wait.Until(ElementToBeClickable(_cancelButton));

            _chooseAMilestoneHeader.Text.Should().Contain(ChooseAMilestoneHeader);

            return this;
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
            return string.Concat(milestoneTypeString.Select(x => char.IsUpper(x) ? " " + x : x.ToString()))
                .TrimStart(' ');
        }
    }
}