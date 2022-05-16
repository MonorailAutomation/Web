using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens
{
    public class TrackDetailsScreen : MoneyScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Funds')]")]
        private IWebElement _addFundsButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Withdraw')]")]
        private IWebElement _withdrawButton;

        public TrackDetailsScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add Funds' button")]
        public TrackDetailsScreen ClickAddFundsButton()
        {
            Wait.Until(ElementToBeClickable(_addFundsButton));
            _addFundsButton.Click();
            return this;
        }

        [AllureStep("Click 'Withdraw' button")]
        public TrackDetailsScreen ClickWithdrawButton()
        {
            Wait.Until(ElementToBeClickable(_withdrawButton));
            _withdrawButton.Click();
            return this;
        }
    }
}