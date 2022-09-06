using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Screens
{
    public class PortfoliosMainScreen : InvestScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Add an Account')]")]
        private IWebElement _addAPortfolioButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='empty-card__container'][1]")]
        private IWebElement _firstPlaceholderCard;

        [FindsBy(How = How.XPath, Using = "//div[@class='empty-card__container'][2]")]
        private IWebElement _secondPlaceholderCard;

        public PortfoliosMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add a Portfolio' button")]
        public PortfoliosMainScreen ClickAddAPortfolioButton()
        {
            Wait.Until(ElementToBeClickable(_addAPortfolioButton));
            _addAPortfolioButton.Click();
            return this;
        }

        [AllureStep("Click '+' placeholder card")]
        public PortfoliosMainScreen ClickPlaceholderCard()
        {
            Wait.Until(ElementToBeClickable(_firstPlaceholderCard));
            _firstPlaceholderCard.Click();
            return this;
        }

        [AllureStep("Verify if '{0}' portfolios exists")]
        public PortfoliosMainScreen VerifyIfPortfolioExists(string portfolioName)
        {
            VerifyIfPortfolioIsVisible(portfolioName);
            return this;
        }

        [AllureStep("Verify if '{0}' portfolio exists with ${1} target amount")]
        public PortfoliosMainScreen VerifyIfPortfolioExists(string portfolioName, string portfolioTargetAmount)
        {
            VerifyIfPortfolioIsVisible(portfolioName);
            VerifyIfTargetAmountIsVisible(portfolioName, portfolioTargetAmount);
            VerifyIfProgressBarIsVisible(portfolioName);
            return this;
        }

        [AllureStep("Click '{0}' Portfolio")]
        public PortfoliosMainScreen ClickPortfolio(string portfolioName)
        {
            var portfolioItemSelector = By.XPath("//h3[contains(text(),'" + portfolioName + "')]");
            VerifyIfPortfolioIsVisible(portfolioName);
            Driver.FindElement(portfolioItemSelector).Click();
            return this;
        }

        private static void VerifyIfProgressBarIsVisible(string portfolioName)
        {
            var progressBarSelector =
                By.XPath("//h3[contains(text(),'" + portfolioName + "')]//following-sibling::div");

            Wait.Until(ExpectedConditions.ElementIsVisible(progressBarSelector));
        }

        private static void VerifyIfTargetAmountIsVisible(string portfolioName, string portfolioTargetAmount)
        {
            var expectedPortfolioAmount = "$0 of $" + portfolioTargetAmount;
            var portfolioTargetAmountSelector =
                By.XPath("//h3[contains(text(),'" + portfolioName + "')]//following-sibling::p");

            Wait.Until(ExpectedConditions.ElementIsVisible(portfolioTargetAmountSelector));
            var actualPortfolioAmount = Driver.FindElement(portfolioTargetAmountSelector).Text;
            actualPortfolioAmount.Should().Be(expectedPortfolioAmount);
        }

        private static void VerifyIfPortfolioIsVisible(string portfolioName)
        {
            var portfolioItemSelector = By.XPath("//h3[contains(text(),'" + portfolioName + "')]");
            Wait.Until(ExpectedConditions.ElementIsVisible(portfolioItemSelector));
        }
    }
}