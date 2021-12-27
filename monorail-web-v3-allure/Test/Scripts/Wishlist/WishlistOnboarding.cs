using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
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
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);

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
                .CheckLinkYourAccountModal()
                .ClickLinkYourAccountButton();

            ConnectPlaid();

            termsAndConditionsModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            electronicDeliveryConsentModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding();
        }

        [Test(Description =
            "Wishlist Onboarding - add Wishlist Item and click 'Open Wishlist Account' on 'Finish' modal")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Onboarding")]
        [AllureStory("Wishlist Onboarding - add Wishlist Item and click 'Open Wishlist Account' on 'Finish' modal")]
        public void WishlistOnboardingWithAddingWishlistItemTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var addWishlistItemFinishModal = new AddWishlistItemSuccessModal(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding()
                .ClickAddWishlistItemButton();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl)
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickConfirmButton();

            addWishlistItemFinishModal
                .CheckAddWishlistItemSuccessModalBeforeOnboarding()
                .VerifyWishlistItemName(WishlistItemName)
                .ClickOpenWishlistAccountButton();

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
                .CheckLinkYourAccountModal()
                .ClickLinkYourAccountButton();

            ConnectPlaid();

            termsAndConditionsModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            electronicDeliveryConsentModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding();
        }

        [Test(Description = "Wishlist Onboarding - add Wishlist Item, leave and then click 'Create a Wishlist'")]
        [AllureEpic("Wishlist")]
        [AllureFeature("Onboarding")]
        [AllureStory("Wishlist Onboarding - add Wishlist Item, leave and then click 'Create a Wishlist'")]
        public void WishlistOnboardingByClickingCreateAWishlistButtonAfterAddingWishlistItemTest()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var addNewWishlistItemModal = new AddNewWishlistItemModal(Driver);
            var wishlistItemDetailsModal = new WishlistItemDetailsModal(Driver);
            var addWishlistItemFinishModal = new AddWishlistItemSuccessModal(Driver);
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var electronicDeliveryConsentModal = new ElectronicDeliveryConsentModal(Driver);

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            wishlistMainScreen
                .CheckWishlistMainScreenBeforeOnboarding()
                .ClickAddWishlistItemButton();

            addNewWishlistItemModal
                .CheckAddNewItemModal()
                .PasteLink(WishlistItemUrl)
                .ClickContinueButton();

            wishlistItemDetailsModal
                .CheckItemDetailsModal()
                .CheckLoadedDataOnItemDetailsModal(WishlistItemName, WishlistItemDescription, WishlistItemUrl)
                .SetWishlistItemPrice(WishlistItemPrice)
                .ClickConfirmButton();

            addWishlistItemFinishModal
                .CheckAddWishlistItemSuccessModalBeforeOnboarding()
                .VerifyWishlistItemName(WishlistItemName)
                .ClickFinishButton();

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
                .CheckLinkYourAccountModal()
                .ClickLinkYourAccountButton();

            ConnectPlaid();

            termsAndConditionsModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            electronicDeliveryConsentModal
                .ScrollToTheBottomOfTheDocument()
                .ClickAgreeAndFinishButton();

            wishlistMainScreen
                .CheckWishlistMainScreenAfterOnboarding();
        }
    }
}