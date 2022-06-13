using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace AGDataUI.Helpers.NonPageSpecificHelpers
{
    public class SeleniumHelper
    {
        public static IWebElement findElement(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            IWebElement element = null;
            try
            {
                waitForElementPresent(driver, locator, timeout);
                element = driver.FindElement(locator);
                return element;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IReadOnlyCollection<IWebElement> findElements(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                waitForElementPresent(driver, locator, timeout);
                elements = driver.FindElements(locator);
                return elements;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void waitForElementPresent(IWebDriver driver, By locator, TimeSpan timeout)
        {
            try
            {
                new WebDriverWait(driver, timeout).Until(d => d.FindElement(locator));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static void navigateToUrl(IWebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static void click(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            try
            {
                waitForElementPresent(driver, locator, timeout);
                IWebElement element = findElement(driver, locator, timeout, fieldName);
                highlightElement(driver, element);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void switchToFrame(IWebDriver driver, string frameId)
        {
            try
            {
                driver.SwitchTo().Frame(driver.FindElement(By.Id(frameId)));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static void doubleClick(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(element).Perform();
        }

        public static void highlightElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid green;');", element);
            Thread.Sleep(500);
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");
        }
    }
}
