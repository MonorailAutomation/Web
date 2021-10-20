using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen
{
    public class AddTrackSuccessModal
    {
        [FindsBy(How = How.XPath, Using = "//vim-add-track-success-modal//button[contains(text(),'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div//h2[3]")]
        private IWebElement _trackNameLabel;

        public AddTrackSuccessModal(IWebDriver driver)
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

        [AllureStep("Click 'Finish' button")]
        public AddTrackSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}