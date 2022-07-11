using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Screens
{
    public class InvestScreen : MainScreen
    {
        private const string SipcDisclaimerPartOne = "All money for \"Investing\" is protected";
        private const string SipcDisclaimerPartTwo = "and insured up to $250K by SiPC®.";

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Portfolios')]")]
        private IWebElement _portfoliosNavItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//small[1]")]
        private IWebElement _sipcDisclaimerPartOne;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//small[2]")]
        private IWebElement _sipcDisclaimerPartTwo;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//svg-icon[contains(@src, 'sipc-logo')]")]
        private IWebElement _sipcLogo;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Stocks')]")]
        private IWebElement _stocksNavItem;

        public InvestScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Stocks'")]
        public InvestScreen ClickStocks()
        {
            Wait.Until(ElementToBeClickable(_stocksNavItem));
            _stocksNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Portfolios'")]
        public InvestScreen ClickPortfolios()
        {
            Wait.Until(ElementToBeClickable(_portfoliosNavItem));
            _portfoliosNavItem.Click();
            return this;
        }

        [AllureStep("Check 'Invest' Screen")]
        public InvestScreen CheckInvestScreen()
        {
            try
            {
                Wait.Until(ElementToBeClickable(_stocksNavItem));
                Wait.Until(ElementToBeClickable(_portfoliosNavItem));
                Wait.Until(ElementToBeClickable(_sipcLogo));
                Wait.Until(ElementToBeClickable(_sipcDisclaimerPartOne));
                Wait.Until(ElementToBeClickable(_sipcDisclaimerPartTwo));

                _sipcDisclaimerPartOne.Text.Should().Be(SipcDisclaimerPartOne);
                _sipcDisclaimerPartTwo.Text.Should().Be(SipcDisclaimerPartTwo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}