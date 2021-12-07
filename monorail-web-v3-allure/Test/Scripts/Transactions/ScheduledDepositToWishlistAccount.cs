using monorail_web_v3.PageObjects;
using monorail_web_v3.PageObjects.Commons.Screens;
using monorail_web_v3.PageObjects.WishlistScreens.Modals;
using monorail_web_v3.PageObjects.WishlistScreens.Screens;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using static monorail_web_v3.Commons.Constants;

namespace monorail_web_v3.Test.Scripts.Transactions
{
    [TestFixture]
    [AllureNUnit]
    internal class ScheduledDepositToWishlistAccount : FunctionalTesting
    {
        private const string Username = "autotests.mono+3.1.161021@gmail.com"; // TO DO: replace with other user
        private const string DepositAmount = "20";

        [Test(Description = "Enable and disable Scheduled Deposit to Wishlist Account - daily")]
        [AllureEpic("Transactions")]
        [AllureFeature("Scheduled Deposit")]
        [AllureStory("Enable and disable Scheduled Deposit to Wishlist Account - daily")]
        public void EnableAndDisableScheduledDepositToWishlistAccountDaily()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var targetAndScheduleModal = new TargetAndScheduleModal(Driver);

            const string depositFrequency = "Daily";

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistHeader()
                .ClickManageYourAccountButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .ClickScheduledDepositSwitch()
                .ClickTargetAndScheduleButton();

            targetAndScheduleModal
                .CheckTargetAndScheduleModal()
                .ClickDailyButton()
                .SetDepositAmount(DepositAmount)
                .CheckDepositScheduleModal(depositFrequency)
                .ClickConfirmButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .VerifyIfScheduledDepositSectionHasChanged(DepositAmount, depositFrequency)
                .CheckScheduledDepositsSection(DepositAmount, depositFrequency)
                .ClickScheduledDepositSwitch();
        }

        [Test(Description = "Enable and disable Scheduled Deposit to Wishlist Account - weekly")]
        [AllureEpic("Transactions")]
        [AllureFeature("Scheduled Deposit")]
        [AllureStory("Enable and disable Scheduled Deposit to Wishlist Account - weekly")]
        public void EnableAndDisableScheduledDepositToWishlistAccountWeekly()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var targetAndScheduleModal = new TargetAndScheduleModal(Driver);

            const string depositFrequency = "Weekly";

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistHeader()
                .ClickManageYourAccountButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .ClickScheduledDepositSwitch()
                .ClickTargetAndScheduleButton();

            targetAndScheduleModal
                .CheckTargetAndScheduleModal()
                .ClickWeeklyButton()
                .SetDepositAmount(DepositAmount)
                .SetDepositDayFromDropdown("Friday")
                .CheckDepositScheduleModal(depositFrequency)
                .ClickConfirmButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .VerifyIfScheduledDepositSectionHasChanged(DepositAmount, depositFrequency)
                .CheckScheduledDepositsSection(DepositAmount, depositFrequency)
                .ClickScheduledDepositSwitch();
        }

        [Test(Description = "Enable and disable Scheduled Deposit to Wishlist Account - monthly")]
        [AllureEpic("Transactions")]
        [AllureFeature("Scheduled Deposit")]
        [AllureStory("Enable and disable Scheduled Deposit to Wishlist Account - monthly")]
        public void EnableAndDisableScheduledDepositToWishlistAccountMonthly()
        {
            var loginPage = new LoginPage(Driver);
            var wishlistScreen = new WishlistScreen(Driver);
            var wishlistMainScreen = new WishlistMainScreen(Driver);
            var wishlistManageAccountModal = new WishlistManageAccountModal(Driver);
            var targetAndScheduleModal = new TargetAndScheduleModal(Driver);

            const string depositFrequency = "Monthly";

            loginPage
                .PassCredentials(Username, ValidPassword)
                .ClickSignInButton();

            wishlistScreen
                .CheckWishlistScreen()
                .CheckMainScreen();

            wishlistMainScreen
                .CheckWishlistHeader()
                .ClickManageYourAccountButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .ClickScheduledDepositSwitch()
                .ClickTargetAndScheduleButton();

            targetAndScheduleModal
                .CheckTargetAndScheduleModal()
                .ClickMonthlyButton()
                .SetDepositAmount(DepositAmount)
                .SetDepositDayFromDropdown("Last day")
                .CheckDepositScheduleModal(depositFrequency)
                .ClickConfirmButton();

            wishlistManageAccountModal
                .CheckWishlistManageAccountModal()
                .VerifyIfScheduledDepositSectionHasChanged(DepositAmount, depositFrequency)
                .CheckScheduledDepositsSection(DepositAmount, depositFrequency)
                .ClickScheduledDepositSwitch();
        }
    }
}