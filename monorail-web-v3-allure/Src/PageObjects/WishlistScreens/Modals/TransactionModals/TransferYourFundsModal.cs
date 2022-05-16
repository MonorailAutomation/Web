using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals.TransactionModals
{
    public class TransferYourFunds : Modal
    {
        private const string TransferYourFundsHeaderText = "Transfers Your Funds";

        private const string TransferYourFundsMessageText =
            "In order to purchase your item, you need to move your funds to a bank account.";

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(), 'External Bank Account')]")]
        private IWebElement _externalBankAccountOption;

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(), 'Monorail Spending Card')]")]
        private IWebElement _monorailSpendingCardOption;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _transferYourFundsMessage;

        public TransferYourFunds(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Transfer Your Funds' modal")]
        public TransferYourFunds CheckTransferYourFundsModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_transferYourFundsMessage));
                Wait.Until(ElementToBeVisible(_monorailSpendingCardOption));
                Wait.Until(ElementToBeVisible(_externalBankAccountOption));

                ModalHeader.Text.Should().Be(TransferYourFundsHeaderText);
                _transferYourFundsMessage.Text.Should().Be(TransferYourFundsMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Click 'Monorail Spending Card' option")]
        public Modal ClickMonorailSpendingCardOption()
        {
            Wait.Until(ElementToBeVisible(_monorailSpendingCardOption));
            _monorailSpendingCardOption.Click();
            return this;
        }

        [AllureStep("Click 'External Bank Account' option")]
        public Modal ClickExternalBankAccountOption()
        {
            Wait.Until(ElementToBeVisible(_externalBankAccountOption));
            _externalBankAccountOption.Click();
            return this;
        }
    }
}