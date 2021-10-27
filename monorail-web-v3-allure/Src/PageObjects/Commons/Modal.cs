using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons
{
    public class Modal
    {
        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Back')]")]
        protected IWebElement BackButton;

        [FindsBy(How = How.XPath, Using = "//vim-modal-footer//button[contains(text(), 'Cancel')]")]
        protected IWebElement CancelButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//button[contains(text(),'Confirm')]")]
        protected IWebElement ConfirmButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//button[contains(text(),'Continue')]")]
        protected IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__header__title']")]
        protected IWebElement ModalHeader;

        [FindsBy(How = How.XPath, Using = "//button[@class='vim-modal__header__button']")]
        protected IWebElement XButton;

        protected Modal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Confirm' button")]
        public Modal ClickConfirmButton()
        {
            Wait.Until(ElementToBeVisible(ConfirmButton));
            ConfirmButton.Click();
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public Modal ClickContinueButton()
        {
            Wait.Until(ElementToBeVisible(ContinueButton));
            ContinueButton.Click();
            return this;
        }
    }
}