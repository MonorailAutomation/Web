using System;
using System.Linq;
using FluentAssertions;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Enums;
using static monorail_web_v3.Commons.Functions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens
{
    public class SaveMainScreen : MoneyScreen
    {
        private const string EmptyScreenHeadlineText = "Separate your Wishlist from your dedicated savings funds.";
        private const string EmptyScreenMessageTextPartOne = "And automate deposits on your schedule.";
        private const string FundYourTracksButtonXPath = "//button[contains(text(), 'Fund your Tracks')]";
        private const string AddSavingTrackButtonXPath = "//button[contains(text(), 'Add Saving Track')]";
        private const string UnlockSavingsTracksButtonXPath = "//button[contains(text(), 'Unlock Savings Tracks')]";

        private const string EmptyScreenMessageTextPartTwo =
            "So you always stay… on Track. Whether you feel motivated or not.";

        private const string EmptyScreenFirstBulletPointText = "Create your emergency fund";
        private const string EmptyScreenSecondBulletPointText = "Budget your monthly expenses";
        private const string EmptyScreenThirdBulletPointText = "Power your personal goals";
        private const string EmptyScreenFourthBulletPointText = "Save for $$$ items";

        [FindsBy(How = How.XPath, Using = AddSavingTrackButtonXPath)]
        private IWebElement _addSavingTrackButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//li[1]")]
        private IWebElement _emptyScreenFirstBulletPoint;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//li[4]")]
        private IWebElement _emptyScreenFourthBulletPoint;

        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement _emptyScreenHeadline;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//p")]
        private IWebElement _emptyScreenMessage;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//li[2]")]
        private IWebElement _emptyScreenSecondBulletPoint;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'vim-empty-screen-card__content')]//li[3]")]
        private IWebElement _emptyScreenThirdBulletPoint;

        [FindsBy(How = How.XPath, Using = FundYourTracksButtonXPath)]
        private IWebElement _fundYourTracksButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Get Started')]")]
        private IWebElement _getStartedButton;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-page-header__title']//h1[contains(text(),'Save')]")]
        private IWebElement _saveHeader;

        [FindsBy(How = How.XPath, Using = UnlockSavingsTracksButtonXPath)]
        private IWebElement _unlockSavingsTracksButton;

        public SaveMainScreen(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Add Saving Track' button")]
        public SaveMainScreen ClickAddSavingTrackButton()
        {
            Wait.Until(ElementToBeClickable(_addSavingTrackButton));
            _addSavingTrackButton.Click();
            return this;
        }

        [AllureStep("Click 'Get Started' button")]
        public SaveMainScreen ClickGetStartedButton()
        {
            Wait.Until(ElementToBeClickable(_getStartedButton));
            _getStartedButton.Click();
            return this;
        }

        [AllureStep("Click 'Unlock Savings Tracks' button")]
        public SaveMainScreen ClickUnlockSavingsTracksButton()
        {
            Wait.Until(ElementToBeClickable(_unlockSavingsTracksButton));
            _unlockSavingsTracksButton.Click();
            return this;
        }

        [AllureStep("Verify if '{0}' track exists")]
        public SaveMainScreen VerifyIfTrackExists(string trackName)
        {
            VerifyIfTrackIsVisible(trackName);
            return this;
        }

        [AllureStep("Verify if '{0}' track exists")]
        public SaveMainScreen
            VerifyIfTrackExists(TrackType trackType)
        {
            VerifyIfTrackIsVisible(TrackTypeToString(trackType));
            return this;
        }

        [AllureStep("Verify if '{0}' track exists with ${1} target amount")]
        public SaveMainScreen VerifyIfTrackExists(string trackName, string trackTargetAmount)
        {
            VerifyIfTrackIsVisible(trackName);
            VerifyIfTargetAmountIsVisible(trackName, trackTargetAmount);
            VerifyIfProgressBarIsVisible(trackName);
            return this;
        }

        [AllureStep("Click '{0}' Track")]
        public SaveMainScreen ClickTrack(TrackType trackType)
        {
            var trackTypeSelector = "//label[contains(text(),'" + TrackTypeToString(trackType) + "')]//parent::div";
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(trackTypeSelector))).Click();
            return this;
        }

        [AllureStep("Click '{0}' Track")]
        public SaveMainScreen ClickTrack(string trackName)
        {
            var trackItemSelector = By.XPath("//h3[contains(text(),'" + trackName + "')]");
            Wait.Until(ExpectedConditions.ElementIsVisible(trackItemSelector)).Click();
            return this;
        }

        [AllureStep("Check Save Main screen before onboarding")]
        public SaveMainScreen CheckSaveMainScreenBeforeOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_saveHeader));
                Wait.Until(ElementToBeVisible(_emptyScreenHeadline));
                Wait.Until(ElementToBeVisible(_emptyScreenMessage));
                Wait.Until(ElementToBeVisible(_emptyScreenFirstBulletPoint));
                Wait.Until(ElementToBeVisible(_emptyScreenSecondBulletPoint));
                Wait.Until(ElementToBeVisible(_emptyScreenThirdBulletPoint));
                Wait.Until(ElementToBeVisible(_emptyScreenFourthBulletPoint));
                Wait.Until(ElementToBeVisible(_unlockSavingsTracksButton));

                IsElementNotVisibleByXpath(FundYourTracksButtonXPath, Driver).Should().BeTrue();
                IsElementNotVisibleByXpath(AddSavingTrackButtonXPath, Driver).Should().BeTrue();

                _emptyScreenHeadline.Text.Should().Contain(EmptyScreenHeadlineText);
                _emptyScreenMessage.Text.Should().Contain(EmptyScreenMessageTextPartOne);
                _emptyScreenMessage.Text.Should().Contain(EmptyScreenMessageTextPartTwo);
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

        [AllureStep("Check Save Main screen after onboarding")]
        public SaveMainScreen CheckSaveMainScreenAfterOnboarding()
        {
            try
            {
                Wait.Until(ElementToBeVisible(_saveHeader));
                Wait.Until(ElementToBeVisible(_fundYourTracksButton));
                Wait.Until(ElementToBeVisible(_addSavingTrackButton));

                IsElementNotVisibleByXpath(UnlockSavingsTracksButtonXPath, Driver).Should().BeTrue();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }

        private static string TrackTypeToString(TrackType trackType)
        {
            var trackTypeString = Enum.GetName(typeof(TrackType), trackType);
            return string.Concat(trackTypeString.Select(x => char.IsUpper(x) ? " " + x : x.ToString()))
                .TrimStart(' ');
        }

        private static void VerifyIfProgressBarIsVisible(string trackName)
        {
            var progressBarSelector =
                By.XPath("//h3[contains(text(),'" + trackName + "')]//following-sibling::div");
            Wait.Until(ExpectedConditions.ElementIsVisible(progressBarSelector));
        }

        private static void VerifyIfTargetAmountIsVisible(string trackName, string trackTargetAmount)
        {
            var expectedTrackAmount = "$0 of $" + trackTargetAmount;
            var trackTargetAmountSelector =
                By.XPath("//h3[contains(text(),'" + trackName + "')]//following-sibling::p");

            Wait.Until(ExpectedConditions.ElementIsVisible(trackTargetAmountSelector));
            var actualTrackAmount = Driver.FindElement(trackTargetAmountSelector).Text;
            actualTrackAmount.Should().Be(expectedTrackAmount);
        }

        private static void VerifyIfTrackIsVisible(string trackName)
        {
            var trackItemSelector = By.XPath("//h3[contains(text(),'" + trackName + "')]");
            Wait.Until(ExpectedConditions.ElementIsVisible(trackItemSelector));
        }
    }
}