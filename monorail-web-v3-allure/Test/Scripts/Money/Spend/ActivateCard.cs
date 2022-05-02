using System;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Modals;
using monorail_web_v3.PageObjects.MoneyScreens.SpendScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Database.RetrieveUser;
using static monorail_web_v3.RestRequests.Helpers.UserManagementHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Money.Spend
{
    [TestFixture]
    [AllureNUnit]
    internal class ActivateCard : FunctionalTesting
    {
        [Test(Description = "Activate Card")]
        [AllureEpic("Money")]
        [AllureFeature("Spend")]
        [AllureStory("Activate Card")]
        public void ActivateCardTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var spendMainScreen = new SpendMainScreen(Driver);
            var activateYourCardLastDigitsModal = new ActivateYourCardLastDigitsModal(Driver);
            var activateYourCardBirthdayModal = new ActivateYourCardBirthdayModal(Driver);
            var activateYourCardCreatePinModal = new ActivateYourCardCreatePinModal(Driver);
            var activateYourCardConfirmPinModal = new ActivateYourCardConfirmPinModal(Driver);
            var activateYourCardSuccessModal = new ActivateYourCardSuccessModal(Driver);

            const string pinCode = "1234";
            const string last4DigitsOnCard = "1111";
            const string userPrefix = "autotests.mono+23.020522%";

            var username = GetUserAfterQ2SpendOnboardingWithoutCard(userPrefix);
            Console.WriteLine(username);

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
                .CheckSpendScreenAfterOnboardingBeforeCardActivation()
                .ClickActivateCardButton();

            activateYourCardLastDigitsModal
                .CheckActivateYourCardLastDigitsModal()
                .EnterLast4NumbersOnCard(last4DigitsOnCard)
                .ClickContinueButton();

            activateYourCardBirthdayModal
                .CheckActivateYourCardBirthdayModal()
                .EnterBirthday(ValidDateOfBirthMDY)
                .ClickContinueButton();

            activateYourCardCreatePinModal
                .CheckActivateYourCardCreatePinModal()
                .EnterPin(pinCode)
                .ClickContinueButton();

            activateYourCardConfirmPinModal
                .CheckActivateYourCardConfirmPinModal()
                .EnterPin(pinCode)
                .ClickContinueButton();

            activateYourCardSuccessModal
                .CheckActivateYourCardSuccessModal()
                .ClickFinish();

            spendMainScreen
                .CheckSpendScreenAfterOnboardingAfterCardActivation();

            DeleteUser(username);
        }
    }
}