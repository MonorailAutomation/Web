using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Enums;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Modals;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.DataGenerator.StringGenerator;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Money.Save
{
    [TestFixture]
    [AllureNUnit]
    internal class AddAnotherSavingTrack : FunctionalTesting
    {
        [Test(Description = "Add another Saving Track")]
        [AllureEpic("Money")]
        [AllureFeature("Save")]
        [AllureStory("Add another Saving Track")]
        public void AddAnotherSavingTrackTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var moneyScreen = new MoneyScreen(Driver);
            var tracksMainScreen = new SaveMainScreen(Driver);
            var chooseATrackModal = new ChooseATrackModal(Driver);
            var trackDetailsModal = new TrackItemDetailsModal(Driver);
            var trackDepositScheduleModal = new TrackDepositScheduleModal(Driver);
            var addTrackSuccessModal = new AddTrackSuccessModal(Driver);

            const string username = "autotests.mono+2.2.181021@gmail.com";
            const string trackDescription = "Test Track Description";
            const string trackTargetDate = "04192029";
            const string trackTargetAmount = "6,900";

            var trackName = "Test Track " + GenerateStringWithNumber();

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickMoney();

            moneyScreen
                .CheckMoneyScreen()
                .ClickSave();

            tracksMainScreen
                .ClickAddSavingTrackButton();

            chooseATrackModal
                .CheckChooseATrackModal()
                .ClickTrackType(TrackType.Debt);

            trackDetailsModal
                .CheckTrackDetailsModal()
                .SetTrackIcon(TrackIcon.Paw)
                .SetTrackMainColor(TrackColor.Turquoise)
                .SetTrackTargetAmount(trackTargetAmount)
                .SetTrackTargetDate(trackTargetDate)
                .SetItemName(trackName)
                .SetItemDescription(trackDescription)
                .ClickContinueButton();

            trackDepositScheduleModal
                .CheckDepositScheduleModal("Weekly")
                .ClickContinueButton();

            addTrackSuccessModal
                .CheckSuccessModal()
                .VerifyNameOfCreatedTrack(trackName)
                .ClickFinishButton();

            tracksMainScreen.VerifyIfTrackExists(trackName, trackTargetAmount);
        }
    }
}