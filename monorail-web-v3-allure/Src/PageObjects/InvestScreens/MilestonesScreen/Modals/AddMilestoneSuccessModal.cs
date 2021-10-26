using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals
{
    public class AddMilestoneSuccessModal
    {
        private const string SuccessHeader = "Success!";
        private const string SuccessMessage = "Your milestone is being added now.";
        private const string SuccessQuote = "“Stay focused, go after your dreams and keep moving toward your goals.”";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='success-goal__footer__content']//svg-icon")]
        private IWebElement _sipcLogo;

        [FindsBy(How = How.XPath, Using = "//div[@class='success-goal__content']//h2")]
        private IWebElement _successHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='success-goal__content']//p")]
        private IWebElement _successMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='success-goal__footer__content']//p")]
        private IWebElement _successQuote;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-modal__header__button']")]
        private IWebElement _xButton;

        public AddMilestoneSuccessModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Success' modal")]
        public AddMilestoneSuccessModal CheckSuccessModal()
        {
            Wait.Until(ElementToBeVisible(_xButton));
            Wait.Until(ElementToBeVisible(_successHeader));
            Wait.Until(ElementToBeVisible(_successMessage));
            Wait.Until(ElementToBeVisible(_successQuote));
            Wait.Until(ElementToBeVisible(_sipcLogo));
            Wait.Until(ElementToBeVisible(_finishButton));

            _successHeader.Text.Should().Contain(SuccessHeader);
            _successMessage.Text.Should().Contain(SuccessMessage);
            _successQuote.Text.Should().Contain(SuccessQuote);

            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public AddMilestoneSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}