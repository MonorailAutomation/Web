using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals
{
    public class ChooseATypeModal : Modal
    {
        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-modal__footer']//span[contains(text(),'Cancel')]")]
        private IWebElement _cancelButton;

        protected ChooseATypeModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        protected ChooseATypeModal CheckChooseATypeModal(string headerText)
        {
            Wait.Until(ElementToBeVisible(ModalHeader));
            Wait.Until(ElementToBeClickable(XButton));
            Wait.Until(ElementToBeClickable(_cancelButton));

            ModalHeader.Text.Should().Contain(headerText);

            return this;
        }
    }
}