using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Enums;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.RandomGenerator;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Invest.Milestones
{
    [TestFixture]
    [AllureNUnit]
    internal class AddMilestoneWithTargetDateAndTargetAmount : FunctionalTesting
    {
        [Test(Description = "Add a Milestone with Target Date and Target Amount")]
        [AllureEpic("Invest")]
        [AllureFeature("Milestones")]
        [AllureStory("Add a Milestone")]
        public void AddMilestoneWithTargetDateAndTargetAmountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var milestonesMainScreen = new MilestonesMainScreen(Driver);
            var chooseAMilestoneModal = new ChooseAMilestoneModal(Driver);
            var milestoneItemDetailsModal = new MilestoneItemDetailsModal(Driver);
            var portfolioModal = new PortfolioModal(Driver);
            var milestoneDepositScheduleModal = new MilestoneDepositScheduleModal(Driver);
            var addMilestoneSuccessModal = new AddMilestoneSuccessModal(Driver);

            const string username = "autotests.mono+1.1.131021@gmail.com";
            const string milestoneDescription = "Test Milestone Description";
            const string milestoneTargetDate = "24/10/2023";
            const string milestoneTargetAmount = "4,500";

            var milestoneName = "Test Milestone " + GenerateRandomString();

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickMilestones();

            Thread.Sleep(10000); //temporary workaround until issue 31578 solved

            milestonesMainScreen.ClickAddAMilestoneButton();

            chooseAMilestoneModal
                .CheckChooseAMilestoneModal()
                .ClickMilestoneType(MilestoneType.CollegeFund);

            milestoneItemDetailsModal
                .CheckMilestoneDetailsModal()
                .SetMilestoneTargetAmount(milestoneTargetAmount)
                .SetMilestoneTargetDate(milestoneTargetDate)
                .SetItemName(milestoneName)
                .SetItemDescription(milestoneDescription)
                .ClickContinueButton();

            portfolioModal
                .CheckPortfolioModal()
                .ClickContinueButton();

            milestoneDepositScheduleModal
                .CheckDepositScheduleModal()
                .ClickContinueButton();

            addMilestoneSuccessModal
                .CheckSuccessModal()
                .ClickFinishButton();

            Driver.Navigate().Refresh();

            milestonesMainScreen.VerifyIfMilestoneExists(milestoneName, milestoneTargetAmount);
        }
    }
}