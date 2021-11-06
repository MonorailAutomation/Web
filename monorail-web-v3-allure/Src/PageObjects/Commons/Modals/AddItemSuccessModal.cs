using FluentAssertions;
using System.Threading;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class AddItemSuccessModal : Modal
    {
        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2[1]")]
        private IWebElement _successHeader;

        protected AddItemSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Finish' button")]
        public AddItemSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeVisible(_finishButton));
            Thread.Sleep(2000); // necessary workaround
            _finishButton.Click();
            return this;
        }

        protected AddItemSuccessModal CheckAddItemSuccessModal(string headerText)
        {
            Wait.Until(ElementToBeVisible(XButton));
            Wait.Until(ElementToBeVisible(_successHeader));
            Wait.Until(ElementToBeVisible(_finishButton));
            _successHeader.Text.Should().Contain(headerText);
            return this;
        }
    }
}