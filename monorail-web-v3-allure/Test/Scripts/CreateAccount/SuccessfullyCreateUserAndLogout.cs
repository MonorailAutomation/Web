using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.CreateAccountModals;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.DataGenerator.EmailGenerator;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Database.VerificationCode;
using static monorail_web_v3.RestRequests.Helpers.UserManagementHelperFunctions;

namespace monorail_web_v3.Test.Scripts.CreateAccount
{
    [TestFixture]
    [AllureNUnit]
    public class SuccessfullyCreateUserAndLogout : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+20.";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Create user with text message verification")]
        [AllureEpic("Create user")]
        [AllureFeature("Successfully create user")]
        [AllureStory("Create user with text message verification")]
        public void CreateUserWithTextMessageVerificationTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);
            var verifyYourAccountChooseMethodModal = new VerifyYourAccountChooseMethodModal(Driver);
            var verifyYourAccountVerificationCodeModal = new VerifyYourAccountVerificationCodeModal(Driver);
            var termsAndConditions = new TermsAndConditionsModal(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(ValidDateOfBirthMDY)
                .SetPhoneNumber("9419252125")
                .ClickContinueButton();

            verifyYourAccountChooseMethodModal
                .CheckVerifyYourAccountChooseMethodModal()
                .ClickTextMessageOption()
                .ClickContinueButton();

            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal();

            Thread.Sleep(5500); // waiting for results in DB

            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal()
                .EnterVerificationCode(GetVerificationCode(username))
                .ClickContinueButton();

            termsAndConditions
                .CheckTermsAndConditionsModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            mainScreen
                .CheckMainScreen()
                .ExpandSideMenu();

            Thread.Sleep(5000);

            sideMenu
                .ClickLogOutLink();

            CloseUser(username);
        }

        [Test(Description = "Create user with email verification")]
        [AllureEpic("Create user")]
        [AllureFeature("Successfully create user")]
        [AllureStory("Create user with email verification")]
        public static void CreateUserWithEmailVerificationTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);
            var verifyYourAccountChooseMethodModal = new VerifyYourAccountChooseMethodModal(Driver);
            var verifyYourAccountVerificationCodeModal = new VerifyYourAccountVerificationCodeModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(ValidDateOfBirthMDY)
                .SetPhoneNumber("9419252125")
                .ClickContinueButton();

            verifyYourAccountChooseMethodModal
                .CheckVerifyYourAccountChooseMethodModal()
                .ClickEmailOption()
                .ClickContinueButton();

            Thread.Sleep(4500); //waiting for results in DB

            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal()
                .EnterVerificationCode(GetVerificationCode(username))
                .ClickContinueButton();

            termsAndConditionsModal
                .CheckTermsAndConditionsModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            mainScreen
                .CheckMainScreen()
                .ExpandSideMenu();

            Thread.Sleep(5000);

            sideMenu
                .ClickLogOutLink();

            CloseUser(username);
        }
    }
}