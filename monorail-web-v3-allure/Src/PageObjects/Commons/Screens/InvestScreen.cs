using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Screens
{
    public class InvestScreen : MainScreen
    {
        private const string SipcDisclaimerPartOne = "All money for \"Investing\" is protected";
        private const string SipcDisclaimerPartTwo = "and insured up to $250K by SiPC®.";

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Milestones')]")]
        private IWebElement _milestonesNavItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//small[1]")]
        private IWebElement _sipcDisclaimerPartOne;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//small[2]")]
        private IWebElement _sipcDisclaimerPartTwo;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer']//svg-icon[contains(@src, 'sipc-logo')]")]
        private IWebElement _sipcLogo;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Trading')]")]
        private IWebElement _tradingNavItem;

        public InvestScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Trading'")]
        public InvestScreen ClickTrading()
        {
            Wait.Until(ElementToBeClickable(_tradingNavItem));
            _tradingNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Milestones'")]
        public InvestScreen ClickMilestones()
        {
            Wait.Until(ElementToBeClickable(_milestonesNavItem));
            _milestonesNavItem.Click();
            return this;
        }

        [AllureStep("Check 'Invest' Screen")]
        public InvestScreen CheckInvestScreen()
        {
            Wait.Until(ElementToBeClickable(_tradingNavItem));
            Wait.Until(ElementToBeClickable(_milestonesNavItem));
            Wait.Until(ElementToBeClickable(_sipcLogo));
            Wait.Until(ElementToBeClickable(_sipcDisclaimerPartOne));
            Wait.Until(ElementToBeClickable(_sipcDisclaimerPartTwo));

            _sipcDisclaimerPartOne.Text.Should().Be(SipcDisclaimerPartOne);
            _sipcDisclaimerPartTwo.Text.Should().Be(SipcDisclaimerPartTwo);
            return this;
        }
    }
}