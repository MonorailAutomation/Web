using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals.ItemModals
{
    public class CompleteYourItemInfoDescriptionModal : Modal
    {
        private const string CompleteYourItemInfoModalHeaderText = "Complete your Item info";
        private const string DescriptionInputPlaceholderText = "Write a description...";
        private const string MissingNameItem = "Name";
        private const string MissingImageItem = "Image";
        private const string MissingPriceItem = "Price";
        private const string MissingDescriptionItem = "Description (optional)";

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[@class='active']")]
        private IWebElement _missingDescriptionItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[@class='complete'][2]")]
        private IWebElement _missingImageItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[@class='complete'][1]")]
        private IWebElement _missingNameActiveItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[@class='complete'][3]")]
        private IWebElement _missingPriceItem;

        [FindsBy(How = How.XPath, Using = "//textarea")]
        private IWebElement _wishlistItemDescriptionInput;

        public CompleteYourItemInfoDescriptionModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Complete your Item info' modal for inserting description")]
        public CompleteYourItemInfoDescriptionModal CheckCompleteYourItemInfoDescriptionModalModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_missingNameActiveItem));
                Wait.Until(ElementToBeVisible(_missingImageItem));
                Wait.Until(ElementToBeVisible(_missingPriceItem));
                Wait.Until(ElementToBeVisible(_missingDescriptionItem));
                Wait.Until(ElementToBeVisible(_wishlistItemDescriptionInput));

                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Contain(CompleteYourItemInfoModalHeaderText);
                _missingNameActiveItem.Text.Should().Be(MissingNameItem);
                _missingImageItem.Text.Should().Be(MissingImageItem);
                _missingPriceItem.Text.Should().Be(MissingPriceItem);
                _missingDescriptionItem.Text.Should().Be(MissingDescriptionItem);
                _wishlistItemDescriptionInput.GetAttribute("placeholder").Should().Be(DescriptionInputPlaceholderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Set Wishlist Item Description to: '${0}'")]
        public CompleteYourItemInfoDescriptionModal SetWishlistItemDescription(string wishlistItemDescription)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemDescriptionInput));
            _wishlistItemDescriptionInput.SendKeys(wishlistItemDescription);
            return this;
        }
    }
}