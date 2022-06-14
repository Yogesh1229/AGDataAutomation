using AGDataUI.Helpers.NonPageSpecificHelpers;
using OpenQA.Selenium;
using System;

namespace AGDataUI.Models.ObjectsRepository
{
    public class CareersPage
    {
        private IWebDriver driver;
        private By _viewOpenPositions = By.XPath("//a[text() = 'View Open Positions']");

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JobOpeningsPage ClickOnViewOpenPositionsLink()
        {
            SeleniumHelper.Click(driver, _viewOpenPositions, TimeSpan.FromSeconds(60), "View Open Positions");

            return new JobOpeningsPage(driver);
        }
    }
}
