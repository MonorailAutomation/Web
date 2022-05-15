using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.CreateAccountModals;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.DataGenerator.EmailGenerator;
using static monorail_web_v3.RestRequests.Helpers.UserManagementHelperFunctions;

namespace monorail_web_v3.Test.Scripts.CreateAccount
{
    [TestFixture]
    [AllureNUnit]
    public class UnsuccessfulUserCreation : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+20.";
        private const string UsernameSuffix = "@gmail.com";

        private const string ExpectedEmailUsedValidationMessage = "Already Used";
        private const string ExpectedUserUnder18ValidationMessage = "Must be at least 18 years old.";
        private const string ExpectedUserOver120ValidationMessage = "Can't be older than 120 years.";

        [Test(Description = "Create user with existing email")]
        [AllureEpic("Create user")]
        [AllureFeature("Registration failed")]
        [AllureStory("Create user with existing email")]
        public void CreateUserWithExistingEmailTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);

            const string username = "autotests.mono+40.131021@gmail.com";

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(ValidDateOfBirthMDY)
                .SetPhoneNumber("9419252125")
                .ClickContinueButton();

            gettingStartedModal
                .VerifyIfCorrectValidationMessageIsDisplayed(ExpectedEmailUsedValidationMessage);
        }

        [Test(Description = "Create user under 18 years old")]
        [AllureEpic("Create user")]
        [AllureFeature("Registration failed")]
        [AllureStory("Create user under 18 years old")]
        public void CreateUserUnder18Test()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(DateOfBirthUnder18MDY)
                .SetPhoneNumber("9419252125")
                .ClickContinueButton();

            gettingStartedModal
                .VerifyIfCorrectValidationMessageIsDisplayed(ExpectedUserUnder18ValidationMessage);
        }

        [Test(Description = "Create user over 120 years old")]
        [AllureEpic("Create user")]
        [AllureFeature("Registration failed")]
        [AllureStory("Create user over 120 years old")]
        public void CreateUserOver120Test()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(DateOfBirthOver120MDY)
                .SetPhoneNumber("9419252125")
                .ClickContinueButton();

            gettingStartedModal
                .VerifyIfCorrectValidationMessageIsDisplayed(ExpectedUserOver120ValidationMessage);
        }

        [Test(Description = "Create user using incorrect email verification code")]
        [AllureEpic("Create user")]
        [AllureFeature("Registration failed")]
        [AllureStory("Create user using incorrect email verification code")]
        public void CreateUserIncorrectEmailVerificationCodeTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);
            var verifyYourAccountChooseMethodModal = new VerifyYourAccountChooseMethodModal(Driver);
            var verifyYourAccountVerificationCodeModal = new VerifyYourAccountVerificationCodeModal(Driver);

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

            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal()
                .EnterVerificationCode("123456")
                .ClickContinueButton();

            verifyYourAccountVerificationCodeModal
                .VerifyIfIncorrectVerificationCodeMessageIsDisplayed();

            CloseUser(username);
        }

        [Test(Description = "Create user using incorrect sms verification code")]
        [AllureEpic("Create user")]
        [AllureFeature("Registration failed")]
        [AllureStory("Create user using incorrect sms verification code")]
        public void CreateUserIncorrectSmsVerificationCodeTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);
            var verifyYourAccountChooseMethodModal = new VerifyYourAccountChooseMethodModal(Driver);
            var verifyYourAccountVerificationCodeModal = new VerifyYourAccountVerificationCodeModal(Driver);

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth(ValidDateOfBirthMDY)
                .SetPhoneNumber("9419252126")
                .ClickContinueButton();

            verifyYourAccountChooseMethodModal
                .CheckVerifyYourAccountChooseMethodModal()
                .ClickTextMessageOption()
                .ClickContinueButton();

            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal()
                .EnterVerificationCode("123456")
                .ClickContinueButton();

            verifyYourAccountVerificationCodeModal
                .VerifyIfIncorrectVerificationCodeMessageIsDisplayed();

            CloseUser(username);
        }
    }
}