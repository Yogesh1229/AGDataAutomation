using AGDataUI.Helpers.NonPageSpecificHelpers;
using OpenQA.Selenium;
using System;

namespace AGDataUI.Tests.Base
{
    public abstract class TestCaseSetup : IDisposable
    {
        protected IWebDriver driver;

        public TestCaseSetup()
        {
            driver = BrowserHelper.InitializeDriver("Chrome");
            SeleniumHelper.NavigateToUrl(driver, "https://www.agdata.com/");
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
