using System;
using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.ItemModals
{
    public class ItemDetailsModal : Modal
    {
        [FindsBy(How = How.Id, Using = "choosePictureDropdown")]
        private IWebElement _changeImageButton;

        [FindsBy(How = How.XPath, Using = "//textarea[@formcontrolname='itemDescription']")]
        protected IWebElement ItemDescriptionInput;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='name']")]
        protected IWebElement ItemNameInput;

        protected ItemDetailsModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Set Item name to '{0}'")]
        public ItemDetailsModal SetItemName(string itemName)
        {
            Wait.Until(ElementToBeVisible(ItemNameInput));
            ItemNameInput.Clear();
            ItemNameInput.SendKeys(itemName);
            return this;
        }

        [AllureStep("Set Item description to '{0}'")]
        public ItemDetailsModal SetItemDescription(string itemDescription)
        {
            Wait.Until(ElementToBeVisible(ItemDescriptionInput));
            ItemDescriptionInput.Clear();
            ItemDescriptionInput.SendKeys(itemDescription);
            return this;
        }

        protected ItemDetailsModal CheckItemDetailsModal(string headerText)
        {
            try
            {
                Wait.Until(ElementToBeVisible(ModalHeader));
                Wait.Until(ElementToBeVisible(XButton));
                Wait.Until(ElementToBeVisible(ItemNameInput));
                Wait.Until(ElementToBeVisible(BackButton));

                ModalHeader.Text.Should().Contain(headerText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return this;
        }
    }
}