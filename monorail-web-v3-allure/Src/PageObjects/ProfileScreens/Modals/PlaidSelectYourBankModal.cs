using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.ProfileScreens.Modals
{
    public class PlaidSelectYourBankModal
    {
        public PlaidSelectYourBankModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click '{0}' bank")]
        public PlaidSelectYourBankModal ClickBank(string bank)
        {
            var bankSelector = "//p[contains(text(), '" + bank + "')]";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(bankSelector))).Click();
            return this;
        }
    }
}