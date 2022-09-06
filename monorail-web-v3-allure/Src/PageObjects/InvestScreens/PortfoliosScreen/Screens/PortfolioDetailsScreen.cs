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
    public class PortfolioDetailsScreen : InvestScreen
    {
        [FindsBy(How = How.XPath, Using = "//p[contains(text(), 'Rename Account')]")]
        private IWebElement _editDetailsOption;

        [FindsBy(How = How.XPath, Using = "//vim-goal-description//p[@class='text-gray-400']")]
        private IWebElement _portfolioDescription;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-goal-sidebar']//h2[@class='m-0']")]
        private IWebElement _portfolioName;

        [FindsBy(How = How.XPath, Using = "//span[@class='vim-goal-sidebar__amount__target']")]
        private IWebElement _portfolioTargetAmount;

        public PortfolioDetailsScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Rename Account' button")]
        public PortfolioDetailsScreen ClickRenameAccountButton()
        {
            Wait.Until(ElementToBeClickable(_editDetailsOption));
            _editDetailsOption.Click();
            return this;
        }

        [AllureStep("Verify if Portfolio Name is '{0}', Description is '{1}'")]
        public PortfolioDetailsScreen VerifyPortfolioDetails(string portfolioName)
        {
            VerifyIfPortfolioNameHasChanged(portfolioName);
            _portfolioName.Text.Should().Be(portfolioName);
            return this;
        }

        private void VerifyIfPortfolioNameHasChanged(string portfolioName)
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElement(_portfolioName, portfolioName));
        }
    }
}