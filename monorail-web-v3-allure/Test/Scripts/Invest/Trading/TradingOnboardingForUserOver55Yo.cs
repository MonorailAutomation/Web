using System;
using System.Threading;
using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Modals;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.CreateAccountModals;
using monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.Commons.RandomGenerator;
using static monorail_web_v3.Test.Scripts.Transactions.ConnectPlaidToNewUser;
using static monorail_web_v3.Database.VerificationCode;
using static monorail_web_v3.RestRequests.PilotFeature;
using TermsAndConditionsModal = monorail_web_v3.PageObjects.CreateAccountModals.TermsAndConditionsModal;

namespace monorail_web_v3.Test.Scripts.Invest.Trading
{
    [TestFixture]
    [AllureNUnit]
    internal class TradingOnboardingForUserOver55Yo : FunctionalTesting
    {
        private const string UsernamePrefix = "autotests.mono+26.201221";
        private const string UsernameSuffix = "@gmail.com";

        [Test(Description = "Trading Onboarding (Orbis) - by clicking 'Start Trading Stocks' button; >55 yo")]
        [AllureEpic("Invest")]
        [AllureFeature("Trading")]
        [AllureStory("Trading Onboarding (Orbis) - by clicking 'Start Trading Stocks' button; >55 yo")]
        public void TradingOnboardingByClickingStartTradingStocksButtonForUserOver55YoTest()
        {
            var loginPage = new LoginPage(Driver);
            var gettingStartedModal = new GettingStartedModal(Driver);
            var verifyYourAccountChooseMethodModal = new VerifyYourAccountChooseMethodModal(Driver);
            var verifyYourAccountVerificationCodeModal = new VerifyYourAccountVerificationCodeModal(Driver);
            var termsAndConditionsModal = new TermsAndConditionsModal(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var tradingMainScreen = new TradingMainScreen(Driver);
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

            var username = UsernamePrefix + GenerateRandomNumber() + UsernameSuffix;
            var phoneNumber = "940" + GenerateRandomNumber() + GenerateRandom4Digits();

            Console.WriteLine(username);

            loginPage
                .ClickCreateAnAccountButton();

            gettingStartedModal
                .CheckGettingStartedModal()
                .SetEmail(username)
                .SetPassword(ValidPassword)
                .SetDateOfBirth("01-01-1966")
                .SetPhoneNumber(phoneNumber)
                .ClickContinueButton();

            verifyYourAccountChooseMethodModal
                .CheckVerifyYourAccountChooseMethodModal()
                .ClickEmailOption()
                .ClickContinueButton();

            Thread.Sleep(4500); //waiting for results in DB

            verifyYourAccountVerificationCodeModal
                .CheckYourAccountVerificationCodeModal()
                .EnterVerificationCode(GetVerificationCode(username))
                .ClickContinueButton();

            termsAndConditionsModal
                .CheckTermsAndConditionsModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            PostPilotFeatures(username, "useOrbis");

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickTrading();

            tradingMainScreen
                .CheckTradingMainScreenBeforeOnboarding()
                .ClickStartTradingStocksButton();

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
                .CheckAddATrustedContactOver55YoModal()
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
                .CheckLinkYourAccountModal()
                .ClickLinkYourAccountButton();

            ConnectPlaid();

            Thread.Sleep(5000);

            disclosuresModal
                .CheckDisclosuresModal()
                .ClickSkipToBottomButton()
                .ClickAgreeAndContinueButton()
                .CheckDisclosuresModal()
                .ClickSkipToBottomButton()
                .CheckDisclosuresModal()
                .ClickAgreeAndContinueButton()
                .ClickSkipToBottomButton()
                .ClickAgreeAndFinishButton();

            tradingMainScreen
                .CheckTradingMainScreenAfterOnboarding();
        }
    }
}