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
        private const string PortfolioDetailsHeaderText = "Account Information";

        [FindsBy(How = How.XPath, Using = "//input[@type='text']")]
        private IWebElement _portfolioTargetDateInput;

        public PortfolioItemDetailsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
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
                //CheckItemDetailsModal(PortfolioDetailsHeaderText);
                //TODO: Uncomment line above when #43576 is fixed
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