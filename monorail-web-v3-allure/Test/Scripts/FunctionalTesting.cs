using System;
using System.IO;
using Allure.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace monorail_web_v3.Test.Scripts
{
    public class FunctionalTesting
    {
        private const string BaseUrl = "https://monarchweb-app-feature.azurewebsites.net/login";
        public static IWebDriver Driver;
        public static WebDriverWait Wait;

        [OneTimeSetUp]
        public void Init()
        {
            var projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            const string configFolder = "Config";
            Environment.SetEnvironmentVariable(
                AllureConstants.ALLURE_CONFIG_ENV_VARIABLE,
                Path.Combine(projectPath, configFolder, AllureConstants.CONFIG_FILENAME));
        }

        [SetUp]
        public void StartBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Url = BaseUrl;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}