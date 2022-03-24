using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Commons.NumberGenerator;
using static monorail_web_v3.RestRequests.Helpers.UserOnboardingHelperFunctions;
using static monorail_web_v3.RestRequests.Helpers.WishlistHelperFunctions;
using static monorail_web_v3.Test.Scripts.Transactions.ConnectPlaidToNewUser;

namespace monorail_web_v3.Test.Scripts.Wishlist
{
    [TestFixture]
    [AllureNUnit]
    internal class WishlistOnboarding : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+22.071221";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Wishlist Onboarding - using 'Create a Wishlist' button")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Onboarding")]
        [AllureStory("Wishlist Onboarding - using 'Create a Wishlist' button")]
        public void WishlistOnboardingUsingCreateAWishlistButtonTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding()
                .ClickCreateAWishlistAccountButton();

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

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding();
        }

        [Test(Description =
            "Wishlist Onboarding - through Wishlist Item Details screen by clicking 'Fund your Wishlist' button")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Onboarding")]
        [AllureStory(
            "Wishlist Onboarding - through Wishlist Item Details screen by clicking 'Fund your Wishlist' button")]
        public void WishlistOnboardingByClickingCreateAWishlistButtonAfterAddingWishlistItemTest()
        {
            const string wishlistItemUrl =
                "https://www.amazon.com/Sceptre-E248W-19203R-Monitor-Speakers-Metallic/dp/B0773ZY26F/ref=lp_16225007011_1_4";
            const string wishlistItemName = "Sceptre 24\" Professional";
        
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistDetailsScreen = new WishlistDetailsScreen(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var wishlistAddCashModal = new WishlistAddCashModal(Driver);

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;
            
            RegisterUser(username);
            AddPersonalizedWishlistItem(username, ValidPassword, WishlistItemUrl, WishlistItemName, 
                WishlistItemDescription, WishlistItemPrice, WishlistItemImage, WishlistItemFavicon);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding();

            wishlistMainScreen
                .ClickWishlistItem(WishlistItemName);

            wishlistDetailsScreen
                .ClickFundYourWishlistButton();
            
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

            wishlistAddCashModal
                .CheckWishlistAddCashModal();
        }
    }
}