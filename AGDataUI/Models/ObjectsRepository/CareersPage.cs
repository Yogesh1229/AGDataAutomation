using AGDataUI.Helpers.NonPageSpecificHelpers;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;

namespace AGDataUI.Models.ObjectsRepository
{
    public class CareersPage
    {
        private IWebDriver driver;
        private readonly By _viewOpenPositions = By.XPath("//a[text() = 'View Open Positions']");

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JobOpeningsPage ClickOnViewOpenPositionsLink(ExtentTest test)
        {
            SeleniumHelper.Click(driver, _viewOpenPositions, TimeSpan.FromSeconds(60), test, "View Open Positions", "Careers Page");

            test.Log(Status.Pass, "Clicked on view open positions link successfully");
            return new JobOpeningsPage(driver);
        }
    }
}
