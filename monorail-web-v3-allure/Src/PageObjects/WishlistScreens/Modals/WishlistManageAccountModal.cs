using System;
using System.Threading;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistManageAccountModal : Modal
    {
        private const string WishlistManageAccountHeaderText = "Wishlist Account";
        private const string DepositAmountLabelText = "Amount";
        private const string DepositFrequencyLabelText = "Deposit";

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//button[contains(text(),'Add Cash')]")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//button[contains(text(),'Cash Out')]")]
        private IWebElement _cashOutButton;

        [FindsBy(How = How.XPath,
            Using = "//div[contains(@class, 'vim-goal-schedule__info--details')]//div[1]//h2")]
        private IWebElement _depositAmount;

        [FindsBy(How = How.XPath,
            Using = "//div[contains(@class, 'vim-goal-schedule__info--details')]//div[1]//p")]
        private IWebElement _depositAmountLabel;

        [FindsBy(How = How.XPath,
            Using = "//div[contains(@class, 'vim-goal-schedule__info--details')]//div[2]//h2")]
        private IWebElement _depositFrequency;

        [FindsBy(How = How.XPath,
            Using = "//div[contains(@class, 'vim-goal-schedule__info--details')]//div[2]//p")]
        private IWebElement _depositFrequencyLabel;

        [FindsBy(How = How.XPath,
            Using = "//vim-modal-footer//button[contains(text(), 'Dismiss')]")]
        private IWebElement _dismissButton;

        [FindsBy(How = How.XPath,
            Using = "//button[contains(text(), 'Edit Schedule')]")]
        private IWebElement _editScheduleButton;

        [FindsBy(How = How.XPath,
            Using = "//div[contains(@class, 'vim-goal-schedule__header')]//vim-toggle")]
        private IWebElement _scheduledDepositSwitch;

        public WishlistManageAccountModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Wishlist Account' modal")]
        public WishlistManageAccountModal CheckWishlistManageAccountModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_addCashButton));
                Wait.Until(ElementToBeVisible(_cashOutButton));
                Wait.Until(ElementToBeVisible(_scheduledDepositSwitch));
                Wait.Until(ElementToBeVisible(_dismissButton));

                ModalHeader.Text.Should().Contain(WishlistManageAccountHeaderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Verify if Scheduled Deposit section has changed")]
        public WishlistManageAccountModal VerifyIfScheduledDepositSectionHasChanged(string depositAmount,
            string depositFrequency)
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElement(_depositAmount, depositAmount));
            Wait.Until(ExpectedConditions.TextToBePresentInElement(_depositFrequency, depositFrequency));
            return this;
        }

        [AllureStep("Check 'Scheduled Deposits' section")]
        public WishlistManageAccountModal CheckScheduledDepositsSection(string depositAmount, string depositFrequency)
        {
            try
            {
                Wait.Until(ElementToBeVisible(_scheduledDepositSwitch));
                Wait.Until(ElementToBeVisible(_depositAmount));
                Wait.Until(ElementToBeVisible(_depositAmountLabel));
                Wait.Until(ElementToBeVisible(_depositFrequency));
                Wait.Until(ElementToBeVisible(_depositFrequencyLabel));

                _depositAmount.Text.Should().Contain(depositAmount);
                _depositAmountLabel.Text.Should().Contain(DepositAmountLabelText);

                _depositFrequency.Text.Should().Contain(depositFrequency);
                _depositFrequencyLabel.Text.Should().Contain(DepositFrequencyLabelText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Click 'Scheduled Deposit' switch")]
        public WishlistManageAccountModal ClickScheduledDepositSwitch()
        {
            Wait.Until(ElementToBeClickable(_scheduledDepositSwitch));
            _scheduledDepositSwitch.Click();
            return this;
        }

        [AllureStep("Click 'Target & Schedule' button")]
        public WishlistManageAccountModal ClickEditScheduleButton()
        {
            Wait.Until(ElementToBeClickable(_editScheduleButton));
            _editScheduleButton.Click();
            return this;
        }

        [AllureStep("Click 'Add Cash' button")]
        public WishlistManageAccountModal ClickAddCashButton()
        {
            Wait.Until(ElementToBeClickable(_addCashButton));
            Thread.Sleep(2000); // necessary workaround
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Cash Out' button")]
        public WishlistManageAccountModal ClickCashOutButton()
        {
            Wait.Until(ElementToBeClickable(_cashOutButton));
            Thread.Sleep(2000); // necessary workaround
            _cashOutButton.Click();
            return this;
        }
    }
}