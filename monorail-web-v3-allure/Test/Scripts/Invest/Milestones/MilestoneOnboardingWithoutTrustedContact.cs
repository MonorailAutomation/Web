using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.DataGenerator.EmailGenerator;
using static monorail_web_v3.DataGenerator.StringGenerator;
using static monorail_web_v3.PageObjects.InvestScreens.MilestonesScreen.Enums.MilestoneType;
using static monorail_web_v3.RestRequests.Helpers.UserManagementHelperFunctions;
using static monorail_web_v3.Test.Scripts.Transactions.ConnectPlaidToNewUser;
using static monorail_web_v3.RestRequests.Helpers.UserOnboardingHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Invest.Milestones
{
    [TestFixture]
    [AllureNUnit]
    internal class MilestoneOnboardingForUserUnder55Yo : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+24.";
        private const string UsernameSuffix = "@gmail.com";

        private const string MilestoneDescription = "Test Milestone Description";
        private const string MilestoneTargetDate = "10242023";
        private const string MilestoneTargetAmount = "4,500";

        [Test(Description =
            "Milestone Onboarding (Apex) - by clicking 'Add a Milestone' button; without Trusted Contact")]
        [AllureEpic("Invest")]
        [AllureFeature("Milestones")]
        [AllureStory("Milestone Onboarding (Apex) - by clicking 'Add a Milestone' button; without Trusted Contact")]
        public void MilestoneOnboardingByClickingAddAMilestoneButtonWithoutTrustedContactTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var milestonesMainScreen = new MilestonesMainScreen(Driver);
            //
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var addATrustedContactModal = new AddATrustedContactModal(Driver);
            var employmentInformationModal = new EmploymentInformationModal(Driver);
            var riskProfileMarketLossQuestionModal = new RiskProfileMarketLossQuestionModal(Driver);
            var riskProfileStockMarketQuestionModal = new RiskProfileStockMarketQuestionModal(Driver);
            var riskProfileInvestingExperienceQuestion = new RiskProfileInvestingExperienceQuestion(Driver);
            var riskProfileEarningsQuestionModal = new RiskProfileEarningsQuestionModal(Driver);
            var riskProfileNetWorthQuestionModal = new RiskProfileNetWorthQuestionModal(Driver);
            var riskProfileLiquidQuestionModal = new RiskProfileLiquidQuestionModal(Driver);
            var regulatoryInformationShareholderQuestionModal =
                new RegulatoryInformationShareholderQuestionModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var regulatoryInformationBrokerageAffiliationQuestionModal =
                new RegulatoryInformationBrokerageAffiliationQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var disclosuresModal = new DisclosuresModal(Driver);
            //
            var chooseAMilestoneModal = new ChooseAMilestoneModal(Driver);
            var milestoneItemDetailsModal = new MilestoneItemDetailsModal(Driver);
            var portfolioModal = new PortfolioModal(Driver);
            var milestoneDepositScheduleModal = new MilestoneDepositScheduleModal(Driver);
            var addMilestoneSuccessModal = new AddMilestoneSuccessModal(Driver);

            var milestoneName = "Test Milestone " + GenerateStringWithNumber();

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickMilestones();

            milestonesMainScreen.ClickAddAMilestoneButton();

            /* Apex Onboarding flow */

            completeYourAccountModal
                .CheckCompleteYourAccountModal()
                .ClickGetStartedButton();

            completeYourProfileModal
                .CheckCompleteYourProfileModal()
                .SetFirstName(ValidFirstName)
                .SetLastName(ValidLastName)
                .SetAddressLine1(ValidAddressLine1)
                .SetCity(ValidCity)
                .SetState(ValidState)
                .SetZip(ValidZip)
                .SetSsn(ValidSsn)
                .ClickConfirmButton();

            addATrustedContactModal
                .CheckAddATrustedContactModal()
                .ClickIDontWantToAddATrustedContactModal();

            employmentInformationModal
                .CheckEmploymentInformationModal()
                .ClickUnemployedAnswer()
                .ClickContinueButtonInSpan();

            riskProfileMarketLossQuestionModal
                .CheckRiskProfileLossQuestionModal()
                .ClickPerfectTimeToBuyAnswer()
                .ClickContinueButtonInSpan();

            riskProfileStockMarketQuestionModal
                .CheckRiskProfileStockMarketQuestionModal()
                .ClickYesIDoAnswer()
                .ClickContinueButtonInSpan();

            riskProfileInvestingExperienceQuestion
                .CheckRiskProfileInvestingExperienceQuestionModal()
                .ClickPeopleCallMeAProAnswer()
                .ClickContinueButtonInSpan();

            riskProfileEarningsQuestionModal
                .CheckRiskProfileEarningsQuestionModal()
                .ClickOver100K()
                .ClickContinueButtonInSpan();

            riskProfileNetWorthQuestionModal
                .CheckRiskProfileNetWorthQuestionModal()
                .ClickOver100K()
                .ClickContinueButtonInSpan();

            riskProfileLiquidQuestionModal
                .CheckRiskProfileLiquidQuestionModal()
                .ClickOver100K()
                .ClickContinueButtonInSpan();

            regulatoryInformationShareholderQuestionModal
                .CheckRegulatoryInformationShareholderQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButtonInSpan();

            regulatoryInformationPoliticallyExposedQuestionModal
                .CheckRegulatoryInformationPoliticallyExposedQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButtonInSpan();

            regulatoryInformationBrokerageAffiliationQuestionModal
                .CheckRegulatoryInformationBrokerageAffiliationQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButtonInSpan();

            linkYourAccountModal
                .CheckConnectYourBankAccountModal()
                .ClickConnectYourBankAccountButton();

            ConnectPlaid();

            disclosuresModal
                .CheckDisclosuresModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            chooseAMilestoneModal
                .CheckChooseAMilestoneModal()
                .ClickMilestoneType(CollegeFund);

            milestoneItemDetailsModal
                .CheckMilestoneDetailsModal()
                .SetMilestoneTargetAmount(MilestoneTargetAmount)
                .SetMilestoneTargetDate(MilestoneTargetDate)
                .SetItemName(milestoneName)
                .SetItemDescription(MilestoneDescription)
                .ClickContinueButton();

            portfolioModal
                .CheckPortfolioModal()
                .ClickContinueButton();

            milestoneDepositScheduleModal
                .CheckDepositScheduleModal("Weekly")
                .ClickContinueButton();

            addMilestoneSuccessModal
                .CheckSuccessModal()
                .ClickFinishButton();

            Driver.Navigate().Refresh();

            milestonesMainScreen.VerifyIfMilestoneExists(milestoneName, MilestoneTargetAmount);

            CloseUser(username);
        }

        [Test(Description = "Milestone Onboarding (Apex) - by clicking '+' placeholder; without Trusted Contact")]
        [AllureEpic("Invest")]
        [AllureFeature("Milestones")]
        [AllureStory("Milestone Onboarding (Apex) - by clicking '+' placeholder; without Trusted Contact")]
        public void MilestoneOnboardingByClickingPlaceholderWithoutTrustedContactTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var milestonesMainScreen = new MilestonesMainScreen(Driver);
            //
            var completeYourAccountModal = new CompleteYourAccountModal(Driver);
            var completeYourProfileModal = new CompleteYourProfileModal(Driver);
            var addATrustedContactModal = new AddATrustedContactModal(Driver);
            var employmentInformationModal = new EmploymentInformationModal(Driver);
            var riskProfileMarketLossQuestionModal = new RiskProfileMarketLossQuestionModal(Driver);
            var riskProfileStockMarketQuestionModal = new RiskProfileStockMarketQuestionModal(Driver);
            var riskProfileInvestingExperienceQuestion = new RiskProfileInvestingExperienceQuestion(Driver);
            var riskProfileEarningsQuestionModal = new RiskProfileEarningsQuestionModal(Driver);
            var riskProfileNetWorthQuestionModal = new RiskProfileNetWorthQuestionModal(Driver);
            var riskProfileLiquidQuestionModal = new RiskProfileLiquidQuestionModal(Driver);
            var regulatoryInformationShareholderQuestionModal =
                new RegulatoryInformationShareholderQuestionModal(Driver);
            var regulatoryInformationPoliticallyExposedQuestionModal =
                new RegulatoryInformationPoliticallyExposedQuestionModal(Driver);
            var regulatoryInformationBrokerageAffiliationQuestionModal =
                new RegulatoryInformationBrokerageAffiliationQuestionModal(Driver);
            var linkYourAccountModal = new LinkYourAccountModal(Driver);
            var disclosuresModal = new DisclosuresModal(Driver);
            //
            var chooseAMilestoneModal = new ChooseAMilestoneModal(Driver);
            var milestoneItemDetailsModal = new MilestoneItemDetailsModal(Driver);
            var portfolioModal = new PortfolioModal(Driver);
            var milestoneDepositScheduleModal = new MilestoneDepositScheduleModal(Driver);
            var addMilestoneSuccessModal = new AddMilestoneSuccessModal(Driver);

            var milestoneName = "Test Milestone " + GenerateStringWithNumber();

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            RegisterUser(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickMilestones();

            milestonesMainScreen.ClickPlaceholderCard();

            /* Apex Onboarding flow */

            completeYourAccountModal
                .CheckCompleteYourAccountModal()
                .ClickGetStartedButton();

            completeYourProfileModal
                .CheckCompleteYourProfileModal()
                .SetFirstName(ValidFirstName)
                .SetLastName(ValidLastName)
                .SetAddressLine1(ValidAddressLine1)
                .SetCity(ValidCity)
                .SetState(ValidState)
                .SetZip(ValidZip)
                .SetSsn(ValidSsn)
                .ClickConfirmButton();

            addATrustedContactModal
                .CheckAddATrustedContactModal()
                .ClickIDontWantToAddATrustedContactModal();

            employmentInformationModal
                .CheckEmploymentInformationModal()
                .ClickUnemployedAnswer()
                .ClickContinueButtonInSpan();

            riskProfileMarketLossQuestionModal
                .CheckRiskProfileLossQuestionModal()
                .ClickPerfectTimeToBuyAnswer()
                .ClickContinueButtonInSpan();

            riskProfileStockMarketQuestionModal
                .CheckRiskProfileStockMarketQuestionModal()
                .ClickYesIDoAnswer()
                .ClickContinueButtonInSpan();

            riskProfileInvestingExperienceQuestion
                .CheckRiskProfileInvestingExperienceQuestionModal()
                .ClickPeopleCallMeAProAnswer()
                .ClickContinueButtonInSpan();

            riskProfileEarningsQuestionModal
                .CheckRiskProfileEarningsQuestionModal()
                .ClickOver100K()
                .ClickContinueButtonInSpan();

            riskProfileNetWorthQuestionModal
                .CheckRiskProfileNetWorthQuestionModal()
                .ClickOver100K()
                .ClickContinueButtonInSpan();

            riskProfileLiquidQuestionModal
                .CheckRiskProfileLiquidQuestionModal()
                .ClickOver100K()
                .ClickContinueButtonInSpan();

            regulatoryInformationShareholderQuestionModal
                .CheckRegulatoryInformationShareholderQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButtonInSpan();

            regulatoryInformationPoliticallyExposedQuestionModal
                .CheckRegulatoryInformationPoliticallyExposedQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButtonInSpan();

            regulatoryInformationBrokerageAffiliationQuestionModal
                .CheckRegulatoryInformationBrokerageAffiliationQuestionModal()
                .ClickNopeAnswer()
                .ClickContinueButtonInSpan();

            linkYourAccountModal
                .CheckConnectYourBankAccountModal()
                .ClickConnectYourBankAccountButton();

            ConnectPlaid();

            disclosuresModal
                .CheckDisclosuresModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            chooseAMilestoneModal
                .CheckChooseAMilestoneModal()
                .ClickMilestoneType(CollegeFund);

            milestoneItemDetailsModal
                .CheckMilestoneDetailsModal()
                .SetMilestoneTargetAmount(MilestoneTargetAmount)
                .SetMilestoneTargetDate(MilestoneTargetDate)
                .SetItemName(milestoneName)
                .SetItemDescription(MilestoneDescription)
                .ClickContinueButton();

            portfolioModal
                .CheckPortfolioModal()
                .ClickContinueButton();

            milestoneDepositScheduleModal
                .CheckDepositScheduleModal("Weekly")
                .ClickContinueButton();

            addMilestoneSuccessModal
                .CheckSuccessModal()
                .ClickFinishButton();

            Driver.Navigate().Refresh();

            milestonesMainScreen.VerifyIfMilestoneExists(milestoneName, MilestoneTargetAmount);

            CloseUser(username);
        }
    }
}