using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals
{
    public class TermsAndConditionsModal : Modal
    {
        private const string TermsAndConditionsModalHeaderText = "Terms And Conditions";

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Agree')]")]
        private IWebElement _agreeButton;

        [FindsBy(How = How.XPath, Using = "//div[@data-page-number='22']")]
        private IWebElement _lastPage;

        public TermsAndConditionsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Agree' button")]
        public TermsAndConditionsModal ClickAgreeButton()
        {
            Wait.Until(ElementToBeVisible(_agreeButton));
            _agreeButton.Click();
            return this;
        }

        [AllureStep("Scroll to the bottom of the document")]
        public TermsAndConditionsModal ScrollToTheBottomOfTheDocument()
        {
            var actions = new Actions(Driver);
            actions.MoveToElement(_lastPage);
            actions.Perform();
            return this;
        }
    }
}