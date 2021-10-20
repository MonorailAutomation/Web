using NUnit.Allure.Steps;
using OpenQA.Selenium;
using FluentAssertions;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.SuccessModal
{
    public class SuccessModal
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//child::h2[contains(text(),'Success!')]")]
        private IWebElement _successHeaderItem;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//div//p")]
        private IWebElement _successSubheaderItem;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//div//div//p")]
        private IWebElement _moneyAmount;

        public SuccessModal(IWebDriver driver)

        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check if deposit was successful")]
        public SuccessModal CheckForDepositSuccess()
        {
            Wait.Until(ElementToBeVisible(_successHeaderItem));
            Wait.Until(ElementToBeVisible(_successSubheaderItem));
            _successSubheaderItem.Text.Should().Be("Funds are on their way to Monorail");
            return this;
        }

        [AllureStep("Check if withdrawal was successful")]
        public SuccessModal CheckForWithdrawalSuccess()
        {
            Wait.Until(ElementToBeVisible(_successHeaderItem));
            Wait.Until(ElementToBeVisible(_successSubheaderItem));
            _successSubheaderItem.Text.Should().Be("Funds are on their way to your connected account");
            return this;
        }

        [AllureStep("Check if correct amount was deposited")]
        public SuccessModal CheckForDepositAmount(string wishlistAddCashAmount)
        {
            Wait.Until(ElementToBeVisible(_moneyAmount));
            _moneyAmount.Text.Should().Be('$' + wishlistAddCashAmount);
            return this;
        }

        [AllureStep("Check if correct amount was withdrawn")]
        public SuccessModal CheckForWithdrawalAmount(string wishlistCashOutAmount)
        {
            Wait.Until(ElementToBeVisible(_moneyAmount));
            _moneyAmount.Text.Should().Be('$' + wishlistCashOutAmount);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public SuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }

    }
}