using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.TransactionModals
{
    public class AddCashModal : Modal
    {
        private const string AddCashModalHeaderText = "Add Cash";
        private const string AddCashMessageText = "Choose an amount to add";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _addCashInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/p")]
        private IWebElement _addCashMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']/div/div[1]/p[2]")]
        private IWebElement _transferCompleteDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='cash-transfer-modal__footer']/div/div[1]/p[1]")]
        private IWebElement _transferCompleteLabel;

        protected AddCashModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set Add Cash amount to '${0}'")]
        public AddCashModal SetAddCashAmount(string addCashAmount)
        {
            Wait.Until(ElementToBeVisible(_addCashInput));
            _addCashInput.Clear();
            _addCashInput.SendKeys(addCashAmount);
            return this;
        }

        protected AddCashModal CheckAddCashModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_addCashMessage));
                Wait.Until(ElementToBeVisible(_addCashInput));


                ModalHeader.Text.Should().Be(AddCashModalHeaderText);
                _addCashMessage.Text.Should().Be(AddCashMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}