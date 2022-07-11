using System;
using OpenQA.Selenium;
using static System.TimeSpan;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;
using SeleniumExtras.PageObjects;



namespace monorail_web_v3.Commons
{
    public class Functions
    {
        public static bool IsElementNotVisibleByXpath(string xpath, IWebDriver driver) 
        {
           try
            {
                driver.Manage().Timeouts().ImplicitWait = FromSeconds(1);
                driver.FindElement(By.XPath(xpath));
                driver.Manage().Timeouts().ImplicitWait = FromSeconds(30);
               return false;
            }
            catch (Exception e)
            {
                driver.Manage().Timeouts().ImplicitWait = FromSeconds(30);
                return true;
            }
        }

        public static bool IsElementNotVisibleById(string id, IWebDriver driver)
        {

            try
            {
                driver.Manage().Timeouts().ImplicitWait = FromSeconds(1);
                driver.FindElement(By.Id(id));
                driver.Manage().Timeouts().ImplicitWait = FromSeconds(30);
                return false;
            }
            catch (Exception e)
            {
                driver.Manage().Timeouts().ImplicitWait = FromSeconds(30);
                return true;
            }
        }
    }
}