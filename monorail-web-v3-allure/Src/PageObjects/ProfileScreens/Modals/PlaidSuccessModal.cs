using System.Threading;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.ProfileScreens.Modals
{
    public class PlaidSuccessModal
    {
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Continue')]")]
        private IWebElement _continueButton;

        public PlaidSuccessModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Continue' button")]
        public PlaidSuccessModal ClickContinueButton()
        {
            Wait.Until(ElementToBeVisible(_continueButton));
            _continueButton.Click();
            Thread.Sleep(15000);
            return this;
        }
    }
}