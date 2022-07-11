using System;
using System.Globalization;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.ItemModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Modals
{
    public class PortfolioItemDetailsModal : ItemDetailsModal
    {
        private const string PortfolioDetailsHeaderText = "Portfolio Details";

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='targetBalance']")]
        private IWebElement _portfolioTargetAmountInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='text']")]
        private IWebElement _portfolioTargetDateInput;

        public PortfolioItemDetailsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set Portfolio Target Amount to '${0}'")]
        public PortfolioItemDetailsModal SetPortfolioTargetAmount(string portfolioTargetAmount)
        {
            Wait.Until(ElementToBeVisible(_portfolioTargetAmountInput));
            _portfolioTargetAmountInput.Clear();
            _portfolioTargetAmountInput.SendKeys(portfolioTargetAmount);
            return this;
        }

        [AllureStep("Set Portfolio Target Date to '{0}'")]
        public PortfolioItemDetailsModal SetPortfolioTargetDate(string portfolioTargetDate)
        {
            Wait.Until(ElementToBeVisible(_portfolioTargetDateInput));
            _portfolioTargetDateInput.Clear();
            _portfolioTargetDateInput.SendKeys(portfolioTargetDate);
            return this;
        }

        [AllureStep("Verify if 'Target Date' is '{0}'")]
        public PortfolioItemDetailsModal VerifyTargetDate(string expectedTargetDate)
        {
            Wait.Until(ElementToBeVisible(_portfolioTargetDateInput));
            var actualPortfolioTargetDate = _portfolioTargetDateInput.GetAttribute("value");
            var parsedDate = DateTime.ParseExact(actualPortfolioTargetDate, "yyyy-MM-dd",
                CultureInfo.InvariantCulture).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            parsedDate.Should().Be(expectedTargetDate);
            return this;
        }

        [AllureStep("Check 'Portfolio Details' modal")]
        public PortfolioItemDetailsModal CheckPortfolioDetailsModal()
        {
            try
            {
                CheckItemDetailsModal(PortfolioDetailsHeaderText);
                Wait.Until(ElementToBeVisible(ItemDescriptionInput));
                Wait.Until(ElementToBeVisible(ContinueButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}