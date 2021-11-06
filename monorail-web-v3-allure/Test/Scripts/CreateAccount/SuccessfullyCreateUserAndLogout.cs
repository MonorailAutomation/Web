using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.CreateAccountModals;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.RandomGenerator;
using static monorail_web_v3.Commons.Passwords;
using static monorail_web_v3.Database.VerificationCode;

namespace monorail_web_v3.Test.Scripts.CreateAccount
{
    [TestFixture]
    [AllureNUnit]
    public class SuccessfullyCreateUserAndLogout : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+20.061121";
        private const string UsernameSuffix = "@gmail.com";
        private const string DateOfBirth = "01/01/1990";
        private const string PhoneNumber = "9419252121";
        
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
            var termsOfUseModal = new TermsOfUseModal(Driver);
            var advisorsPrivacyPolicyModal = new AdvisorsPrivacyPolicyModal(Driver);
            var sideMenu = new SideMenu(Driver);
            
            const string verificationCode = "111111";
            
            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            loginPage
                .ClickCreateAnAccountButton();
            
            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(DateOfBirth)
                .SetPhoneNumber(PhoneNumber)
                .ClickContinueButton();
            
            verifyYourAccountChooseMethodModal
                .CheckVerifyYourAccountChooseMethodModal()
                .ClickTextMessageOption()
                .ClickContinueButton();
            
            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal();
            
            //Thread.Sleep(2000); // comment below

            verifyYourAccountVerificationCodeModal
                //.EnterVerificationCode(GetVerificationCode(username)) // needs to be fixed by Dev. VC doesn't arrive, you need to hit 'Resend' to receive it
                .EnterVerificationCode(verificationCode)
                .ClickContinueButton();
            
            termsOfUseModal
                .CheckTermsOfUseModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndContinueButton();
            
            advisorsPrivacyPolicyModal
                .CheckAdvisorsPrivacyPolicyModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();
            
            sideMenu
                .ExpandSideMenu()
                .Logout();
        }
        
        [Test(Description = "Create user with email verification")]
        [AllureEpic("Create user")]
        [AllureFeature("Successfully create user")]
        [AllureStory("Create user with email verification")]
        public void CreateUserWithEmailVerificationTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);
            var verifyYourAccountChooseMethodModal = new VerifyYourAccountChooseMethodModal(Driver);
            var verifyYourAccountVerificationCodeModal = new VerifyYourAccountVerificationCodeModal(Driver);
            var termsOfUseModal = new TermsOfUseModal(Driver);
            var advisorsPrivacyPolicyModal = new AdvisorsPrivacyPolicyModal(Driver);
            var sideMenu = new SideMenu(Driver);
            
            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;

            loginPage
                .ClickCreateAnAccountButton();
            
            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(DateOfBirth)
                .SetPhoneNumber(PhoneNumber)
                .ClickContinueButton();
            
            verifyYourAccountChooseMethodModal
                .CheckVerifyYourAccountChooseMethodModal()
                .ClickEmailOption()
                .ClickContinueButton();
            
            Thread.Sleep(2000); //waiting for results in DB
            
            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal()
                .EnterVerificationCode(GetVerificationCode(username))
                .ClickContinueButton();
            
            termsOfUseModal
                .CheckTermsOfUseModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndContinueButton();
            
            advisorsPrivacyPolicyModal
                .CheckAdvisorsPrivacyPolicyModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();
            
            sideMenu
                .ExpandSideMenu()
                .Logout();
        }
    }
}