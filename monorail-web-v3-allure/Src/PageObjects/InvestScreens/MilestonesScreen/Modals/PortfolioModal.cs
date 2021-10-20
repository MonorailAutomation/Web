using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals
{
    public class PortfolioModal
    {
        private const string PortfolioHeader = "Portfolio";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Back')]")]
        private IWebElement _backButton;

        [FindsBy(How = How.XPath, Using = "//vim-modal-body//button[contains(text(), 'Change Portfolio')]")]
        private IWebElement _changePortfolioButton;

        [FindsBy(How = How.XPath, Using = "//vim-recommended-portfolio-modal//button[contains(text(),'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _portfolioHeader;

        public PortfolioModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Portfolio' modal")]
        public PortfolioModal CheckPortfolioModal()
        {
            Wait.Until(ElementToBeVisible(_portfolioHeader));
            Wait.Until(ElementToBeVisible(_changePortfolioButton));
            Wait.Until(ElementToBeVisible(_backButton));
            Wait.Until(ElementToBeVisible(_continueButton));

            _portfolioHeader.Text.Should().Contain(PortfolioHeader);

            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public PortfolioModal ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }
    }
}