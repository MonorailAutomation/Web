using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistCashOutSuccessModal
    {
        private const string WishlistCashOutSuccessHeader = "Success!";
        private const string WishlistCashOutSuccessMessage = "Funds are on their way to your connected account";

        private const string WishlistCashOutSuccessAdvicePartOne =
            "Transfers can take between 3-7 business days to transfer.";

        private const string WishlistCashOutSuccessAdvicePartTwo =
            "Deposited funds will be available to withdraw 5 business days after they finish depositing.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']//div//div//p")]
        private IWebElement _moneyAmount;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__body__content']/div/p[2]")]
        private IWebElement _wishlistCashOutSuccessAdvice;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _wishlistCashOutSuccessHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/div/p[1]")]
        private IWebElement _wishlistCashOutSuccessMessage;

        public WishlistCashOutSuccessModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Cash Out' success modal")]
        public WishlistCashOutSuccessModal CheckWishlistCashOutSuccessModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistCashOutSuccessHeader));
            Wait.Until(ElementToBeVisible(_wishlistCashOutSuccessMessage));
            Wait.Until(ElementToBeVisible(_moneyAmount));
            Wait.Until(ElementToBeVisible(_wishlistCashOutSuccessAdvice));
            Wait.Until(ElementToBeClickable(_finishButton));

            _wishlistCashOutSuccessHeader.Text.Should().Be(WishlistCashOutSuccessHeader);
            _wishlistCashOutSuccessMessage.Text.Should().Be(WishlistCashOutSuccessMessage);
            _moneyAmount.Text.Should().NotBeNullOrEmpty();
            _wishlistCashOutSuccessAdvice.Text.Should().Contain(WishlistCashOutSuccessAdvicePartOne);
            _wishlistCashOutSuccessAdvice.Text.Should().Contain(WishlistCashOutSuccessAdvicePartTwo);

            return this;
        }

        [AllureStep("Check if ${0} amount was withdrawn")]
        public WishlistCashOutSuccessModal CheckForWithdrawnAmount(string wishlistCashOutAmount)
        {
            Wait.Until(ElementToBeVisible(_moneyAmount));
            _moneyAmount.Text.Should().Be('$' + wishlistCashOutAmount);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public WishlistCashOutSuccessModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}