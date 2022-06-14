using AGDataUI.Helpers.NonPageSpecificHelpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AGDataUI.Models.ObjectsRepository
{
    public class JobOpeningsPage
    {
        private IWebDriver driver;
        private By managerLink = By.XPath("//a[contains(text(), 'Manager')]");
        private By frameId = By.Id("HBIFRAME");
        private By applyBtn = By.XPath("//a[text()='Apply']");

        public JobOpeningsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JobOpeningsPage ClickOnSecondManagerLink()
        {
            SeleniumHelper.SwitchToFrame(driver, frameId);
            IReadOnlyCollection<IWebElement> managersList = 
                SeleniumHelper.FindElements(driver, managerLink, TimeSpan.FromSeconds(60), "All Managers List");

            SeleniumHelper.ClickUsingJSExecutor(driver, managersList.ElementAt(1));

            return this;
        }

        public void VerifyIfApplyButtonIsDisplayed()
        {
            bool isApplyBtnDisplayed = SeleniumHelper.IsElementDisplayed(driver, applyBtn, TimeSpan.FromSeconds(60), "Apply Button");
            Assert.True(isApplyBtnDisplayed, "Manager openings description page is not opened.");
        }
    }
}
