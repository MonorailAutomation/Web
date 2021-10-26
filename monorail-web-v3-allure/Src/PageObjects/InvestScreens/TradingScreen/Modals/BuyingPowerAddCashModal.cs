using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.InvestScreens.TradingScreen.Modals
{
    public class BuyingPowerAddCashModal
    {
        private const string BuyingPowerAddCashHeader = "Add Cash";
        private const string BuyingPowerAddCashMessage = "Choose an amount to add";
        private const string TransferCompleteDateLabel = "Transfer Complete Date (Est.)";
        private const string CurrentBuyingPowerLabel = "Current Buying Power";
        
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__header__title']")]
        private IWebElement _wishlistAddCashHeader;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']/p")]
        private IWebElement _wishlistAddCashMessage;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//input")]
        private IWebElement _wishlistAddCashInput;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[1]//p[2]")]
        private IWebElement _transferCompleteDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[1]//p[1]")]
        private IWebElement _transferCompleteLabel;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[2]")]
        private IWebElement _currentBuyingPowerAmount;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//div[2]//p[1]")]
        private IWebElement _currentBuyingPowerLabel;
        
        [FindsBy(How = How.XPath, Using = "//vim-modal-body//input")]
        private IWebElement _amountInput;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__footer']//button[contains(text(),'Confirm')]")]
        private IWebElement _confirmButton;

        public BuyingPowerAddCashModal(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        
        [AllureStep("Check 'Add Cash' modal")]
        public BuyingPowerAddCashModal CheckBuyingPowerAddCashModal()
        {
            Wait.Until(ElementToBeVisible(_wishlistAddCashHeader));
            Wait.Until(ElementToBeVisible(_wishlistAddCashMessage));
            Wait.Until(ElementToBeVisible(_wishlistAddCashInput));
            Wait.Until(ElementToBeVisible(_transferCompleteLabel));
            Wait.Until(ElementToBeVisible(_transferCompleteDate));
            Wait.Until(ElementToBeVisible(_currentBuyingPowerLabel));
            Wait.Until(ElementToBeVisible(_currentBuyingPowerAmount));
            Wait.Until(ElementToBeVisible(_wishlistAddCashMessage));

            _wishlistAddCashHeader.Text.Should().Be(BuyingPowerAddCashHeader);
            _wishlistAddCashMessage.Text.Should().Be(BuyingPowerAddCashMessage);
            _transferCompleteLabel.Text.Should().Be(TransferCompleteDateLabel);
            _transferCompleteDate.Text.Should().NotBeNullOrEmpty();
            _currentBuyingPowerLabel.Text.Should().Be(CurrentBuyingPowerLabel);
            _currentBuyingPowerAmount.Text.Should().NotBeNullOrEmpty();

            return this;
        }
        
        [AllureStep("Set Buying Power Add Cash ${0} amount to add")]
        public BuyingPowerAddCashModal SetBuyingPowerAddCashAmount(string amountToAdd)
        {
            Wait.Until(ElementToBeClickable(_amountInput));
            _amountInput.Clear();
            _amountInput.SendKeys(amountToAdd);
            return this;
        }

        [AllureStep("Click 'Confirm' button")]
        public BuyingPowerAddCashModal ClickConfirmButton()
        {
            Wait.Until(ElementToBeClickable(_confirmButton));
            _confirmButton.Click();
            return this;
        }
    }
}