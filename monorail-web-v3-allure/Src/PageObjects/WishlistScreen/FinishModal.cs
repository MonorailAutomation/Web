using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreen
{
    public class FinishModal
    {
        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath, Using = "//vim-modal-body//h2[2]")]
        private IWebElement _wishlistItemName;

        public FinishModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Verify if Wishlist item name is: {0}")]
        public FinishModal VerifyWishlistItemName(string wishlistItemName)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemName));
            _wishlistItemName.Text.Should().Be(wishlistItemName);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public FinishModal ClickFinishButton()
        {
            Wait.Until(ElementToBeClickable(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}