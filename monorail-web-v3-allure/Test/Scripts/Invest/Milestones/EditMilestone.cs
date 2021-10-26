using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Screens;
using monorail_web_v3.PageObjects.Menus;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.RestRequests.Helpers.MilestoneHelperFunctions;
using static monorail_web_v3.Commons.Passwords;

namespace monorail_web_v3.Test.Scripts.Invest.Milestones
{
    [TestFixture]
    [AllureNUnit]
    internal class EditMilestoneWithoutScheduledDeposits : FunctionalTesting
    {
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

            const string username = "autotests.mono+4.1.131021@gmail.com";
            const string milestoneId = "bb9e454c-38f9-4b5e-860c-97f86a7d0c6c";

            const string originalMilestoneName = "Original Milestone Name";
            const string originalMilestoneDescription = "Original Milestone Description";
            const string originalMilestoneTargetAmount = "967";
            const string originalMilestoneTargetDate = "08/10/2025";

            const string changedMilestoneName = "Changed Milestone Name";
            const string changedMilestoneDescription = "Changed Milestone Description";
            const string changedMilestoneTargetAmount = "5,292";
            const string changedMilestoneTargetDate = "06/12/2026";

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainHeader
                .ClickInvest();

            investMenu.ClickMilestones();

            milestonesMainScreen.ClickMilestone(originalMilestoneName);

            milestoneDetailsScreen
                .ClickEditDetailsButton();

            milestoneDetailsModal
                .CheckMilestoneDetailsModal()
                .SetMilestoneName(changedMilestoneName)
                .SetMilestoneDescription(changedMilestoneDescription)
                .SetMilestoneTargetAmount(changedMilestoneTargetAmount)
                .SetMilestoneTargetDate(changedMilestoneTargetDate)
                .ClickContinueButton();

            milestoneDetailsScreen
                .VerifyMilestoneDetails(changedMilestoneName, changedMilestoneDescription,
                    changedMilestoneTargetAmount);

            // milestoneDetailsScreen.ClickEditDetailsButton();
            // milestoneDetailsModal.VerifyTargetDate(changedMilestoneTargetDate);

            RevertMilestone(username, ValidPassword, milestoneId, originalMilestoneName,
                originalMilestoneDescription, originalMilestoneTargetAmount, originalMilestoneTargetDate);
        }
    }
}