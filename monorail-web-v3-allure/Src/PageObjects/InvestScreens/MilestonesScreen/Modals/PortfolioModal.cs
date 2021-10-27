using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals
{
    public class PortfolioModal : Modal
    {
        private const string PortfolioHeaderText = "Portfolio";

        [FindsBy(How = How.XPath, Using = "//vim-modal-body//button[contains(text(), 'Change Portfolio')]")]
        private IWebElement _changePortfolioButton;

        public PortfolioModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Portfolio' modal")]
        public PortfolioModal CheckPortfolioModal()
        {
            Wait.Until(ElementToBeVisible(ModalHeader));
            Wait.Until(ElementToBeVisible(XButton));
            Wait.Until(ElementToBeVisible(_changePortfolioButton));
            Wait.Until(ElementToBeVisible(BackButton));
            Wait.Until(ElementToBeVisible(ContinueButton));

            ModalHeader.Text.Should().Contain(PortfolioHeaderText);

            return this;
        }
    }
}