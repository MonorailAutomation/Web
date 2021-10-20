using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class AddWishlistItemFinishModal
    {
        private const string SuccessHeader = "Good one!";
        private const string SuccessMessage = "You are one step closer from getting your";

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Finish')]")]
        private IWebElement _finishButton;

        [FindsBy(How = How.XPath, Using = "//vim-modal-body//h2[1]")]
        private IWebElement _successHeader;

        [FindsBy(How = How.XPath, Using = "//vim-modal-body//p")]
        private IWebElement _successMessage;

        [FindsBy(How = How.XPath, Using = "//vim-modal-body//h2[2]")]
        private IWebElement _wishlistItemName;

        public AddWishlistItemFinishModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check Finish modal")]
        public AddWishlistItemFinishModal CheckAddWishlistItemFinishModal()
        {
            Wait.Until(ElementToBeVisible(_successHeader));
            Wait.Until(ElementToBeVisible(_successMessage));

            _successHeader.Text.Should().Be(SuccessHeader);
            _successMessage.Text.Should().Be(SuccessMessage);

            return this;
        }

        [AllureStep("Verify if Wishlist item name is: {0}")]
        public AddWishlistItemFinishModal VerifyWishlistItemName(string wishlistItemName)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemName));
            _wishlistItemName.Text.Should().Be(wishlistItemName);
            return this;
        }

        [AllureStep("Click 'Finish' button")]
        public AddWishlistItemFinishModal ClickFinishButton()
        {
            Wait.Until(ElementToBeVisible(_finishButton));
            _finishButton.Click();
            return this;
        }
    }
}