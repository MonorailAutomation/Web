using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Screens
{
    public class TradingMainScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Add Cash')]")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Cash Out')]")]
        private IWebElement _cashOutButton;

        public TradingMainScreen(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add Cash' button")]
        public TradingMainScreen ClickAddCashButton()
        {
            Wait.Until(ElementToBeClickable(_addCashButton));
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Cash Out' button")]
        public TradingMainScreen ClickCashOutButton()
        {
            Wait.Until(ElementToBeClickable(_cashOutButton));
            _cashOutButton.Click();
            return this;
        }
    }
}