using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.WishlistScreen
{
    public class AddNewItemModal
    {
        [FindsBy(How = How.XPath, Using = "//vim-add-item-link-modal//button[contains(text(),'Continue')]")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "itemURL_wishlist")]
        private IWebElement _linkField;

        public AddNewItemModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Paste link: {0}")]
        public AddNewItemModal PasteLink(string wishlistItemUrl)
        {
            Wait.Until(ElementToBeVisible(_linkField));
            _linkField.SendKeys(wishlistItemUrl);
            return this;
        }

        [AllureStep("Click 'Continue' button")]
        public AddNewItemModal ClickContinueButton()
        {
            Wait.Until(ElementToBeClickable(_linkField));
            _continueButton.Click();
            return this;
        }
    }
}