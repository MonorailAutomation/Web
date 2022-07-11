using System;
using System.Collections;
using System.Collections.Generic;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using static monorail_web_v3.Commons.Functions;

namespace monorail_web_v3.PageObjects.InvestScreens.StocksScreen.Screens
{
    public class StocksMainScreen : InvestScreen
    {
        private const string StartTradingStocksButtonXPath = "//button[contains(text(), 'Start Trading Stocks')]";
        private const string AddCashButtonXPath = "//button[contains(text(), 'Add Cash')]";
        private const string CashOutButtonXPath = "//button[contains(text(), 'Cash Out')]";
        private const string FindNewStocksButtonXPath = "//p[contains(text(), 'Find New Stocks')]";

        [FindsBy(How = How.XPath, Using = AddCashButtonXPath)]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath, Using = CashOutButtonXPath)]
        private IWebElement _cashOutButton;

        [FindsBy(How = How.XPath, Using = FindNewStocksButtonXPath)]
        private IWebElement _findNewStocksButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'How it Works')]")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.XPath, Using = StartTradingStocksButtonXPath)]
        private IWebElement _startTradingStocksButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-page-header__title']//h1[contains(text(),'Stocks')]")]
        private IWebElement _stocksHeader;



        public StocksMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Start Trading Stocks' button")]
        public StocksMainScreen ClickStartTradingStocksButton()
        {
            Wait.Until(ElementToBeClickable(_startTradingStocksButton));
            _startTradingStocksButton.Click();
            return this;
        }

        [AllureStep("Click 'Add Cash' button")]
        public StocksMainScreen ClickAddCashButton()
        {
            Wait.Until(ElementToBeClickable(_addCashButton));
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Cash Out' button")]
        public StocksMainScreen ClickCashOutButton()
        {
            Wait.Until(ElementToBeClickable(_cashOutButton));
            _cashOutButton.Click();
            return this;
        }

        [AllureStep("Check Stocks Main screen just after onboarding")]
        public StocksMainScreen CheckStocksMainScreenAfterOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_stocksHeader));
                Wait.Until(ElementToBeVisible(_howItWorksButton));

                IsElementNotVisibleByXpath(StartTradingStocksButtonXPath, Driver).Should().BeTrue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check Stocks Main screen before onboarding")]
        public StocksMainScreen CheckStocksMainScreenBeforeOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_stocksHeader));
                Wait.Until(ElementToBeVisible(_howItWorksButton));
                Wait.Until(ElementToBeVisible(_startTradingStocksButton));

                IsElementNotVisibleByXpath(AddCashButtonXPath, Driver).Should().BeTrue();

                IsElementNotVisibleByXpath(CashOutButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(FindNewStocksButtonXPath, Driver).Should().BeTrue();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check Stocks Main screen after activation")]
        public StocksMainScreen CheckStocksMainScreenAfterActivation()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_stocksHeader));
                Wait.Until(ElementToBeVisible(_howItWorksButton));
                Wait.Until(ElementToBeVisible(_addCashButton));
                Wait.Until(ElementToBeVisible(_cashOutButton));
                Wait.Until(ElementToBeVisible(_findNewStocksButton));

                IsElementNotVisibleByXpath(StartTradingStocksButtonXPath, Driver).Should().BeTrue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}