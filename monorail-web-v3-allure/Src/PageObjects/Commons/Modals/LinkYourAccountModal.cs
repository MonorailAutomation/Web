using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class LinkYourAccountModal : Modal
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Link Your Account')]")]
        private IWebElement _linkYourAccountButton;

        public LinkYourAccountModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Link Your Account' button")]
        public LinkYourAccountModal ClickLinkYourAccountButton()
        {
            Wait.Until(ElementToBeClickable(_linkYourAccountButton));
            _linkYourAccountButton.Click();
            return this;
        }

        //TO DO: Check Link Your Account modal
    }
}