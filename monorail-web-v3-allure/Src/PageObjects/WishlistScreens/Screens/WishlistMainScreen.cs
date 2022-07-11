using System;
using System.Threading;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using static monorail_web_v3.Commons.Functions;

namespace monorail_web_v3.PageObjects.WishlistScreens.Screens
{
    public class WishlistMainScreen : WishlistScreen
    {
        private const string AvailableForYourNextItemMessageText = "Available funds";
        private const string ReadyToPowerYourWishlistMessageText = "Ready to power your Wishlist?";

        private const string ReadyToPowerYourWishlistMessageXPath = "//div[@class='container']//h2";
        private const string CreateAWishlistAccountButtonXPath = "//button[contains(text(),'Create a Wishlist Account')]";
        private const string MoneyAmountXPath = "//vim-wishlist-account//h1";
        private const string AvailableForYourNextItemMessageXPath = "//vim-wishlist-account//p";
        private const string ManageButtonXPath = "//button[contains(text(),'Manage')]";
        private const string AddCashButtonXPath = "//button[contains(text(),'Add Cash')]";
        private const string WishlistItemIsBeingAddedModalXPath = "//p[contains(text(),'Your wishlist item is being added!')]";

        [FindsBy(How = How.XPath, Using = AddCashButtonXPath)]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath,
            Using = "//button[contains(text(), 'Add item')]")]
        private IWebElement _addWishlistItemButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='empty-card__container']")]
        private IWebElement _addWishlistItemPlaceholder;

        [FindsBy(How = How.XPath,
            Using = AvailableForYourNextItemMessageXPath )]
        private IWebElement _availableForYourNextItemMessage;

        [FindsBy(How = How.XPath,
            Using = CreateAWishlistAccountButtonXPath)]
        private IWebElement _createAWishlistAccountButton;

        [FindsBy(How = How.XPath,
            Using = "//button[contains(text(),'How it Works')]")]
        private IWebElement _howItWorksButton;

        [FindsBy(How = How.XPath, Using = "//button/span[contains(text(), \"Let's Go\")]")]
        private IWebElement _letsGoButton;

        [FindsBy(How = How.XPath, Using = ManageButtonXPath)]
        private IWebElement _manageButton;

        [FindsBy(How = How.XPath,
            Using = MoneyAmountXPath)]
        private IWebElement _moneyAmount;

        [FindsBy(How = How.XPath, Using = ReadyToPowerYourWishlistMessageXPath)]
        private IWebElement _readyToPowerYourWishlistMessage;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Tap to Complete Info')]")]
        private IWebElement _tapToCompletePill;

        [FindsBy(How = How.XPath,
            Using = "//button[contains(text(),'View All')]")]
        private IWebElement _viewAllButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-page-header__title']//h1[contains(text(),'Wishlist')]")]
        private IWebElement _wishlistHeader;

        [FindsBy(How = How.XPath,
            Using = WishlistItemIsBeingAddedModalXPath)]
        private IWebElement _wishlistItemIsBeingAddedModal;

        public WishlistMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Create A Wishlist Account' button")]
        public WishlistMainScreen ClickCreateAWishlistAccountButton()
        {
            Wait.Until(ElementToBeClickable(_createAWishlistAccountButton));
            _createAWishlistAccountButton.Click();
            return this;
        }

        [AllureStep("Click 'Add Cash' button")]
        public WishlistMainScreen ClickAddCashButton()
        {
            Wait.Until(ElementToBeClickable(_addCashButton));
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Manage' button")]
        public WishlistMainScreen ClickManageButton()
        {
            Wait.Until(ElementToBeClickable(_manageButton));
            _manageButton.Click();
            return this;
        }

        [AllureStep("Click 'Let's Go' button")]
        public WishlistMainScreen ClickLetsGoButton()
        {
            Wait.Until(ElementToBeClickable(_letsGoButton));
            _letsGoButton.Click();
            return this;
        }

        [AllureStep("Click add Wishlist item using placeholder")]
        public WishlistMainScreen ClickAddWishlistItemPlaceholder()
        {
            Wait.Until(ElementToBeClickable(_addWishlistItemPlaceholder));
            _addWishlistItemPlaceholder.Click();
            return this;
        }

        [AllureStep("Click add Wishlist item using button")]
        public WishlistMainScreen ClickAddWishlistItemButton()
        {
            Wait.Until(ElementToBeClickable(_addWishlistItemButton));
            _addWishlistItemButton.Click();
            return this;
        }

        [AllureStep("Click '{0}' item")]
        public WishlistMainScreen ClickWishlistItem(string wishlistItemName)
        {
            var wishlistItemSelector = "//p[contains(text(), '" + wishlistItemName + "')]";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemSelector))).Click();
            return this;
        }

        [AllureStep("Click 'Tap to Complete Info' pill")]
        public WishlistMainScreen ClickTapToCompleteInfoPill()
        {
            Wait.Until(ElementToBeClickable(_tapToCompletePill)).Click();
            return this;
        }

        [AllureStep("Check if item is no longer displayed in the wishlist")]
        public WishlistMainScreen CheckNoWishlistItem(string wishlistItemName)
        {
            var wishlistItemSelector = "//p[contains(text(), '" + wishlistItemName + "')]";
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(wishlistItemSelector)));
            return this;
        }

        [AllureStep("Check if ${0} item is in ${1} status")]
        public WishlistMainScreen CheckStatusForItem(string wishlistItemName, string status)
        {
            var wishlistItemSelector = "//p[contains(text(), '" + wishlistItemName + "')]";
            var wishlistItemStatusSelector = wishlistItemSelector + "//following-sibling::span";

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(wishlistItemSelector)));
            var wishlistItemStatus = Driver.FindElement(By.XPath(wishlistItemStatusSelector));
            wishlistItemStatus.Text.Should().Be(status);

            return this;
        }

        [AllureStep("Check if 'Your wishlist item is being added!' bar is no longer displayed")]
        public WishlistMainScreen CheckItemBeingAddedBarDisappeared()
        {
            Wait.Until(ElementToBeNotVisible(_wishlistItemIsBeingAddedModal));
            return this;
        }

        [AllureStep("Check Wishlist Main screen after onboarding")]
        public WishlistMainScreen CheckWishlistMainScreenAfterOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_wishlistHeader));
                Wait.Until(ElementToBeVisible(_howItWorksButton));
                Wait.Until(ElementToBeVisible(_moneyAmount));
                Wait.Until(ElementToBeVisible(_availableForYourNextItemMessage));
                Wait.Until(ElementToBeVisible(_addWishlistItemButton));
                Wait.Until(ElementToBeVisible(_manageButton));
                Wait.Until(ElementToBeVisible(_addCashButton));

                IsElementNotVisibleByXpath(ReadyToPowerYourWishlistMessageXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(CreateAWishlistAccountButtonXPath, Driver).Should().BeTrue();

                _availableForYourNextItemMessage.Text.Should().Be(AvailableForYourNextItemMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check Wishlist Main screen before onboarding")]
        public WishlistMainScreen CheckWishlistMainScreenBeforeOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_wishlistHeader));
                Wait.Until(ElementToBeVisible(_howItWorksButton));
                Wait.Until(ElementToBeVisible(_addWishlistItemButton));
                Wait.Until(ElementToBeVisible(_addWishlistItemPlaceholder));
                Wait.Until(ElementToBeVisible(_readyToPowerYourWishlistMessage));
                Wait.Until(ElementToBeVisible(_createAWishlistAccountButton));

                IsElementNotVisibleByXpath(MoneyAmountXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(AvailableForYourNextItemMessageXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(ManageButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(AddCashButtonXPath, Driver).Should().BeTrue();

                _readyToPowerYourWishlistMessage.Text.Should().Be(ReadyToPowerYourWishlistMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}