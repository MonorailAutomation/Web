using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.ProfileScreens.Screens
{
    public class MyConnectedAccountScreen : MainScreen
    {
        private const string ConnectedAccountPageHeaderText = "Connected Account";
        private const string NoAccountHeaderText = "Funding goals is secure and simple";

        private const string NoAccountMessageText =
            "Your goals grow by connecting your current spending account. It's easy, speedy and bank level secure.";

        [FindsBy(How = How.XPath, Using = "//div[@class='my-connected-accounts__bank']//h2")]
        private IWebElement _connectedAccountAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='my-connected-accounts__bank']//p")]
        private IWebElement _connectedAccountBank;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-page-header__title']//div[1]//h1")]
        private IWebElement _connectedAccountPageHeader;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Link Your Bank Account')]")]
        private IWebElement _linkYourBankAccountButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='my-connected-accounts__empty__text']//h5")]
        private IWebElement _noAccountHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='my-connected-accounts__empty__text']//p")]
        private IWebElement _noAccountMessage;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Unlink Bank Account')]")]
        private IWebElement _unlinkBankAccountButton;

        public MyConnectedAccountScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check empty 'My Connected Account' screen")]
        public MyConnectedAccountScreen CheckMyConnectedAccountScreenWithoutPlaidAccount()
        {
            Wait.Until(ElementToBeVisible(_connectedAccountPageHeader));
            Wait.Until(ElementToBeVisible(_noAccountHeader));
            Wait.Until(ElementToBeVisible(_noAccountMessage));
            Wait.Until(ElementToBeClickable(_linkYourBankAccountButton));

            _connectedAccountPageHeader.Text.Should().Be(ConnectedAccountPageHeaderText);
            _noAccountHeader.Text.Should().Be(NoAccountHeaderText);
            _noAccountMessage.Text.Should().Be(NoAccountMessageText);
            return this;
        }

        [AllureStep("Check 'My Connected Account' screen with connected Plaid account")]
        public MyConnectedAccountScreen CheckMyConnectedAccountScreenWithConnectedPlaidAccount()
        {
            Wait.Until(ElementToBeVisible(_connectedAccountPageHeader));
            Wait.Until(ElementToBeVisible(_connectedAccountAmount));
            Wait.Until(ElementToBeVisible(_connectedAccountBank));
            Wait.Until(ElementToBeClickable(_unlinkBankAccountButton));

            _connectedAccountPageHeader.Text.Should().Be(ConnectedAccountPageHeaderText);
            _connectedAccountAmount.Text.Should().NotBeNullOrEmpty();
            _connectedAccountBank.Text.Should().NotBeNullOrEmpty();
            return this;
        }

        [AllureStep("Click 'Link Your Bank Account' button")]
        public MyConnectedAccountScreen ClickLinkYourBankAccount()
        {
            Wait.Until(ElementToBeVisible(_linkYourBankAccountButton));
            _linkYourBankAccountButton.Click();
            return this;
        }
    }
}