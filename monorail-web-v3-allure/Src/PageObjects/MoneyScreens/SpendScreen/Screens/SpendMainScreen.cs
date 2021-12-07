using monorail_web_v3.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.Test.Scripts;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Screens
{
    public class SpendMainScreen : MoneyScreen
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Cash')]")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cash Out')]")]
        private IWebElement _cashOutButton;

        public SpendMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add Cash' button")]
        public SpendMainScreen ClickAddCashButton()
        {
            FunctionalTesting.Wait.Until(Waits.ElementToBeClickable(_addCashButton));
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Cash Out' button")]
        public SpendMainScreen ClickCashOutButton()
        {
            FunctionalTesting.Wait.Until(Waits.ElementToBeClickable(_cashOutButton));
            _cashOutButton.Click();
            return this;
        }
    }
}