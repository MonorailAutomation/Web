using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.RestRequests.Helpers.MilestoneHelperFunctions;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Invest.Milestones
{
    [TestFixture, AllureNUnit]
    internal class EditMilestoneWithoutScheduledDeposits : FunctionalTesting
    {
        [Test(Description = "Edit a Milestone - change name, description")]
        [AllureEpic("Invest")]
        [AllureFeature("Milestones")]
        [AllureStory("Edit a Milestone - change name, description")]
        public void EditMilestoneNameDescriptionTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var milestonesMainScreen = new MilestonesMainScreen(Driver);
            var milestoneDetailsModal = new MilestoneItemDetailsModal(Driver);
            var milestoneDetailsScreen = new MilestoneDetailsScreen(Driver);

            const string username = "autotests.mono+4.1.131021@gmail.com";
            const string milestoneId = "35206f40-e104-444b-b4b2-ee61e97ded85";

            const string originalMilestoneName = "Original Milestone Name";
            const string originalMilestoneDescription = "Original Milestone Description";

            const string changedMilestoneName = "Changed Milestone Name";
            const string changedMilestoneDescription = "Changed Milestone Description";

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickMilestones();

            milestonesMainScreen.ClickMilestone(originalMilestoneName);

            milestoneDetailsScreen
                .ClickEditDetailsButton();

            milestoneDetailsModal
                .CheckMilestoneDetailsModal()
                .SetItemName(changedMilestoneName)
                .SetItemDescription(changedMilestoneDescription)
                .ClickContinueButton();

            milestoneDetailsScreen
                .VerifyMilestoneDetails(changedMilestoneName, changedMilestoneDescription);

            RevertMilestone(username, milestoneId, originalMilestoneName, originalMilestoneDescription);
        }
    }
}