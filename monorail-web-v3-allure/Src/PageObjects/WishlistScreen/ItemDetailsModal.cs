using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreen
{
    public class ItemDetailsModal
    {
        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Confirm')]")]
        private IWebElement _confirmButton;

        [FindsBy(How = How.Id, Using = "description_wishlist_details")]
        private IWebElement _wishlistItemDescriptionInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//img")]
        private IWebElement _wishlistItemImage;

        [FindsBy(How = How.Id, Using = "name_wishlist_details")]
        private IWebElement _wishlistItemNameInput;

        [FindsBy(How = How.Id, Using = "amount_wishlist_details")]
        private IWebElement _wishlistItemPriceInput;

        [FindsBy(How = How.Id, Using = "itemURL_wishlist")]
        private IWebElement _wishlistItemUrlInput;

        public ItemDetailsModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Verify data on 'Item Details' screen")]
        public ItemDetailsModal VerifyDataOnItemDetailsModal(string wishlistItemName, string wishlistItemDescription,
            string wishlistItemUrl)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemNameInput));
            Wait.Until(ElementToBeVisible(_wishlistItemPriceInput));
            Wait.Until(ElementToBeVisible(_wishlistItemDescriptionInput));
            Wait.Until(ElementToBeVisible(_wishlistItemUrlInput));
            Wait.Until(ElementToBeVisible(_wishlistItemImage));


            _wishlistItemNameInput.GetAttribute("value").Should().Be(wishlistItemName);
            _wishlistItemDescriptionInput.GetAttribute("value").Should().Be(wishlistItemDescription);
            _wishlistItemUrlInput.GetAttribute("value").Should().Be(wishlistItemUrl);

            return this;
        }

        [AllureStep("Set Price to '${0}'")]
        public ItemDetailsModal SetWishlistItemPrice(string wishlistItemPrice)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemPriceInput));
            _wishlistItemPriceInput.SendKeys(wishlistItemPrice);
            return this;
        }

        [AllureStep("Click 'Confirm' button")]
        public ItemDetailsModal ClickConfirmButton()
        {
            Wait.Until(ElementToBeClickable(_confirmButton));
            _confirmButton.Click();
            return this;
        }
    }
}