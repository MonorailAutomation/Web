using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals;
using monorail_web_v3.PageObjects.Commons.Modals.TransactionModals;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.DataGenerator.EmailGenerator;
using static monorail_web_v3.DataGenerator.StringGenerator;
using static monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Enums.PortfolioType;
using static monorail_web_v3.RestRequests.Helpers.UserManagementHelperFunctions;
using static monorail_web_v3.Test.Scripts.Transactions.Plaid.ConnectPlaidToNewUser;
using static monorail_web_v3.RestRequests.Helpers.UserOnboardingHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Invest.Portfolios
{
    [TestFixture]
    [AllureNUnit]
    internal class PortfolioOnboardingForUserOver55Yo : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+24.";
        private const string UsernameSuffix = "@gmail.com";

        private const string PortfolioDescription = "Test Portfolio Description";
        private const string PortfolioTargetDate = "10242023";
        private const string PortfolioTargetAmount = "4,500";

        [Test(Description = "Portfolio Onboarding (Apex) - by clicking 'Add a Portfolio' button; with Trusted Contact")]
        [AllureEpic("Invest")]
        [AllureFeature("Portfolios")]
        [AllureStory("Portfolio Onboarding (Apex) - by clicking 'Add a Portfolio' button; with Trusted Contact")]
        public void PortfolioOnboardingByClickingAddAPortfolioButtonWithTrustedContactTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var portfoliosMainScreen = new PortfoliosMainScreen(Driver);
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
            var chooseAPortfolioModal = new ChooseAPortfolioModal(Driver);
            var portfolioItemDetailsModal = new PortfolioItemDetailsModal(Driver);
            var portfolioModal = new PortfolioModelModal(Driver);
            var portfolioDepositScheduleModal = new DepositScheduleModal(Driver);
            var addPortfolioSuccessModal = new AddPortfolioSuccessModal(Driver);

            var portfolioName = "Test Portfolio " + GenerateStringWithNumber();

            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            const string dateOfBirth = "1966-01-01";

            RegisterUserWithDoB(username, dateOfBirth);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickPortfolios();

            portfoliosMainScreen.ClickAddAPortfolioButton();

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
                .SetFirstName(ValidFirstName)
                .SetLastName(ValidLastName)
                .SetEmail(ValidEmail)
                .SetAddressLine1(ValidAddressLine1)
                .SetCity(ValidCity)
                .SetState(ValidState)
                .SetZip(ValidZip)
                .SetPhoneNumber(ValidPhoneNumber)
                .ClickConfirmButton();

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

            chooseAPortfolioModal
                .CheckChooseAPortfolioModal()
                .ClickPortfolioType(CollegeFund);

            portfolioItemDetailsModal
                .CheckPortfolioDetailsModal()
                .SetPortfolioTargetAmount(PortfolioTargetAmount)
                .SetPortfolioTargetDate(PortfolioTargetDate)
                .SetItemName(portfolioName)
                .SetItemDescription(PortfolioDescription)
                .ClickContinueButton();

            portfolioModal
                .CheckPortfolioModelModal()
                .ClickContinueButton();

            portfolioDepositScheduleModal
                .CheckDepositScheduleModal("Weekly")
                .ClickContinueButton();

            addPortfolioSuccessModal
                .CheckSuccessModal()
                .ClickFinishButton();

            Driver.Navigate().Refresh();

            portfoliosMainScreen.VerifyIfPortfolioExists(portfolioName, PortfolioTargetAmount);

            CloseUser(username);
        }

        [Test(Description = "Portfolio Onboarding (Apex) - by clicking '+' placeholder; with Trusted Contact")]
        [AllureEpic("Invest")]
        [AllureFeature("Portfolios")]
        [AllureStory("Portfolio Onboarding (Apex) - by clicking '+' placeholder; with Trusted Contact")]
        public void PortfolioOnboardingByClickingPlaceholderWithTrustedContactTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var portfoliosMainScreen = new PortfoliosMainScreen(Driver);
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
            var chooseAPortfolioModal = new ChooseAPortfolioModal(Driver);
            var portfolioItemDetailsModal = new PortfolioItemDetailsModal(Driver);
            var portfolioModal = new PortfolioModelModal(Driver);
            var portfolioDepositScheduleModal = new DepositScheduleModal(Driver);
            var addPortfolioSuccessModal = new AddPortfolioSuccessModal(Driver);

            var portfolioName = "Test Portfolio " + GenerateStringWithNumber();
            var username = GenerateNewEmail(UsernamePrefix, UsernameSuffix);

            const string dateOfBirth = "1966-01-01";

            RegisterUserWithDoB(username, dateOfBirth);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickPortfolios();

            portfoliosMainScreen.ClickAddAPortfolioButton();

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
                .SetFirstName(ValidFirstName)
                .SetLastName(ValidLastName)
                .SetEmail(ValidEmail)
                .SetAddressLine1(ValidAddressLine1)
                .SetCity(ValidCity)
                .SetState(ValidState)
                .SetZip(ValidZip)
                .SetPhoneNumber(ValidPhoneNumber)
                .ClickConfirmButton();

            Thread.Sleep(5000);

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

            chooseAPortfolioModal
                .CheckChooseAPortfolioModal()
                .ClickPortfolioType(CollegeFund);

            portfolioItemDetailsModal
                .CheckPortfolioDetailsModal()
                .SetPortfolioTargetAmount(PortfolioTargetAmount)
                .SetPortfolioTargetDate(PortfolioTargetDate)
                .SetItemName(portfolioName)
                .SetItemDescription(PortfolioDescription)
                .ClickContinueButton();

            portfolioModal
                .CheckPortfolioModelModal()
                .ClickContinueButton();

            portfolioDepositScheduleModal
                .CheckDepositScheduleModal("Weekly")
                .ClickContinueButton();

            addPortfolioSuccessModal
                .CheckSuccessModal()
                .ClickFinishButton();

            Driver.Navigate().Refresh();

            portfoliosMainScreen.VerifyIfPortfolioExists(portfolioName, PortfolioTargetAmount);

            CloseUser(username);
        }
    }
}