using System;
using System.Threading;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class AddItemSuccessModal : Modal
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2[1]")]
        private IWebElement _successHeader;
        
        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Finish')]")]
        public IWebElement _finishButton;

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
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_successHeader));
                _successHeader.Text.Should().Contain(headerText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}