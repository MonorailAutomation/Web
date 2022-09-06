using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals.ItemModals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Modals
{
    public class AddPortfolioSuccessModal : AddItemSuccessModal
    {
        private const string SuccessHeaderText = "You are all set!";
        private const string SuccessMessageText = "Your account is being created now.";


        private const string SipcLogoUrl = "assets/img/sipc-logo.svg";

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'success-modal__footer')]//svg-icon")]
        private IWebElement _sipcLogo;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _successMessage;


        public AddPortfolioSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Success' modal")]
        public AddPortfolioSuccessModal CheckSuccessModal()
        {
            try
            {
                CheckAddItemSuccessModal(SuccessHeaderText);
                Wait.Until(ElementToBeVisible(_successMessage));
                Wait.Until(ElementToBeVisible(_sipcLogo));
                Wait.Until(ElementToBeVisible(_finishButton));

                _successMessage.Text.Should().Contain(SuccessMessageText);
                _sipcLogo.GetAttribute("src").Should().Be(SipcLogoUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}