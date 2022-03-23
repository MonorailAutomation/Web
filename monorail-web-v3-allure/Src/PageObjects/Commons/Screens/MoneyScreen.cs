using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Screens
{
    public class MoneyScreen : MainScreen
    {
        private const string FdicDisclaimerText =
            "Wishlist, Tracks, and Checking Accounts are made available through Vimvest LLC DBA Monorail. Wishlist, Tracks, Checking Accounts, and the Monorail Visa Debit Card are provided by and issued by Hills Bank and Trust Company, Member FDIC.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//small")]
        private IWebElement _fdicDisclaimer;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//svg-icon[contains(@src, 'fdic-logo')]")]
        private IWebElement _fdicLogo;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Save')]")]
        private IWebElement _saveNavMenu;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Spend')]")]
        private IWebElement _spendNavMenu;

        public MoneyScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Spend'")]
        public MoneyScreen ClickSpend()
        {
            Wait.Until(ElementToBeClickable(_spendNavMenu));
            _spendNavMenu.Click();
            return this;
        }

        [AllureStep("Click 'Save'")]
        public MoneyScreen ClickSave()
        {
            Wait.Until(ElementToBeClickable(_saveNavMenu));
            _saveNavMenu.Click();
            return this;
        }

        [AllureStep("Check 'Money' Screen")]
        public MoneyScreen CheckMoneyScreen()
        {
            try
            {
                Wait.Until(ElementToBeClickable(_spendNavMenu));
                Wait.Until(ElementToBeClickable(_saveNavMenu));
                Wait.Until(ElementToBeClickable(_fdicLogo));
                Wait.Until(ElementToBeClickable(_fdicDisclaimer));

                _fdicDisclaimer.Text.Should().Be(FdicDisclaimerText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}