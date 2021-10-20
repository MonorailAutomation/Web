using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.RestRequests.Helpers.MilestoneHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Invest.Milestones
{
    [TestFixture]
    [AllureNUnit]
    internal class EditMilestoneWithoutScheduledDeposits : FunctionalTesting
    {
        private const string Username = "autotests.mono+4.1.131021@gmail.com";
        private const string Password = "Test123!!";
        private const string MilestoneId = "bb9e454c-38f9-4b5e-860c-97f86a7d0c6c";

        private const string OriginalMilestoneName = "Original Milestone Name";
        private const string OriginalMilestoneDescription = "Original Milestone Description";
        private const string OriginalMilestoneTargetAmount = "967";
        private const string OriginalMilestoneTargetDate = "08/10/2025";

        private const string ChangedMilestoneName = "Changed Milestone Name";
        private const string ChangedMilestoneDescription = "Changed Milestone Description";
        private const string ChangedMilestoneTargetAmount = "5,292";
        private const string ChangedMilestoneTargetDate = "06/12/2026";
        
        [Test(Description =
            "Edit a Milestone - change name, description, target amount, target date but without scheduled deposit")]
        [AllureEpic("Invest")]
        [AllureFeature("Milestones")]
        [AllureStory("Edit a Milestone - change name, description, amount, date")]
        public void EditMilestoneNameDescriptionAmountDateTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainHeader = new MainHeader(Driver);
            var investMenu = new InvestMenu(Driver);
            var milestonesMainScreen = new MilestonesMainScreen(Driver);
            var milestoneDetailsModal = new MilestoneDetailsModal(Driver);
            var milestoneDetailsScreen = new MilestoneDetailsScreen(Driver);

            loginPage
                .PassCredentials(Username, Password)
                .ClickSignInButton();

            mainHeader
                .ClickInvest();

            investMenu.ClickMilestones();

            milestonesMainScreen.ClickMilestone(OriginalMilestoneName);

            milestoneDetailsScreen.ClickEditDetailsButton();

            milestoneDetailsModal.SetMilestoneName(ChangedMilestoneName)
                .SetMilestoneDescription(ChangedMilestoneDescription)
                .SetMilestoneTargetAmount(ChangedMilestoneTargetAmount)
                .SetMilestoneTargetDate(ChangedMilestoneTargetDate)
                .ClickContinueButton();

            milestoneDetailsScreen.VerifyMilestoneDetails(ChangedMilestoneName, ChangedMilestoneDescription,
                ChangedMilestoneTargetAmount);

            //milestoneDetailsScreen.ClickEditDetailsButton();
            //milestoneDetailsModal.VerifyTargetDate(ChangedMilestoneTargetDate);
            
            RevertMilestone(Username, Password, MilestoneId, OriginalMilestoneName,
                OriginalMilestoneDescription, OriginalMilestoneTargetAmount, OriginalMilestoneTargetDate);
        }
    }
}