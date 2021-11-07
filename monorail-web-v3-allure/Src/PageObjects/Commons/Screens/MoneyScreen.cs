using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Screens
{
    public class MoneyScreen : MainScreen
    {
        private const string FdicDisclaimerPartOne = "Saving and Checking accounts are provided by";
        private const string FdicDisclaimerPartTwo = "Hills Bank. They are FDIC insured up to $500K.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//small[1]")]
        private IWebElement _fdicDisclaimerPartOne;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//small[2]")]
        private IWebElement _fdicDisclaimerPartTwo;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//svg-icon[contains(@src, 'fdic-logo')]")]
        private IWebElement _fdicLogo;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Save')]")]
        private IWebElement _saveNavMenu;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Spend')]")]
        private IWebElement _spendNavMenu;

        public MoneyScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Spend'")]
        public MoneyScreen ClickSpend()
        {
            Wait.Until(ElementToBeClickable(_spendNavMenu));
            _spendNavMenu.Click();
            return this;
        }

        [AllureStep("Click 'Save'")]
        public MoneyScreen ClickSave()
        {
            Wait.Until(ElementToBeClickable(_saveNavMenu));
            _saveNavMenu.Click();
            return this;
        }

        [AllureStep("Check 'Money' Screen")]
        public MoneyScreen CheckMoneyScreen()
        {
            Wait.Until(ElementToBeClickable(_spendNavMenu));
            Wait.Until(ElementToBeClickable(_saveNavMenu));
            Wait.Until(ElementToBeClickable(_fdicLogo));
            Wait.Until(ElementToBeClickable(_fdicDisclaimerPartOne));
            Wait.Until(ElementToBeClickable(_fdicDisclaimerPartTwo));

            _fdicDisclaimerPartOne.Text.Should().Be(FdicDisclaimerPartOne);
            _fdicDisclaimerPartTwo.Text.Should().Be(FdicDisclaimerPartTwo);
            return this;
        }
    }
}