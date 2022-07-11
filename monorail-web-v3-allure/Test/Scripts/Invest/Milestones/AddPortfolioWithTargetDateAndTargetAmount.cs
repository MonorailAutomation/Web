using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Modals.TransactionModals;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Enums;
using monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.DataGenerator.StringGenerator;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Invest.Portfolios
{
    [TestFixture]
    [AllureNUnit]
    internal class AddPortfolioWithTargetDateAndTargetAmount : FunctionalTesting
    {
        [Test(Description = "Add a Portfolio with Target Date and Target Amount")]
        [AllureEpic("Invest")]
        [AllureFeature("Portfolios")]
        [AllureStory("Add a Portfolio")]
        public void AddPortfolioWithTargetDateAndTargetAmountTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var portfolioMainScreen = new PortfoliosMainScreen(Driver);
            var chooseAPortfolioModal = new ChooseAPortfolioModal(Driver);
            var portfolioItemDetailsModal = new PortfolioItemDetailsModal(Driver);
            var portfolioModal = new PortfolioModelModal(Driver);
            var portfolioDepositScheduleModal = new DepositScheduleModal(Driver);
            var addPortfolioSuccessModal = new AddPortfolioSuccessModal(Driver);

            const string username = "autotests.mono+1.1.071122@gmail.com";
            const string portfolioDescription = "Test Portfolio Description";
            const string portfolioTargetDate = "10242023";
            const string portfolioTargetAmount = "4,500";

            var portfolioName = "Test Portfolio " + GenerateStringWithNumber();

            VerifyPlaidConnection(username);

            loginPage
                .PassCredentials(username, ValidPassword)
                .ClickSignInButton();

            mainScreen
                .CheckMainScreen()
                .ClickInvest();

            investScreen
                .CheckInvestScreen()
                .ClickPortfolios();

            portfolioMainScreen.ClickAddAPortfolioButton();

            chooseAPortfolioModal
                .CheckChooseAPortfolioModal()
                .ClickPortfolioType(PortfolioType.CollegeFund);

            portfolioItemDetailsModal
                .CheckPortfolioDetailsModal()
                .SetPortfolioTargetAmount(portfolioTargetAmount)
                .SetPortfolioTargetDate(portfolioTargetDate)
                .SetItemName(portfolioName)
                .SetItemDescription(portfolioDescription)
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

            portfolioMainScreen.VerifyIfPortfolioExists(portfolioName, portfolioTargetAmount);
        }
    }
}