using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;


namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistAddCashSuccessModal
    {
        private const string WishlistAddCashSuccessHeader = "Success!";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath,
            Using = "//div[contains(@class, 'vim-add-funds__split-amount')]//p")]
        private IWebElement _moneyAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _wishlistAddCashSuccessHeader;

        public WishlistAddCashSuccessModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add Cash' success modal")]
        public WishlistAddCashSuccessModal CheckWishlistAddCashSuccessModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistAddCashSuccessHeader));
            Wait.Until(ElementToBeVisible(_moneyAmount));
            Wait.Until(ElementToBeClickable(_finishButton));

            _wishlistAddCashSuccessHeader.Text.Should().Be(WishlistAddCashSuccessHeader);
            return this;
        }

        [AllureStep("Check if ${0} amount was deposited")]
        public WishlistAddCashSuccessModal CheckForDepositAmount(string wishlistAddCashAmount)
        {
            Wait.Until(ElementToBeVisible(_moneyAmount));
            _moneyAmount.Text.Should().Be('$' + wishlistAddCashAmount);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public WishlistAddCashSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}