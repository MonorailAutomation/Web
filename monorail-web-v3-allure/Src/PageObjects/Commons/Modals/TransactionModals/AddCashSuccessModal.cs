using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace monorail_web_v3.PageObjects.Commons.Modals.TransactionModals
{
    public class AddCashSuccessModal : Modal
    {
        protected const string AddCashSuccessHeaderText = "Success!";
        protected const string AddCashSuccessMessageText = "Funds are on their way to Monorail";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        protected IWebElement SuccessHeader;

        protected AddCashSuccessModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}