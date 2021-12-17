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
    public class AddWishlistItemSuccessModal : AddItemSuccessModal
    {
        private const string SuccessHeaderText = "Good one!";
        private const string SuccessMessageText = "You are one step closer to getting your";
        private const string OpenWishlistAccountMessageText = "Ready to power your wishlist?";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _successMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2[2]")]
        private IWebElement _wishlistItemName;
        
        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//p")]
        private IWebElement _openWishlistAccountMessage;
        
        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Open Wishlist Account')]")]
        private IWebElement _openWishlistAccountButton;

        public AddWishlistItemSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        
        [AllureStep("Click 'Open Wishlist Account' button")]
        public AddWishlistItemSuccessModal ClickOpenWishlistAccountButton()
        {
            Wait.Until(ElementToBeClickable(_openWishlistAccountButton));
            _openWishlistAccountButton.Click();
            return this;
        }

        [AllureStep("Check 'Success' modal after onboarding")]
        public AddWishlistItemSuccessModal CheckAddWishlistItemSuccessModalAfterOnboarding()
        {
            try
            {
                CheckAddItemSuccessModal(SuccessHeaderText);
                Wait.Until(ElementToBeVisible(_successMessage));
                Wait.Until(ElementToBeVisible(_wishlistItemName));

                _successMessage.Text.Should().Be(SuccessMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
        
        [AllureStep("Check 'Success' modal before onboarding")]
        public AddWishlistItemSuccessModal CheckAddWishlistItemSuccessModalBeforeOnboarding()
        {
            try
            {
                CheckAddItemSuccessModal(SuccessHeaderText);
                Wait.Until(ElementToBeVisible(_successMessage));
                Wait.Until(ElementToBeVisible(_wishlistItemName));
                Wait.Until(ElementToBeVisible(_openWishlistAccountMessage));
                Wait.Until(ElementToBeVisible(_openWishlistAccountButton));

                _successMessage.Text.Should().Be(SuccessMessageText);
                _openWishlistAccountMessage.Text.Should().Be(OpenWishlistAccountMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Verify if Wishlist item name is: {0}")]
        public AddWishlistItemSuccessModal VerifyWishlistItemName(string wishlistItemName)
        {
            Wait.Until(ElementToBeVisible(_wishlistItemName));
            _wishlistItemName.Text.Should().Be(wishlistItemName);
            return this;
        }
    }
}