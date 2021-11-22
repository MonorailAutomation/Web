using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class AddNewWishlistItemModal : Modal
    {
        private const string AddNewWishlistItemHeaderText = "Add new Item";
        private const string AddNewWishlistItemMessageText = "Paste a link from anywhere on the web:";
        private const string AddNewWishlistItemLinkPlaceholder = "http://";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _addNewWishlistItemMessage;

        [FindsBy(How = How.Id, Using = "itemURL_wishlist")]
        private IWebElement _linkField;

        public AddNewWishlistItemModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Add new Item' modal")]
        public AddNewWishlistItemModal CheckAddNewItemModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_addNewWishlistItemMessage));
                Wait.Until(ElementToBeVisible(_linkField));
                Wait.Until(ElementToBeVisible(CancelButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Contain(AddNewWishlistItemHeaderText);
                _addNewWishlistItemMessage.Text.Should().Be(AddNewWishlistItemMessageText);
                _linkField.GetAttribute("placeholder").Should().Be(AddNewWishlistItemLinkPlaceholder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return this;
        }

        [AllureStep("Paste link: {0}")]
        public AddNewWishlistItemModal PasteLink(string wishlistItemUrl)
        {
            Wait.Until(ElementToBeVisible(_linkField));
            _linkField.SendKeys(wishlistItemUrl);
            return this;
        }
    }
}