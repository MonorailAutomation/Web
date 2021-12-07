using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Commons.RandomGenerator;
using static monorail_web_v3.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_web_v3.Test.Scripts.Transactions.ConnectPlaidToNewUser;

namespace monorail_web_v3.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class WishlistOnboarding : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+22.071221";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Wishlist Onboarding - first account onboarding")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Onboarding")]
        [AllureStory("Wishlist Onboarding - first account onboarding")]
        public void WishlistOnboardingTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationModal = new RegulatoryInformationModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);

            const string firstName = "Auto";
            const string lastName = "Test";
            const string addressLine1 = "3322 Bee Ridge Rd";
            const string city = "Sarasota";
            const string state = "FL";
            const string zip = "34239";
            const string ssn = "666-00-3785";

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen // to do: add verify screen before onboarding
                .ClickCreateAWishlistAccountButton();

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

            Thread.Sleep(5000); // TO DO: Change to verify Link your account modal

            linkYourAccountModal
                .ClickLinkYourAccountButton();

            ConnectPlaid();

            termsAndConditionsModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            electronicDeliveryConsentModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            Thread.Sleep(5000); // TO DO: change to verify 'wishlist screen' after onboarding
        }
    }
}