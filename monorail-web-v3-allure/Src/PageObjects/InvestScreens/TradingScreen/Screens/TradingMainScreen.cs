using System;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Screens
{
    public class TradingMainScreen : InvestScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Add Cash')]")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Cash Out')]")]
        private IWebElement _cashOutButton;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'Find New Stocks')]")]
        private IWebElement _findNewStocksButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'How it Works')]")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Start Trading Stocks')]")]
        private IWebElement _startTradingStocksButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-page-header__title']//h1[contains(text(),'Trading')]")]
        private IWebElement _tradingHeader;

        public TradingMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Start Trading Stocks' button")]
        public TradingMainScreen ClickStartTradingStocksButton()
        {
            Wait.Until(ElementToBeClickable(_startTradingStocksButton));
            _startTradingStocksButton.Click();
            return this;
        }

        [AllureStep("Click 'Add Cash' button")]
        public TradingMainScreen ClickAddCashButton()
        {
            Wait.Until(ElementToBeClickable(_addCashButton));
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Cash Out' button")]
        public TradingMainScreen ClickCashOutButton()
        {
            Wait.Until(ElementToBeClickable(_cashOutButton));
            _cashOutButton.Click();
            return this;
        }

        [AllureStep("Check Trading Main screen just after onboarding")]
        public TradingMainScreen CheckTradingMainScreenAfterOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_tradingHeader));
                Wait.Until(ElementToBeVisible(_howItWorksButton));

                Wait.Until(ElementToBeNotVisible(_startTradingStocksButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check Trading Main screen before onboarding")]
        public TradingMainScreen CheckTradingMainScreenBeforeOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_tradingHeader));
                Wait.Until(ElementToBeVisible(_howItWorksButton));
                Wait.Until(ElementToBeVisible(_startTradingStocksButton));
                //TODO: Find a way to handle these checks in a short period of time
                //Wait.Until(ElementToBeNotVisible(_addCashButton));
                //Wait.Until(ElementToBeNotVisible(_cashOutButton));
                //Wait.Until(ElementToBeNotVisible(_findNewStocksButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check Trading Main screen after activation")]
        public TradingMainScreen CheckTradingMainScreenAfterActivation()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_tradingHeader));
                Wait.Until(ElementToBeVisible(_howItWorksButton));
                Wait.Until(ElementToBeVisible(_addCashButton));
                Wait.Until(ElementToBeVisible(_cashOutButton));
                Wait.Until(ElementToBeVisible(_findNewStocksButton));

                Wait.Until(ElementToBeNotVisible(_startTradingStocksButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}