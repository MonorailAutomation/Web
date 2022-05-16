using Microsoft.Extensions.Configuration;
using monorail_web_v3.Model.ConfigurationModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.TimeSpan;
using static monorail_web_v3.Test.Configuration;

namespace monorail_web_v3.Test.Scripts
{
    public class FunctionalTesting
    {
        public static string MonorailTestEnvironment;
        public static IWebDriver Driver;
        public static WebDriverWait Wait;

        [SetUp]
        public void BeforeAll()
        {
            BuildAllureConfig();

            var configuration = new ConfigurationBuilder().BuildAppSettings();

            var environmentConfiguration =
                configuration.GetSection("EnvironmentConfiguration").Get<EnvironmentConfiguration>();
            var waitsConfiguration = configuration.GetSection("WaitsConfiguration").Get<WaitsConfiguration>();

            MonorailTestEnvironment = environmentConfiguration.TestEnvironment;

            var monorailUrl = "https://monarchweb-app-" + MonorailTestEnvironment + ".azurewebsites.net/login";

            var options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            Driver = new ChromeDriver(options);
            Driver.Url = monorailUrl;
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = FromSeconds(waitsConfiguration.ImplicitWaitDuration);
            Wait = new WebDriverWait(Driver, FromSeconds(waitsConfiguration.ExplicitWaitDuration));
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}