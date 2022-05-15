using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.TransactionModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class TargetAndScheduleModal : DepositScheduleModal
    {
        private const string TargetAndScheduleHeader = "Target & Schedule";

        public TargetAndScheduleModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Target & Schedule' modal")]
        public TargetAndScheduleModal CheckTargetAndScheduleModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ConfirmButton));

                ModalHeader.Text.Should().Contain(TargetAndScheduleHeader);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}