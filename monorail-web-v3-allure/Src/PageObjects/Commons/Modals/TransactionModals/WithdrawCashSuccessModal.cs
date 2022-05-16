using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace monorail_web_v3.PageObjects.Commons.Modals.TransactionModals
{
    public class WithdrawCashSuccessModal : Modal
    {
        protected const string WithdrawCashSuccessHeaderText = "Success!";
        protected const string WithdrawCashSuccessMessageText = "Funds are on their way to your connected account";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        protected IWebElement SuccessHeader;

        protected WithdrawCashSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}