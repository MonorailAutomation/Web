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
    public class CompleteYourItemInfoNameModal : Modal
    {
        private const string CompleteYourItemInfoModalHeaderText = "Complete your Item info";
        private const string NameInputPlaceholderText = "Insert name...";
        private const string TipMessageText = "Tip: Copy and paste the product name from the website for best results.";
        private const string MissingNameItem = "Name";
        private const string MissingImageItem = "Image";
        private const string MissingPriceItem = "Price";
        private const string MissingDescriptionItem = "Description (optional)";

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[4]")]
        private IWebElement _missingDescriptionItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[2]")]
        private IWebElement _missingImageItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[@class='active']")]
        private IWebElement _missingNameActiveItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[3]")]
        private IWebElement _missingPriceItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _tipMessage;

        [FindsBy(How = How.XPath, Using = "//textarea")]
        private IWebElement _wishlistItemNameInput;

        public CompleteYourItemInfoNameModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Complete your Item info' modal for inserting name")]
        public CompleteYourItemInfoNameModal CheckCompleteYourItemInfoNameModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_missingNameActiveItem));
                Wait.Until(ElementToBeVisible(_missingImageItem));
                Wait.Until(ElementToBeVisible(_missingPriceItem));
                Wait.Until(ElementToBeVisible(_missingDescriptionItem));
                Wait.Until(ElementToBeVisible(_wishlistItemNameInput));

                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Contain(CompleteYourItemInfoModalHeaderText);
                _missingNameActiveItem.Text.Should().Be(MissingNameItem);
                _missingImageItem.Text.Should().Be(MissingImageItem);
                _missingPriceItem.Text.Should().Be(MissingPriceItem);
                _missingDescriptionItem.Text.Should().Be(MissingDescriptionItem);
                _wishlistItemNameInput.GetAttribute("placeholder").Should().Be(NameInputPlaceholderText);
                _tipMessage.Text.Should().Be(TipMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Set Wishlist Item Name to: '${0}'")]
        public CompleteYourItemInfoNameModal SetWishlistItemName(string wishlistItemName)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemNameInput));
            _wishlistItemNameInput.SendKeys(wishlistItemName);
            return this;
        }
    }
}