using System;
using System.Linq;
using monorail_web_v3.PageObjects.Commons.Modals.ItemModals;
using monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Enums;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Modals
{
    public class ChooseAPortfolioModal : ChooseATypeModal
    {
        private const string ChooseAPortfolioHeaderText = "Choose a Model";

        public ChooseAPortfolioModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click '{0}' Portfolio Type")]
        public ChooseAPortfolioModal ClickPortfolioType(PortfolioType portfolioType)
        {
            var portfolioTypeSelector = "//p[contains(text(), '" + PortfolioTypeToString(portfolioType) + "')]";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(portfolioTypeSelector))).Click();
            return this;
        }

        [AllureStep("Check 'Choose a Portfolio' modal")]
        public ChooseAPortfolioModal CheckChooseAPortfolioModal()
        {
            try
            {
                CheckChooseATypeModal(ChooseAPortfolioHeaderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        private static string PortfolioTypeToString(PortfolioType portfolioType)
        {
            var portfolioTypeString = Enum.GetName(typeof(PortfolioType), portfolioType);
            return string.Concat(portfolioTypeString.Select(x => char.IsUpper(x) ? " " + x : x.ToString()))
                .TrimStart(' ');
        }
    }
}