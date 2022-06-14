using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace AGDataUI.Helpers.NonPageSpecificHelpers
{
    public class BrowserHelper
    {
        public static IWebDriver driver;

        public static IWebDriver InitializeDriver(string browser)
        {
            if (browser.Equals("Chrome"))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();               
            }
            else if (browser.Equals("Edge"))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                driver = new EdgeDriver();
            }
            else
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            }

            return driver;
        }
    }
}
