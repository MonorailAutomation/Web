using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.ItemModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class AddTrackSuccessModal : AddItemSuccessModal
    {
        private const string SuccessHeaderText = "Nice!";
        private const string SuccessMessageText = "Your new saving track is being added now.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2[2]")]
        private IWebElement _successMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2[3]")]
        private IWebElement _trackNameLabel;

        public AddTrackSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Verify if Track's name is: {0}")]
        public AddTrackSuccessModal VerifyNameOfCreatedTrack(string trackName)
        {
            Wait.Until(ElementToBeVisible(_trackNameLabel));
            _trackNameLabel.Text.Should().Be(trackName);
            return this;
        }

        [AllureStep("Check 'Success' modal")]
        public AddTrackSuccessModal CheckSuccessModal()
        {
            try
            {
                CheckAddItemSuccessModal(SuccessHeaderText);
                Wait.Until(ElementToBeVisible(_successMessage));
                Wait.Until(ElementToBeVisible(_trackNameLabel));
                Wait.Until(ElementToBeVisible(_finishButton));

                _successMessage.Text.Should().Contain(SuccessMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}