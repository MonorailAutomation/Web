using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.DataGenerator.NumberGenerator;
using static monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Enums.TrackType;
using static monorail_web_v3.RestRequests.Helpers.UserManagementHelperFunctions;
using static monorail_web_v3.Test.Scripts.Transactions.ConnectPlaidToNewUser;
using static monorail_web_v3.RestRequests.Helpers.UserOnboardingHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Money.Save
{
    [TestFixture]
    [AllureNUnit]
    internal class Q2SaveOnboarding : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+25.201221";
        private const string UsernameSuffix = "@monorail.com";

        [Test(Description = "Q2 Save Onboarding - no track selected")]
        [AllureEpic("Money")]
        [AllureFeature("Save")]
        [AllureStory("Q2 Save Onboarding - no track selected")]
        public void Q2SaveOnboardingNoTrackSelectedTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var saveMainScreen = new SaveMainScreen(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);
            var chooseATrackModal = new ChooseATrackModal(Driver);
            var trackItemDetailsModal = new TrackItemDetailsModal(Driver);
            var depositScheduleModal = new DepositScheduleModal(Driver);
            var addTrackSuccessModal = new AddTrackSuccessModal(Driver);

            var username = UsernamePrefix + GenerateRandomDigits(3) + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickMoney();

            moneyScreen
                .CheckMoneyScreen()
                .ClickSave();

            saveMainScreen
                .CheckSaveMainScreenBeforeOnboarding()
                .ClickUnlockSavingsTracksButton();

            completeYourAccountModal
                .CheckCompleteYourAccountModal()
                .ClickGetStartedButton();

            completeYourProfileModal
                .CheckCompleteYourProfileModal()
                .SetFirstName(ValidFirstName)
                .SetLastName(ValidLastName)
                .SetAddressLine1(ValidAddressLine1)
                .SetCity(ValidCity)
                .SetState(ValidState)
                .SetZip(ValidZip)
                .SetSsn(ValidSsn)
                .ClickConfirmButton();

            regulatoryInformationPoliticallyExposedQuestionModal
                .CheckRegulatoryInformationPoliticallyExposedQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButton();

            linkYourAccountModal
                .CheckConnectYourBankAccountModal()
                .ClickConnectYourBankAccountButton();

            ConnectPlaid();

            electronicDeliveryConsentModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeButton();

            termsAndConditionsModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeButton();

            saveMainScreen
                .ClickGetStartedButton();

            chooseATrackModal
                .CheckChooseATrackModal()
                .ClickTrackType(Holidays);

            trackItemDetailsModal
                .ClickContinueButton();

            depositScheduleModal
                .CheckDepositScheduleModal("Weekly")
                //.DisableDepositSchedule()
                .ClickContinueButton();

            addTrackSuccessModal
                .CheckSuccessModal()
                .ClickFinishButton();

            saveMainScreen
                .CheckSaveMainScreenAfterOnboarding()
                .VerifyIfTrackExists(Holidays);

            CloseUser(username);
        }

        [Test(Description = "Q2 Save Onboarding - single track")]
        [AllureEpic("Money")]
        [AllureFeature("Save")]
        [AllureStory("Q2 Save Onboarding - single track")]
        public void Q2SaveOnboardingSingleTrackTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var saveMainScreen = new SaveMainScreen(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);

            var username = UsernamePrefix + GenerateRandomDigits(3) + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickMoney();

            moneyScreen
                .CheckMoneyScreen()
                .ClickSave();

            saveMainScreen
                .CheckSaveMainScreenBeforeOnboarding()
                .ClickUnlockSavingsTracksButton();

            completeYourAccountModal
                .CheckCompleteYourAccountModal()
                .ClickGetStartedButton();

            completeYourProfileModal
                .CheckCompleteYourProfileModal()
                .SetFirstName(ValidFirstName)
                .SetLastName(ValidLastName)
                .SetAddressLine1(ValidAddressLine1)
                .SetCity(ValidCity)
                .SetState(ValidState)
                .SetZip(ValidZip)
                .SetSsn(ValidSsn)
                .ClickConfirmButton();

            regulatoryInformationPoliticallyExposedQuestionModal
                .CheckRegulatoryInformationPoliticallyExposedQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButton();

            linkYourAccountModal
                .CheckConnectYourBankAccountModal()
                .ClickConnectYourBankAccountButton();

            ConnectPlaid();

            electronicDeliveryConsentModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeButton();

            termsAndConditionsModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeButton();

            saveMainScreen
                .ClickTrack(Travel)
                .ClickGetStartedButton();

            saveMainScreen
                .CheckSaveMainScreenAfterOnboarding()
                .VerifyIfTrackExists(Travel);

            CloseUser(username);
        }

        [Test(Description = "Q2 Save Onboarding - multiple tracks")]
        [AllureEpic("Money")]
        [AllureFeature("Save")]
        [AllureStory("Q2 Save Onboarding - multiple tracks")]
        public void Q2SaveOnboardingMultipleTracksTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var saveMainScreen = new SaveMainScreen(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);

            var username = UsernamePrefix + GenerateRandomDigits(3) + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickMoney();

            moneyScreen
                .CheckMoneyScreen()
                .ClickSave();

            saveMainScreen
                .ClickUnlockSavingsTracksButton();

            completeYourAccountModal
                .CheckCompleteYourAccountModal()
                .ClickGetStartedButton();

            completeYourProfileModal
                .CheckCompleteYourProfileModal()
                .SetFirstName(ValidFirstName)
                .SetLastName(ValidLastName)
                .SetAddressLine1(ValidAddressLine1)
                .SetCity(ValidCity)
                .SetState(ValidState)
                .SetZip(ValidZip)
                .SetSsn(ValidSsn)
                .ClickConfirmButton();

            regulatoryInformationPoliticallyExposedQuestionModal
                .CheckRegulatoryInformationPoliticallyExposedQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButton();

            linkYourAccountModal
                .CheckConnectYourBankAccountModal()
                .ClickConnectYourBankAccountButton();

            ConnectPlaid();

            electronicDeliveryConsentModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeButton();

            termsAndConditionsModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeButton();

            saveMainScreen
                .ClickTrack(Savings)
                .ClickTrack(Emergency)
                .ClickTrack(Travel)
                .ClickTrack(Bills)
                .ClickTrack(Food)
                .ClickTrack(Gas)
                .ClickTrack(BigPurchase)
                .ClickTrack(Holidays)
                .ClickTrack(Debt)
                .ClickGetStartedButton();

            Thread.Sleep(20000);

            saveMainScreen
                .CheckSaveMainScreenAfterOnboarding()
                .VerifyIfTrackExists(Savings)
                .VerifyIfTrackExists(Emergency)
                .VerifyIfTrackExists(Travel)
                .VerifyIfTrackExists(Bills)
                .VerifyIfTrackExists(Food)
                .VerifyIfTrackExists(Gas)
                .VerifyIfTrackExists(BigPurchase)
                .VerifyIfTrackExists(Holidays)
                .VerifyIfTrackExists(Debt);

            CloseUser(username);
        }
    }
}