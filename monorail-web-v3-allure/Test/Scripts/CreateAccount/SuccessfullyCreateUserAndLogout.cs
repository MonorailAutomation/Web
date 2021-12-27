using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.CreateAccountModals;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.RandomGenerator;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Database.VerificationCode;

namespace monorail_web_v3.Test.Scripts.CreateAccount
{
    [TestFixture]
    [AllureNUnit]
    public class SuccessfullyCreateUserAndLogout : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+20.061121";
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
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var mainScreen = new MainScreen(Driver);
            var sideMenu = new SideMenu(Driver);

            const string verificationCode = "111111";

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(ValidDateOfBirthDmy)
                .SetPhoneNumber(ValidPhoneNumber)
                .ClickContinueButton();

            verifyYourAccountChooseMethodModal
                .CheckVerifyYourAccountChooseMethodModal()
                .ClickTextMessageOption()
                .ClickContinueButton();

            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal();

            //Thread.Sleep(4500); // comment below

            verifyYourAccountVerificationCodeModal
                //.EnterVerificationCode(GetVerificationCode(username)) // needs to be fixed by Dev. VC doesn't arrive, you need to hit 'Resend' to receive it
                .EnterVerificationCode(verificationCode)
                .ClickContinueButton();

            termsAndConditionsModal
                .CheckTermsAndConditionsModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            mainScreen
                .CheckMainScreen()
                .ExpandSideMenu();

            sideMenu
                .ClickLogOutLink();
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

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(ValidDateOfBirthDmy)
                .SetPhoneNumber(ValidPhoneNumber)
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

            sideMenu
                .ClickLogOutLink();
        }
    }
}