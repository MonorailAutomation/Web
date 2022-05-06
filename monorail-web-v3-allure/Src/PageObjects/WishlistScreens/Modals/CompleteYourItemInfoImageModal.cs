using System;
using System.Threading;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Modals
{
    public class CompleteYourItemInfoImageModal : Modal
    {
        private const string CompleteYourItemInfoModalHeaderText = "Complete your Item info";
        private const string MissingNameItem = "Name";
        private const string MissingImageItem = "Image";
        private const string MissingPriceItem = "Price";
        private const string MissingDescriptionItem = "Description (optional)";

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'carousel__images__item')][1]")]
        private IWebElement _firstImageOnCarousel;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[4]")]
        private IWebElement _missingDescriptionItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[@class='active']")]
        private IWebElement _missingImageItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[@class='complete']")]
        private IWebElement _missingNameActiveItem;

        [FindsBy(How = How.XPath, Using = "//ul[@class='vim-wishlist-item-info-list']//li[3]")]
        private IWebElement _missingPriceItem;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _tipMessage;

        public CompleteYourItemInfoImageModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Check 'Complete your Item info' modal for selecting image")]
        public CompleteYourItemInfoImageModal CheckCompleteYourItemInfoImageModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(_missingNameActiveItem));
                Wait.Until(ElementToBeVisible(_missingImageItem));
                Wait.Until(ElementToBeVisible(_missingPriceItem));
                Wait.Until(ElementToBeVisible(_missingDescriptionItem));
                Wait.Until(ElementToBeClickable(_firstImageOnCarousel));
                Wait.Until(ElementToBeClickable(BackButton));
                Wait.Until(ElementToBeClickable(ContinueButton));

                ModalHeader.Text.Should().Contain(CompleteYourItemInfoModalHeaderText);
                _missingNameActiveItem.Text.Should().Be(MissingNameItem);
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

        [AllureStep("Click first image on the carousel")]
        public CompleteYourItemInfoImageModal ClickFirstImageOnCarousel()
        {
            Wait.Until(ElementToBeClickable(_firstImageOnCarousel));
            Thread.Sleep(2500); // wait until all images are loaded
            _firstImageOnCarousel.Click();
            return this;
        }
    }
}