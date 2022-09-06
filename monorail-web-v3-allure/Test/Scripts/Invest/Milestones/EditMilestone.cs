using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Modals;
using monorail_web_v3.PageObjects.InvestScreens.PortfoliosScreen.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.RestRequests.Helpers.PortfolioHelperFunctions;
using static monorail_web_v3.Commons.Constants;
using static monorail_web_v3.RestRequests.Helpers.PlaidConnectionHelperFunctions;

namespace monorail_web_v3.Test.Scripts.Invest.Portfolios
{
    [TestFixture]
    [AllureNUnit]
    internal class EditPortfolioWithoutScheduledDeposits : FunctionalTesting
    {
        [Test(Description = "Edit a Portfolio - change name, description")]
        [AllureEpic("Invest")]
        [AllureFeature("Portfolios")]
        [AllureStory("Edit a Portfolio - change name, description")]
        public void EditPortfolioNameDescriptionTest()
        {
            var loginPage = new LoginPage(Driver);
            var mainScreen = new MainScreen(Driver);
            var investScreen = new InvestScreen(Driver);
            var portfoliosMainScreen = new PortfoliosMainScreen(Driver);
            var portfolioDetailsModal = new PortfolioItemDetailsModal(Driver);
            var portfolioDetailsScreen = new PortfolioDetailsScreen(Driver);

            const string username = "autotests.mono+4.1.131021@gmail.com";
            const string portfolioId = "35206f40-e104-444b-b4b2-ee61e97ded85";

            const string originalPortfolioName = "Original Portfolio Name";
           
            const string changedPortfolioName = "Changed Portfolio Name";

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

            portfoliosMainScreen.ClickPortfolio(originalPortfolioName);

            portfolioDetailsScreen
                .ClickRenameAccountButton();

            portfolioDetailsModal
                .CheckPortfolioDetailsModal()
                .SetItemName(changedPortfolioName)
                .ClickContinueButton();

            portfolioDetailsScreen
                .VerifyPortfolioDetails(changedPortfolioName);

            RevertPortfolio(username, portfolioId, originalPortfolioName);
        }
    }
}