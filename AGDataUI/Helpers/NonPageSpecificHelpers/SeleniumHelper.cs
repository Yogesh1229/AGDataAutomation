using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AGDataUI.Helpers.NonPageSpecificHelpers
{
    public class SeleniumHelper
    {
        public static IWebElement FindElement(IWebDriver driver, By locator, TimeSpan timeout, ExtentTest test, string fieldName, string pageName)
        {
            IWebElement element = null;
            try
            {
                WaitForElementPresent(driver, locator, timeout, test, fieldName, pageName);
                element = driver.FindElement(locator);
                return element;
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException("Unable to locate element " + bold(fieldName) + " on " + bold(pageName));
            }
        }

        public static IReadOnlyCollection<IWebElement> FindElements(IWebDriver driver, By locator, TimeSpan timeout, ExtentTest test, string fieldName, string pageName)
        {
            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                WaitForElementPresent(driver, locator, timeout, test, fieldName, pageName);
                elements = driver.FindElements(locator);
                return elements;
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException("Unable to locate element " + bold(fieldName) + " on " + bold(pageName));
            }
        }

        public static void WaitForElementPresent(IWebDriver driver, By locator, TimeSpan timeout, ExtentTest test, string fieldName, string pageName)
        {
            try
            {
                new WebDriverWait(driver, timeout).Until(d => d.FindElement(locator));
            }
            catch (System.Exception)
            {
                test.Fail("Unable to locate element " + bold(fieldName) + " on " + bold(pageName));
                throw new ElementNotVisibleException("Unable to locate element " + bold(fieldName) + " on " + bold(pageName));
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

        public static void Click(IWebDriver driver, By locator, TimeSpan timeout, ExtentTest test, string fieldName, string pageName)
        {
            try
            {
                WaitForElementPresent(driver, locator, timeout, test, fieldName, pageName);
                IWebElement element = FindElement(driver, locator, timeout, test, fieldName, pageName);
                HighlightElement(driver, element);
                element.Click();
            }
            catch (Exception)
            {
                test.Fail("Unable to click link " + bold(fieldName) + " on " + bold(pageName));
                throw new ElementClickInterceptedException("Unable to click link " + bold(fieldName) + " on " + bold(pageName));
            }
        }

        public static void ClickUsingJSExecutor(IWebDriver driver, IWebElement element, TimeSpan timeout, ExtentTest test, string fieldName, string pageName)
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
                test.Fail("Unable to click link " + bold(fieldName) + " on " + bold(pageName));
                throw new ElementClickInterceptedException("Unable to click link " + bold(fieldName) + " on " + bold(pageName));
            }
        }

        public static bool IsElementDisplayed(IWebDriver driver, By locator, TimeSpan timeout, ExtentTest test, string fieldName, string pageName)
        {
            bool isDisplayed = false;
            try
            {
                IWebElement element = FindElement(driver, locator, timeout, test, fieldName, pageName);
                isDisplayed = element.Displayed;
                return isDisplayed;
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException("Unable to locate element " + bold(fieldName) + " on " + bold(pageName));
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
                throw new Exception($"Unable to switch to frame having frameid: {frameId}");
            }
        }

        public static void MoveToElement(IWebDriver driver, By locator, TimeSpan timeout, ExtentTest test, string fieldName, string pageName)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(FindElement(driver, locator, timeout, test, fieldName, pageName)).Perform();
            }
            catch (Exception)
            {
                test.Fail("Unable to hover element " + bold(fieldName) + " on " + bold(pageName));
                throw new ElementNotInteractableException("Unable to hover element " + bold(fieldName) + " on " + bold(pageName));
            }           
        }

        public static void MoveToElementAndClick(IWebDriver driver, By locator, TimeSpan timeout, ExtentTest test, string fieldName, string pageName)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(FindElement(driver, locator, timeout, test, fieldName, pageName)).Perform();
                actions.Click().Build().Perform();
            }
            catch (Exception)
            {
                test.Fail("Unable to hover element " + bold(fieldName) + " on " + bold(pageName));
                throw new ElementClickInterceptedException ("Unable to hover and click element " + bold(fieldName) + " on " + bold(pageName));
            }
            
        }

        public static void HighlightElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid green;');", element);
            Thread.Sleep(500);
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");
        }

        public static String bold(String text)
        {
            return new StringBuilder().Append("<b>").Append(text).Append("</b>").ToString();
        }
    }
}
