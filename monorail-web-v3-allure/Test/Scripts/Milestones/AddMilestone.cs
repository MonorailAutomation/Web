using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace monorail_web_v3.Test.Scripts.Milestones
{
    [TestFixture]
    [AllureNUnit]
    internal class AddMilestone : FunctionalTesting
    {
        private const string Username = "mp.1.042021@vimvest.com";
        private const string Password = "Test123!!";
        private const string MilestoneName = "Test Milestone ABC1";
        private const string MilestoneDescription = "Test Milestone Description";
        private const string MilestoneTargetDate = "24/10/2022";
        private const string MilestoneTargetAmount = "2500";

        [Test(Description = "Add a Milestone")]
        [AllureEpic("Invest")]
        [AllureFeature("Milestones")]
        [AllureStory("Add a Milestone")]
        public void AddAMilestoneTest()
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

            loginPage
                .PassCredentials(Username, Password)
                .ClickSignInButton();

            mainHeader
                .ClickInvest();

            investMenu.ClickMilestones();

            milestonesMainScreen.ClickAddAMilestoneButton();

            chooseAMilestoneModal.ClickMilestoneType(MilestoneType.College_Fund);

            milestoneDetailsModal.SetMilestoneName(MilestoneName)
                .SetMilestoneDescription(MilestoneDescription)
                .SetMilestoneTargetAmount(MilestoneTargetAmount)
                .SetMilestoneTargetDate(MilestoneTargetDate)
                .ClickContinueButton();

            portfolioModal.ClickContinueButton();

            depositScheduleModal.ClickContinueButton();

            successModal.ClickFinishButton();

            Driver.Navigate().Refresh();

            milestonesMainScreen.VerifyIfMilestoneExists(MilestoneName);
        }
    }
}