using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons.Modals.OnboardingModals
{
    public class OnboardingModal : Modal
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h2")]
        protected IWebElement StepHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-modal__body__content']//h4")]
        protected IWebElement StepSubheader;

        protected OnboardingModal(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        protected void CheckOnboardingModal()
        {
            try
            {
                Wait.Until(ElementToBeVisible(StepHeader));
                Wait.Until(ElementToBeVisible(StepSubheader));
                Wait.Until(ElementToBeVisible(BackButton));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}