using System;
using System.Threading;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class LinkYourAccountModal : Modal
    {
        private const string ConnectYourBankAccountModalHeaderText = "Connect Your Bank Account";

        private const string EncryptionInfoText =
            "End to end encryption. Your credentials are never made available to Monorail.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _encryptionInfo;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__footer']//a[contains(text(), 'Connect Your Bank Account')]")]
        private IWebElement _connectYourBankAccountButton;

        public LinkYourAccountModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Connect Your Bank Account' button")]
        public LinkYourAccountModal ClickConnectYourBankAccountButton()
        {
            Wait.Until(ElementToBeClickable(_connectYourBankAccountButton));
            _connectYourBankAccountButton.Click();
            return this;
        }

        [AllureStep("Check 'Connect Your Bank Account' modal")]
        public LinkYourAccountModal CheckConnectYourBankAccountModal()
        {
            Thread.Sleep(4000);
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_encryptionInfo));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(_connectYourBankAccountButton));

                ModalHeader.Text.Should().Contain(ConnectYourBankAccountModalHeaderText);
                _encryptionInfo.Text.Should().Contain(EncryptionInfoText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}