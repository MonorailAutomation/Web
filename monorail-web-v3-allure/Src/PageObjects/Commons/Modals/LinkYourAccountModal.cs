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
        private const string LinkAnAccountModalHeaderText = "Link an Account";

        private const string EncryptionInfoText =
            "End to end encryption. Your credentials are never made available to Vimvest.";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//p")]
        private IWebElement _encryptionInfo;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Link Your Account')]")]
        private IWebElement _linkYourAccountButton;

        public LinkYourAccountModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click 'Link Your Account' button")]
        public LinkYourAccountModal ClickLinkYourAccountButton()
        {
            Wait.Until(ElementToBeClickable(_linkYourAccountButton));
            _linkYourAccountButton.Click();
            return this;
        }

        [AllureStep("Check 'Link your Account' modal")]
        public LinkYourAccountModal CheckLinkYourAccountModal()
        {
            Thread.Sleep(4000);
            try
            {
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(_encryptionInfo));
                Wait.Until(ElementToBeVisible(BackButton));
                Wait.Until(ElementToBeVisible(_linkYourAccountButton));

                ModalHeader.Text.Should().Contain(LinkAnAccountModalHeaderText);
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