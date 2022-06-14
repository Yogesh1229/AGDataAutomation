using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AGDataUI.Helpers.NonPageSpecificHelpers
{
    public class SeleniumHelper
    {
        public static IWebElement FindElement(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            IWebElement element = null;
            try
            {
                WaitForElementPresent(driver, locator, timeout);
                element = driver.FindElement(locator);
                return element;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IReadOnlyCollection<IWebElement> FindElements(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                WaitForElementPresent(driver, locator, timeout);
                elements = driver.FindElements(locator);
                return elements;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void WaitForElementPresent(IWebDriver driver, By locator, TimeSpan timeout)
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

        public static void NavigateToUrl(IWebDriver driver, string url)
        {
            try
            {
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
                driver.Navigate().GoToUrl(url);               
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static void Click(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            try
            {
                WaitForElementPresent(driver, locator, timeout);
                IWebElement element = FindElement(driver, locator, timeout, fieldName);
                HighlightElement(driver, element);
                element.Click();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ClickUsingJSExecutor(IWebDriver driver, IWebElement element)
        {
            try
            {
                if(element.Displayed && element.Enabled)
                {
                    HighlightElement(driver, element);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                }  
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsElementDisplayed(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            bool isDisplayed = false;
            try
            {
                IWebElement element = FindElement(driver, locator, timeout, fieldName);
                isDisplayed = element.Displayed;
                return isDisplayed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SwitchToFrame(IWebDriver driver, By frameId)
        {
            try
            {
                driver.SwitchTo().Frame(driver.FindElement(frameId));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static void DoubleClick(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(element).Perform();
        }

        public static void MoveToElement(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(FindElement(driver, locator, timeout, fieldName)).Perform();
        }

        public static void MoveToElementAndClick(IWebDriver driver, By locator, TimeSpan timeout, string fieldName)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(FindElement(driver, locator, timeout, fieldName)).Perform();
            actions.Click().Build().Perform();
        }

        public static void HighlightElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid green;');", element);
            Thread.Sleep(500);
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");
        }
    }
}
