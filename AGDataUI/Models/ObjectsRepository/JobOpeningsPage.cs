using AGDataUI.Helpers.NonPageSpecificHelpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGDataUI.Models.ObjectsRepository
{
    public class JobOpeningsPage
    {
        private IWebDriver driver;
        private By managerLink = By.XPath("//a[contains(text(), 'Manager')]");
        private By frameId = By.Id("HBIFRAME");

        public JobOpeningsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JobOpeningsPage ClickOnSecondManagerLink()
        {
            SeleniumHelper.switchToFrame(driver, frameId.ToString());
            IReadOnlyCollection<IWebElement> managersList = 
                SeleniumHelper.findElements(driver, managerLink, TimeSpan.FromSeconds(60), "All Managers List");

            SeleniumHelper.doubleClick(driver, managersList.ElementAt(2));
            return this;
        }
    }
}
