using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class TrackDepositScheduleModal : DepositScheduleModal
    {
        private const string DepositScheduleHeader = "Deposit Schedule";

        public TrackDepositScheduleModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Target & Schedule' modal")]
        public TrackDepositScheduleModal CheckTargetAndScheduleModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ContinueButton));
                Wait.Until(ElementToBeVisible(BackButton));

                ModalHeader.Text.Should().Contain(DepositScheduleHeader);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}