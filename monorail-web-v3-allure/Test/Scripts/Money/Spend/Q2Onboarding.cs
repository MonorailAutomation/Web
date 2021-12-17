using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals;
using monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Commons.RandomGenerator;
using static monorail_web_v3.Test.Scripts.Transactions.ConnectPlaidToNewUser;
using static monorail_web_v3.RestRequests.Helpers.UserOnboardingHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Money.Spend
{
    [TestFixture]
    [AllureNUnit]
    internal class Q2Onboarding : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+23.091221";
        private const string UsernameSuffix = "@gmail.com";
        
        [Test(Description = "Q2 Spending Onboarding")]
        [AllureEpic("Money")]
        [AllureFeature("Spend")]
        [AllureStory("Q2 Checking Onboarding")]
        public void Q2SpendOnboardingTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var spendMainScreen = new SpendMainScreen(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationModal = new RegulatoryInformationModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);
            var spendOnboardingSuccessModal = new SpendOnboardingSuccessModal(Driver);

            const string firstName = "Auto";
            const string lastName = "Test";
            const string addressLine1 = "3322 Bee Ridge Rd";
            const string city = "Sarasota";
            const string state = "FL";
            const string zip = "34239";
            const string ssn = "666-00-3785";

            
            //const string username = "autotests.mono+23.091221665@gmail.com";

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            RegisterUser(username);
            
            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickMoney();

            moneyScreen
                .CheckMoneyScreen()
                .ClickSpend();

            spendMainScreen
                .CheckSpendScreenBeforeOnboarding()
                .ClickOpenYourCheckingAccountButton();
            
            completeYourAccountModal
                .CheckCompleteYourAccountModal()
                .ClickGetStartedButton();

            completeYourProfileModal
                .SetFirstName(firstName)
                .SetLastName(lastName)
                .SetAddressLine1(addressLine1)
                .SetCity(city)
                .SetState(state)
                .SetZip(zip)
                .SetSsn(ssn)
                .ClickConfirmButton();

            regulatoryInformationModal
                .ClickNopeAnswer()
                .ClickContinueButton();

            Thread.Sleep(7500); // TO DO: Change to verify Link your account modal

            linkYourAccountModal
                .ClickLinkYourAccountButton();

            ConnectPlaid();

            termsAndConditionsModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            electronicDeliveryConsentModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            spendOnboardingSuccessModal
                .CheckSpendOnboardingSuccessModal()
                .ClickFinish();
        }
    }
}