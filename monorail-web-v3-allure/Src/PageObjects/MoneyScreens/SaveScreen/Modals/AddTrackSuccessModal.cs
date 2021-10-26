using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals
{
    public class AddTrackSuccessModal
    {
        private const string SuccessHeader = "Nice!";
        private const string SuccessMessage = "Your new saving track is being added now.";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2[1]")]
        private IWebElement _successHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2[2]")]
        private IWebElement _successMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2[3]")]
        private IWebElement _trackNameLabel;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-modal__header__button']")]
        private IWebElement _xButton;

        public AddTrackSuccessModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Success' modal")]
        public AddTrackSuccessModal CheckSuccessModal()
        {
            Wait.Until(ElementToBeVisible(_xButton));
            Wait.Until(ElementToBeVisible(_successHeader));
            Wait.Until(ElementToBeVisible(_successMessage));
            Wait.Until(ElementToBeVisible(_finishButton));

            _successHeader.Text.Should().Contain(SuccessHeader);
            _successMessage.Text.Should().Contain(SuccessMessage);

            return this;
        }

        [AllureStep("Verify if Track's name is: {0}")]
        public AddTrackSuccessModal VerifyNameOfCreatedTrack(string trackName)
        {
            Wait.Until(ElementToBeVisible(_trackNameLabel));
            _trackNameLabel.Text.Should().Be(trackName);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public AddTrackSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}