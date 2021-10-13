using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.RandomGenerator;

namespace monorail_web_v3.Test.Scripts.Invest.Milestones
{
    [TestFixture]
    [AllureNUnit]
    internal class AddMilestoneWithTargetDateAndTargetAmount : FunctionalTesting
    {
        private const string Username = "autotests.mono+1.1.131021@gmail.com";
        private const string Password = "Test123!!";
        private const string MilestoneDescription = "Test Milestone Description";
        private const string MilestoneTargetDate = "24/10/2023";
        private const string MilestoneTargetAmount = "4,500";

        [Test(Description = "Add a Milestone with Target Date and Target Amount")]
        [AllureEpic("Invest")]
        [AllureFeature("Milestones")]
        [AllureStory("Add a Milestone")]
        public void AddMilestoneWithTargetDateAndTargetAmountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainHeader = new MainHeader(Driver);
            var investMenu = new InvestMenu(Driver);
            var milestonesMainScreen = new MilestonesMainScreen(Driver);
            var chooseAMilestoneModal = new ChooseAMilestoneModal(Driver);
            var milestoneDetailsModal = new MilestoneDetailsModal(Driver);
            var portfolioModal = new PortfolioModal(Driver);
            var depositScheduleModal = new DepositScheduleModal(Driver);
            var successModal = new SuccessModal(Driver);

            var milestoneName = "Test Milestone " + GenerateRandomString();

            loginPage
                .PassCredentials(Username, Password)
                .ClickSignInButton();

            mainHeader
                .ClickInvest();

            investMenu.ClickMilestones();

            milestonesMainScreen.ClickAddAMilestoneButton();

            chooseAMilestoneModal.ClickMilestoneType(MilestoneType.CollegeFund);

            milestoneDetailsModal.SetMilestoneName(milestoneName)
                .SetMilestoneDescription(MilestoneDescription)
                .SetMilestoneTargetAmount(MilestoneTargetAmount)
                .SetMilestoneTargetDate(MilestoneTargetDate)
                .ClickContinueButton();

            portfolioModal.ClickContinueButton();

            depositScheduleModal.ClickContinueButton();

            successModal.ClickFinishButton();

            Driver.Navigate().Refresh();

            milestonesMainScreen.VerifyIfMilestoneExists(milestoneName, MilestoneTargetAmount);
        }
    }
}