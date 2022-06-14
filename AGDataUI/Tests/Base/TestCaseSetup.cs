using AGDataUI.Helpers.NonPageSpecificHelpers;
using OpenQA.Selenium;
using QAAutomation.Common.Utility.Helpers;
using System;

namespace AGDataUI.Tests.Base
{
    public abstract class TestCaseSetup : IDisposable
    {
        protected IWebDriver driver;

        public TestCaseSetup()
        {
            string browserType = ConfigurationHelper.getConfigValue("AppSettings", "Browser");
            string url = ConfigurationHelper.getConfigValue("AppSettings", "Url");
            driver = BrowserHelper.InitializeDriver(browserType);
            SeleniumHelper.NavigateToUrl(driver, url);
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
