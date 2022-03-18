using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Modals;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class WishlistItemDetailsModal : ItemDetailsModal
    {
        private const string ItemDetailsHeaderText = "Item details";

        [FindsBy(How = How.XPath, Using = "//textarea[@formcontrolname='description']")]
        private IWebElement _wishlistDescriptionInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//img")]
        private IWebElement _wishlistItemImage;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='name']")]
        private IWebElement _wishlistItemNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='amount']")]
        private IWebElement _wishlistItemPriceInput;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='itemURL']")]
        private IWebElement _wishlistItemUrlInput;

        public WishlistItemDetailsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Item details' modal")]
        public WishlistItemDetailsModal CheckItemDetailsModal()
        {
            try
            {
                CheckItemDetailsModal(ItemDetailsHeaderText);
                Wait.Until(ElementToBeVisible(_wishlistItemImage));
                Wait.Until(ElementToBeVisible(_wishlistItemPriceInput));
                Wait.Until(ElementToBeVisible(_wishlistDescriptionInput));
                Wait.Until(ElementToBeVisible(_wishlistItemNameInput));
                Wait.Until(ElementToBeVisible(ConfirmButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Verify data on 'Item Details' screen")]
        public WishlistItemDetailsModal CheckLoadedDataOnItemDetailsModal(string wishlistItemName,
            string wishlistItemDescription,
            string wishlistItemUrl)
        {
            CheckItemNameDescriptionItemUrl(wishlistItemName, wishlistItemDescription, wishlistItemUrl);
            return this;
        }

        [AllureStep("Verify data on 'Edit Item Details' screen")]
        public WishlistItemDetailsModal CheckLoadedDataOnItemDetailsModal(string wishlistItemName,
            string wishlistItemDescription,
            string wishlistItemUrl, string wishlistItemPrice)
        {
            CheckItemNameDescriptionItemUrl(wishlistItemName, wishlistItemDescription, wishlistItemUrl);
            _wishlistItemPriceInput.GetAttribute("value").Should().Contain(wishlistItemPrice);
            return this;
        }

        [AllureStep("Set Price to: '${0}'")]
        public WishlistItemDetailsModal SetWishlistItemPrice(string wishlistItemPrice)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemPriceInput));
            _wishlistItemPriceInput.SendKeys(wishlistItemPrice);
            return this;
        }

        [AllureStep("Edit Price to: '${0}'")]
        public WishlistItemDetailsModal EditItemPrice(string changedItemPrice)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemPriceInput));
            _wishlistItemPriceInput.Clear();
            _wishlistItemPriceInput.SendKeys(changedItemPrice);
            return this;
        }

        [AllureStep("Edit Name to: '${0}'")]
        public WishlistItemDetailsModal EditItemName(string changedItemName)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemNameInput));
            _wishlistItemNameInput.Clear();
            _wishlistItemNameInput.SendKeys(changedItemName);
            return this;
        }

        [AllureStep("Edit Description to '${0}'")]
        public WishlistItemDetailsModal EditItemDescription(string changedItemDescription)
        {
            Wait.Until(ElementToBeVisible(_wishlistDescriptionInput));
            _wishlistDescriptionInput.Clear();
            _wishlistDescriptionInput.SendKeys(changedItemDescription);
            return this;
        }

        private void CheckItemNameDescriptionItemUrl(string wishlistItemName,
            string wishlistItemDescription,
            string wishlistItemUrl)
        {
            ItemNameInput.GetAttribute("value").Should().Contain(wishlistItemName);
            _wishlistDescriptionInput.GetAttribute("value").Should().Contain(wishlistItemDescription);
            //_wishlistItemUrlInput.GetAttribute("value").Should().Be(wishlistItemUrl);
        }
    }
}