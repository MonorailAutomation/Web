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
    public class CompleteYourItemInfoEntryModal : Modal
    {
        private const string CompleteYourItemInfoModalHeaderText = "Complete your Item info";

        private const string CompleteYourItemInfoModalMessageText =
            "There is some missing information about your item we were not able to get automatically.";

        private const string CompleteYourItemInfoModalHelpMessageText =
            "You can either try again or continue to complete them manually.";

        private const string MissingNameItem = "Name";
        private const string MissingImageItem = "Image";
        private const string MissingPriceItem = "Price";
        private const string MissingDescriptionItem = "Description (optional)";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p[contains(text(), 'manually')]")]
        private IWebElement _completeYourItemInfoModalHelpMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        private IWebElement _completeYourItemInfoModalMessage;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[4]")]
        private IWebElement _missingDescriptionItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[2]")]
        private IWebElement _missingImageItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[1]")]
        private IWebElement _missingNameItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[3]")]
        private IWebElement _missingPriceItem;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Remove item')]")]
        private IWebElement _removeItemButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Try again')]")]
        private IWebElement _tryAgainButton;

        public CompleteYourItemInfoEntryModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Complete your Item info' entry modal")]
        public CompleteYourItemInfoEntryModal CheckCompleteYourItemInfoEntryModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_removeItemButton));
                Wait.Until(ElementToBeVisible(_completeYourItemInfoModalMessage));
                Wait.Until(ElementToBeVisible(_completeYourItemInfoModalHelpMessage));
                Wait.Until(ElementToBeVisible(_missingNameItem));
                Wait.Until(ElementToBeVisible(_missingImageItem));
                Wait.Until(ElementToBeVisible(_missingPriceItem));
                Wait.Until(ElementToBeVisible(_missingDescriptionItem));
                Wait.Until(ElementToBeVisible(_tryAgainButton));
                Wait.Until(ElementToBeVisible(ContinueButton));

                ModalHeader.Text.Should().Contain(CompleteYourItemInfoModalHeaderText);
                _completeYourItemInfoModalMessage.Text.Should().Be(CompleteYourItemInfoModalMessageText);
                _completeYourItemInfoModalHelpMessage.Text.Should().Be(CompleteYourItemInfoModalHelpMessageText);
                _missingNameItem.Text.Should().Be(MissingNameItem);
                _missingImageItem.Text.Should().Be(MissingImageItem);
                _missingPriceItem.Text.Should().Be(MissingPriceItem);
                _missingDescriptionItem.Text.Should().Be(MissingDescriptionItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}