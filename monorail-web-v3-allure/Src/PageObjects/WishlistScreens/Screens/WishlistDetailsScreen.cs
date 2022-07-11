using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using static monorail_web_v3.Commons.Functions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreens.Screens
{
    public class WishlistDetailsScreen : WishlistScreen
    {
        private const string ReadyToBuyButtonXPath = "//button[contains(text(), 'Ready to Buy')]";
        private const string FundYourWishlistButtonXPath = "//button[contains(text(),'Fund your Wishlist')]";
        private const string ProgressBarXPath = "//div[@class='vim-progress-bar']";
        private const string PurchaseItemButtonXPath = "//button[contains(text(), 'Purchase Item')]";

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'back-button')]")]
        private IWebElement _backButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Edit')]")]
        private IWebElement _editButton;

        [FindsBy(How = How.XPath, Using = FundYourWishlistButtonXPath)]
        private IWebElement _fundYourWishlistButton;

        [FindsBy(How = How.XPath, Using = ProgressBarXPath)]
        private IWebElement _progressBar;

        [FindsBy(How = How.XPath, Using = PurchaseItemButtonXPath)]
        private IWebElement _purchaseItemButton;

        [FindsBy(How = How.XPath, Using = ReadyToBuyButtonXPath)]
        private IWebElement _readyToBuyButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Remove')]")]
        private IWebElement _removeButton;

        [FindsBy(How = How.XPath,
            Using = "//p[contains(@class, 'wishlit-transferring-status__details__description')]")]
        private IWebElement _wishlistTransferringStatusDescription;

        [FindsBy(How = How.XPath, Using = "//p[contains(@class, 'wishlit-transferring-status__details__text')]")]
        private IWebElement _wishlistTransferringStatusDetailText;

        [FindsBy(How = How.XPath, Using = "//p[contains(@class, 'wishlit-transferring-status__title')]")]
        private IWebElement _wishlistTransferringStatusTitle;

        public WishlistDetailsScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click '<' button")]
        public WishlistDetailsScreen ClickBackButton()
        {
            Wait.Until(ElementToBeClickable(_backButton));
            _backButton.Click();
            return this;
        }

        [AllureStep("Click 'Remove' button")]
        public WishlistDetailsScreen ClickRemoveButton()
        {
            Wait.Until(ElementToBeClickable(_removeButton));
            _removeButton.Click();
            return this;
        }

        [AllureStep("Click 'Ready to Buy' button")]
        public WishlistDetailsScreen ClickReadyToBuyButton()
        {
            Wait.Until(ElementToBeClickable(_readyToBuyButton));
            _readyToBuyButton.Click();
            return this;
        }

        [AllureStep("Click 'Fund your Wishlist' button")]
        public WishlistDetailsScreen ClickFundYourWishlistButton()
        {
            Wait.Until(ElementToBeClickable(_fundYourWishlistButton));
            _fundYourWishlistButton.Click();
            return this;
        }

        [AllureStep("Click 'Edit' button")]
        public WishlistDetailsScreen ClickEditButton()
        {
            Wait.Until(ElementToBeClickable(_editButton));
            _editButton.Click();
            return this;
        }

        [AllureStep("Check Wishlist Item Details screen for 'Not Ready to Buy' status")]
        public WishlistDetailsScreen CheckWishlistItemDetailsScreenForNotReadyToBuyItemStatus()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_backButton));
                Wait.Until(ElementToBeVisible(_removeButton));
                Wait.Until(ElementToBeVisible(_fundYourWishlistButton));
                Wait.Until(ElementToBeVisible(_editButton));
                Wait.Until(ElementToBeVisible(_progressBar));

                IsElementNotVisibleByXpath(ReadyToBuyButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(PurchaseItemButtonXPath, Driver).Should().BeTrue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check Wishlist Item Details screen for internal 'Purchase Item' status")]
        public WishlistDetailsScreen CheckWishlistItemDetailsScreenForInternalPurchaseItemStatus(string amount)
        {
            const string wishlistTransferringStatusTitle = "Your funds have transferred!";
            const string wishlistTransferringStatusDetailsText =
                "has completed transferring to your Monorail Account";
            const string wishlistTransferringStatusDetailsDescription = "Transfer completed on ";
            try
            {
                Wait.Until(ElementToBeVisible(_backButton));
                Wait.Until(ElementToBeVisible(_removeButton));
                Wait.Until(ElementToBeVisible(_purchaseItemButton));
                Wait.Until(ElementToBeVisible(_editButton));
                Wait.Until(ElementToBeVisible(_wishlistTransferringStatusTitle));
                Wait.Until(ElementToBeVisible(_wishlistTransferringStatusDetailText));

                IsElementNotVisibleByXpath(ReadyToBuyButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(FundYourWishlistButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(ProgressBarXPath, Driver).Should().BeTrue();

                _wishlistTransferringStatusTitle.Text.Should().Be(wishlistTransferringStatusTitle);
                _wishlistTransferringStatusDetailText.Text.Should()
                    .Contain( wishlistTransferringStatusDetailsText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check Wishlist Item Details screen for external 'Transferring' status")]
        public WishlistDetailsScreen CheckWishlistItemDetailsScreenForExternalFundsTransferringStatus(string amount)
        {
            const string wishlistTransferringStatusTitle = "Your funds are on the way!";
            const string wishlistTransferringStatusDetailsTextPartOne = " is on the way to your connected account (";
            const string wishlistTransferringStatusDetailsTextPartTwo = "- 0000)";
            const string wishlistTransferringStatusDetailsDescription = "Transfer started on ";
            try
            {
                Wait.Until(ElementToBeVisible(_backButton));
                Wait.Until(ElementToBeVisible(_removeButton));
                Wait.Until(ElementToBeVisible(_editButton));
                Wait.Until(ElementToBeVisible(_wishlistTransferringStatusTitle));
                Wait.Until(ElementToBeVisible(_wishlistTransferringStatusDetailText));

                IsElementNotVisibleByXpath(PurchaseItemButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(ReadyToBuyButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(FundYourWishlistButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(ProgressBarXPath, Driver).Should().BeTrue();

                _wishlistTransferringStatusTitle.Text.Should().Be(wishlistTransferringStatusTitle);
                _wishlistTransferringStatusDetailText.Text.Should()
                    .Contain(wishlistTransferringStatusDetailsTextPartOne);
                _wishlistTransferringStatusDetailText.Text.Should()
                    .Contain(wishlistTransferringStatusDetailsTextPartTwo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Verify if Wishlist item name is: '{0}', description is: '{1}', price is: '{2}', url is: '{3}'")]
        public WishlistDetailsScreen VerifyWishlistItemDetails(string wishlistItemName, string wishlistItemDescription,
            string wishlistItemPrice, string wishlistItemUrl)
        {
            const string wishlistItemUrlSelector = "//a[@class='wishlist-details__sidebar__logo-wrapper']";

            VerifyWishlistItemDetails(wishlistItemName, wishlistItemDescription, wishlistItemPrice);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemUrlSelector))).GetAttribute("href")
                .Should().Contain(wishlistItemUrl);

            return this;
        }

        [AllureStep("Verify if Wishlist item name is: '{0}', description is: '{1}', price is: '{2}''")]
        public WishlistDetailsScreen VerifyWishlistItemDetails(string wishlistItemName, string wishlistItemDescription,
            string wishlistItemPrice)
        {
            var wishlistItemNameSelector = "//div//h2[contains(text(), '" + wishlistItemName + "')]";
            var wishlistItemDescriptionSelector = "//div//p[contains(text(), '" + wishlistItemDescription + "')]";
            var wishlistItemPriceSelector = "//div//h2[contains(text(), '" + wishlistItemPrice + "')]";

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemNameSelector))).Text.Should()
                .Contain(wishlistItemName);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemDescriptionSelector))).Text.Should()
                .Contain(wishlistItemDescription);
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemPriceSelector))).Text.Should()
                .Contain(wishlistItemPrice);

            return this;
        }
    }
}