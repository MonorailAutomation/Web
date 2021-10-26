using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class AddNewWishlistItemModal
    {
        private const string AddNewWishlistItemHeader = "Add new Item";
        private const string AddNewWishlistItemMessage = "Paste a link from anywhere on the web:";
        private const string AddNewWishlistItemLinkPlaceholder = "http://";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _addNewWishlistItemHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _addNewWishlistItemMessage;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Cancel')]")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(),'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "itemURL_wishlist")]
        private IWebElement _linkField;

        public AddNewWishlistItemModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add new Item' modal")]
        public AddNewWishlistItemModal CheckAddNewItemModal()
        {
            Wait.Until(ElementToBeVisible(_addNewWishlistItemHeader));
            Wait.Until(ElementToBeVisible(_addNewWishlistItemMessage));
            Wait.Until(ElementToBeVisible(_linkField));
            Wait.Until(ElementToBeVisible(_cancelButton));
            Wait.Until(ElementToBeVisible(_continueButton));

            _addNewWishlistItemHeader.Text.Should().Contain(AddNewWishlistItemHeader);
            _addNewWishlistItemMessage.Text.Should().Be(AddNewWishlistItemMessage);
            _linkField.GetAttribute("placeholder").Should().Be(AddNewWishlistItemLinkPlaceholder);

            return this;
        }

        [AllureStep("Paste link: {0}")]
        public AddNewWishlistItemModal PasteLink(string wishlistItemUrl)
        {
            Wait.Until(ElementToBeVisible(_linkField));
            _linkField.SendKeys(wishlistItemUrl);
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public AddNewWishlistItemModal ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_continueButton));
            _continueButton.Click();
            return this;
        }
    }
}