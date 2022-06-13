using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace AGDataUI
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
            driver.Navigate().GoToUrl("https://www.agdata.com");

             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));

            By company = By.XPath("//nav[@id='site-navigation']//ul[@id='primary-menu']//a[text() = 'Company']");
            By careers = By.XPath("//nav[@id='site-navigation']//ul[@id='primary-menu']//a[text() = 'Careers']");
            By viewOpenPositions = By.XPath("//a[text() = 'View Open Positions']");
            By managerLink = By.XPath("//a[contains(text(), 'Manager')]");
            
            IWebElement companyElement = wait.Until(d => d.FindElement(company));
            companyElement.Click();
            Thread.Sleep(3000);
            IWebElement careersElement = wait.Until(d => d.FindElement(careers));
            careersElement.Click();
            IWebElement viewOpenPositionsElement = wait.Until(d => d.FindElement(viewOpenPositions));
            viewOpenPositionsElement.Click();
            driver.SwitchTo().Frame(driver.FindElement(By.Id("HBIFRAME")));
            int count = driver.FindElements(managerLink).Count;
            IReadOnlyCollection<IWebElement> managerElements = wait.Until(d => d.FindElements(managerLink));

            Actions actions = new Actions(driver);
            actions.DoubleClick(managerElements.ElementAt(2)).Perform();
        }
    }
}
