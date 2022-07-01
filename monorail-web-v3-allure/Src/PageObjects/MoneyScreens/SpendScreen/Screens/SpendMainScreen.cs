using System;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using static monorail_web_v3.Commons.Waits;

namespace monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Screens
{
    public class SpendMainScreen : MoneyScreen
    {
        private const string SpendHeaderText = "Spend";

        private const string EmptyScreenHeadlineText =
            "Spend your money directly from Monorail using the free checking account and debit card.";

        private const string EmptyScreenFirstBulletPointText =
            "Stay on top of every purchase with transparent transactions";

        private const string EmptyScreenSecondBulletPointText = "Balance work and life by enabling direct deposit";
        private const string EmptyScreenThirdBulletPointText = "Only spend what you have with the Monorail debit card";
        private const string EmptyScreenFourthBulletPointText = "Keep your money all in one place";

        private const string CardOnTheWayHeaderText = "Your new card is on the way!";

        private const string CardOnTheWayMessageText =
            "It should arrive in 5-10 business days. When it does, activate it below.";

        private const string ActiveCardBadgeText = "Active";
        private const string LockedCardBadgeText = "Locked";

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Activate Card')]")]
        private IWebElement _activateCardButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add Cash')]")]
        private IWebElement _addCashButton;

        [FindsBy(How = How.XPath, Using = "//vim-active-card//p[1]")]
        private IWebElement _cardOnTheWayHeader;

        [FindsBy(How = How.XPath, Using = "//vim-active-card//p[2]")]
        private IWebElement _cardOnTheWayMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='status-badge active']")]
        private IWebElement _cardStatusBadgeActive;

        [FindsBy(How = How.XPath, Using = "//div[@class='status-badge locked']")]
        private IWebElement _cardStatusBadgeLocked;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cash Out')]")]
        private IWebElement _cashOutButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//li[1]")]
        private IWebElement _emptyScreenFirstBulletPoint;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//li[4]")]
        private IWebElement _emptyScreenFourthBulletPoint;

        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement _emptyScreenHeadline;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//li[2]")]
        private IWebElement _emptyScreenSecondBulletPoint;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//li[3]")]
        private IWebElement _emptyScreenThirdBulletPoint;

        [FindsBy(How = How.XPath, Using = "//vim-toggle[contains(@ng-reflect-disable, 'false')]")]
        private IWebElement _lockUnlockCardToggle;

        [FindsBy(How = How.XPath, Using = "//div[@id='moreOptionsDropdown']")]
        private IWebElement _moreOptionsButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Move Funds')]")]
        private IWebElement _moveFundsButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Open your Monorail Checking Account')]")]
        private IWebElement _openYourMonorailCheckingAccountButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-page-header__title']//h1[1]")]
        private IWebElement _spendHeader;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'View Transactions')]")]
        private IWebElement _viewTransactionsButton;

        public SpendMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add Cash' button")]
        public SpendMainScreen ClickAddCashButton()
        {
            Wait.Until(ElementToBeClickable(_addCashButton));
            _addCashButton.Click();
            return this;
        }

        [AllureStep("Click 'Cash Out' button")]
        public SpendMainScreen ClickCashOutButton()
        {
            Wait.Until(ElementToBeClickable(_cashOutButton));
            _cashOutButton.Click();
            return this;
        }

        [AllureStep("Click 'Open your Checking Account' button")]
        public SpendMainScreen ClickOpenYourCheckingAccountButton()
        {
            Wait.Until(ElementToBeClickable(_openYourMonorailCheckingAccountButton));
            _openYourMonorailCheckingAccountButton.Click();
            return this;
        }

        [AllureStep("Click 'Activate Card' button")]
        public SpendMainScreen ClickActivateCardButton()
        {
            Wait.Until(ElementToBeClickable(_activateCardButton));
            _activateCardButton.Click();
            return this;
        }

        [AllureStep("Click 'Lock/Unlock Card' toggle")]
        public SpendMainScreen ClickLockUnlockCardToggle()
        {
            Wait.Until(ElementToBeClickable(_lockUnlockCardToggle));
            _lockUnlockCardToggle.Click();
            return this;
        }

        [AllureStep("Check if card is locked")]
        public SpendMainScreen CheckIfCardIsLocked()
        {
            Wait.Until(ElementToBeVisible(_cardStatusBadgeLocked));
            _cardStatusBadgeLocked.Text.Should().Be(LockedCardBadgeText);
            return this;
        }

        [AllureStep("Check if card is active")]
        public SpendMainScreen CheckIfCardIsActive()
        {
            Wait.Until(ElementToBeVisible(_cardStatusBadgeActive));
            _cardStatusBadgeActive.Text.Should().Be(ActiveCardBadgeText);
            return this;
        }

        [AllureStep("Check 'Spend' screen before onboarding")]
        public SpendMainScreen CheckSpendScreenBeforeOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_spendHeader));
                Wait.Until(ElementToBeVisible(_emptyScreenHeadline));
                Wait.Until(ElementToBeVisible(_emptyScreenFirstBulletPoint));
                Wait.Until(ElementToBeVisible(_emptyScreenSecondBulletPoint));
                Wait.Until(ElementToBeVisible(_emptyScreenThirdBulletPoint));
                Wait.Until(ElementToBeVisible(_emptyScreenFourthBulletPoint));
                Wait.Until(ElementToBeVisible(_openYourMonorailCheckingAccountButton));

                _spendHeader.Text.Should().Contain(SpendHeaderText);
                _emptyScreenHeadline.Text.Should().Contain(EmptyScreenHeadlineText);
                _emptyScreenFirstBulletPoint.Text.Should().Contain(EmptyScreenFirstBulletPointText);
                _emptyScreenSecondBulletPoint.Text.Should().Contain(EmptyScreenSecondBulletPointText);
                _emptyScreenThirdBulletPoint.Text.Should().Contain(EmptyScreenThirdBulletPointText);
                _emptyScreenFourthBulletPoint.Text.Should().Contain(EmptyScreenFourthBulletPointText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check 'Spend' screen after onboarding, before card activation")]
        public SpendMainScreen CheckSpendScreenAfterOnboardingBeforeCardActivation()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_spendHeader));
                Wait.Until(ElementToBeVisible(_addCashButton));
                Wait.Until(ElementToBeVisible(_cardOnTheWayHeader));
                Wait.Until(ElementToBeVisible(_cardOnTheWayMessage));
                Wait.Until(ElementToBeVisible(_activateCardButton));
                Wait.Until(ElementToBeVisible(_viewTransactionsButton));
                Wait.Until(ElementToBeVisible(_moveFundsButton));
                Wait.Until(ElementToBeVisible(_moreOptionsButton));
                //TODO: Find a way to handle these checks in a short period of time
                //Wait.Until(ElementToBeNotVisible(_openYourMonorailCheckingAccountButton));

                _spendHeader.Text.Should().Contain(SpendHeaderText);
                _cardOnTheWayHeader.Text.Should().Contain(CardOnTheWayHeaderText);
                _cardOnTheWayMessage.Text.Should().Contain(CardOnTheWayMessageText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        [AllureStep("Check 'Spend' screen after onboarding, after card activation")]
        public SpendMainScreen CheckSpendScreenAfterOnboardingAfterCardActivation()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_spendHeader));
                Wait.Until(ElementToBeVisible(_addCashButton));
                Wait.Until(ElementToBeVisible(_viewTransactionsButton));
                Wait.Until(ElementToBeVisible(_moveFundsButton));
                Wait.Until(ElementToBeVisible(_moreOptionsButton));
                //TODO: Find a way to handle these checks in a short period of time
                //Wait.Until(ElementToBeNotVisible(_openYourMonorailCheckingAccountButton));
                //Wait.Until(ElementToBeNotVisible(_cardOnTheWayHeader));
                //Wait.Until(ElementToBeNotVisible(_cardOnTheWayMessage));
                //Wait.Until(ElementToBeNotVisible(_activateCardButton));

                _spendHeader.Text.Should().Contain(SpendHeaderText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}