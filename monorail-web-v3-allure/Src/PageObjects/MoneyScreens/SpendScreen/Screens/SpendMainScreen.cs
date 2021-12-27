using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using static monorail_web_v3.Commons.Waits;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Screens
{
    public class SpendMainScreen : MoneyScreen
    {
        private const string SpendHeaderText = "Spend";
        private const string SetGoalsMessageText = "Set Goals.";
        private const string ReachGoalsMessageText = "Reach Goals.";
        private const string PurchaseMessageText = "Purchase.";
        private const string InfoMessageText = "Spend directly from Vimvest by using our new debit card.";

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Cash')]")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cash Out')]")]
        private IWebElement _cashOutButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-open-checking-account__cta']//p")]
        private IWebElement _infoMessage;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Open your Checking Account')]")]
        private IWebElement _openYourCheckingAccountButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-open-checking-account__cta']//h2[3]")]
        private IWebElement _purchaseMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-open-checking-account__cta']//h2[2]")]
        private IWebElement _reachGoalsMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-open-checking-account__cta']//h2[1]")]
        private IWebElement _setGoalsMessage;

        /*    */
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-page-header__title']//h1[1]")]
        private IWebElement _spendHeader;

        public SpendMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add Cash' button")]
        public SpendMainScreen ClickAddCashButton()
        {
            Wait.Until(ElementToBeClickable(_addCashButton));
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Cash Out' button")]
        public SpendMainScreen ClickCashOutButton()
        {
            Wait.Until(ElementToBeClickable(_cashOutButton));
            _cashOutButton.Click();
            return this;
        }

        [AllureStep("Click 'Open your Checking Account' button")]
        public SpendMainScreen ClickOpenYourCheckingAccountButton()
        {
            Wait.Until(ElementToBeClickable(_openYourCheckingAccountButton));
            _openYourCheckingAccountButton.Click();
            return this;
        }

        [AllureStep("Check 'Spend' screen before onboarding")]
        public SpendMainScreen CheckSpendScreenBeforeOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_spendHeader));
                Wait.Until(ElementToBeVisible(_setGoalsMessage));
                Wait.Until(ElementToBeVisible(_reachGoalsMessage));
                Wait.Until(ElementToBeVisible(_purchaseMessage));
                Wait.Until(ElementToBeVisible(_infoMessage));
                Wait.Until(ElementToBeVisible(_openYourCheckingAccountButton));

                _spendHeader.Text.Should().Contain(SpendHeaderText);
                _setGoalsMessage.Text.Should().Be(SetGoalsMessageText);
                _reachGoalsMessage.Text.Should().Be(ReachGoalsMessageText);
                _purchaseMessage.Text.Should().Be(PurchaseMessageText);
                _infoMessage.Text.Should().Be(InfoMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}