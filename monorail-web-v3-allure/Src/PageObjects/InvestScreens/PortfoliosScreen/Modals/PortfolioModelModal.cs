using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Modals
{
    public class PortfolioModelModal : Modal
    {
        private const string PortfolioModelHeaderText = "Model";

        [FindsBy(How = How.XPath, Using = "//vim-modal-body//button[contains(text(), 'Change Model')]")]
        private IWebElement _changeModelButton;

        public PortfolioModelModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Model' screen")]
        public PortfolioModelModal CheckPortfolioModelModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_changeModelButton));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Contain(PortfolioModelHeaderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}