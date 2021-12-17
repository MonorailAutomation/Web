using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class RemoveWishlistItemModal : Modal
    {
        private const string RemoveWishlistItemHeaderText = "Remove from Wishlist";
        private const string RemoveWishlistItemMessageText = "Are you sure you want to remove this Wishlist item?";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Cancel')]")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Remove')]")]
        private IWebElement _removeButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _removeWishlistItemMessage;

        public RemoveWishlistItemModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Remove Item' modal")]
        public RemoveWishlistItemModal CheckRemoveItemModal()
        {
            Wait.Until(ElementToBeVisible(ModalHeader));
            Wait.Until(ElementToBeVisible(_removeWishlistItemMessage));
            Wait.Until(ElementToBeVisible(_cancelButton));
            Wait.Until(ElementToBeVisible(_removeButton));

            ModalHeader.Text.Should().Be(RemoveWishlistItemHeaderText);
            _removeWishlistItemMessage.Text.Should().Be(RemoveWishlistItemMessageText);
            return this;
        }

        [AllureStep("Click 'Remove' button")]
        public Modal ClickRemoveButton()
        {
            Wait.Until(ElementToBeVisible(_removeButton));
            _removeButton.Click();
            return this;
        }
    }
}