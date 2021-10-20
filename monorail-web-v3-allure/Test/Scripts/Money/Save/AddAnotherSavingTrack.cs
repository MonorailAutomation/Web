using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Menus;
using monorail_web_v3.PageObjects.MoneyScreens.SaveScreen;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.RandomGenerator;

namespace monorail_web_v3.Test.Scripts.Money.Save
{
    [TestFixture]
    [AllureNUnit]
    internal class AddAnotherSavingTrack : FunctionalTesting
    {
        private const string Password = "Test123!!";

        [Test(Description = "Add another Saving Track")]
        [AllureEpic("Money")]
        [AllureFeature("Save")]
        [AllureStory("Add another Saving Track")]
        public void AddAnotherSavingTrackTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainHeader = new MainHeader(Driver);
            var moneyMenu = new MoneyMenu(Driver);
            var tracksMainScreen = new TracksMainScreen(Driver);
            var chooseATrackModal = new ChooseATrackModal(Driver);
            var trackDetailsModal = new TrackDetailsModal(Driver);
            var trackDepositScheduleModal = new TrackDepositScheduleModal(Driver);
            var addTrackSuccessModal = new AddTrackSuccessModal(Driver);

            const string username = "autotests.mono+2.2.181021@gmail.com";
            const string trackDescription = "Test Track Description";
            const string trackTargetDate = "19/04/2029";
            const string trackTargetAmount = "6900";

            var trackName = "Test Track " + GenerateRandomString();

            loginPage
                .PassCredentials(username, Password)
                .ClickSignInButton();

            mainHeader
                .ClickMoney();

            moneyMenu
                .ClickSave();

            tracksMainScreen
                .ClickAddSavingTrackButton();

            chooseATrackModal
                .ClickMilestoneType(TrackType.Debt);

            trackDetailsModal
                .SetTrackIcon(TrackIcon.Paw)
                .SetTrackMainColor(TrackColor.Turquoise)
                .SetTrackName(trackName)
                .SetTrackDescription(trackDescription)
                .SetTrackTargetAmount(trackTargetAmount)
                .SetTrackTargetDate(trackTargetDate)
                .ClickContinueButton();

            trackDepositScheduleModal
                .ClickContinueButton();

            addTrackSuccessModal
                .VerifyNameOfCreatedTrack(trackName)
                .ClickFinishButton();

            Driver.Navigate().Refresh();

            tracksMainScreen.VerifyIfTrackExists(trackName, trackTargetAmount);
        }
    }
}