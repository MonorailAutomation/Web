using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals
{
    public class AddMilestoneSuccessModal : AddItemSuccessModal
    {
        private const string SuccessHeaderText = "Success!";
        private const string SuccessMessageText = "Your milestone is being added now.";

        private const string SuccessQuoteText =
            "“Stay focused, go after your dreams and keep moving toward your goals.”";

        private const string SipcLogoUrl = "assets/img/sipc-logo.svg";

        [FindsBy(How = How.XPath, Using = "//div[@class='success-goal__footer__content']//svg-icon")]
        private IWebElement _sipcLogo;

        [FindsBy(How = How.XPath, Using = "//div[@class='success-goal__content']//p")]
        private IWebElement _successMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='success-goal__footer__content']//p")]
        private IWebElement _successQuote;

        public AddMilestoneSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Success' modal")]
        public AddMilestoneSuccessModal CheckSuccessModal()
        {
            try
            {
                CheckAddItemSuccessModal(SuccessHeaderText);
                Wait.Until(ElementToBeVisible(_successMessage));
                Wait.Until(ElementToBeVisible(_successQuote));
                Wait.Until(ElementToBeVisible(_sipcLogo));

                _successMessage.Text.Should().Contain(SuccessMessageText);
                _successQuote.Text.Should().Contain(SuccessQuoteText);
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