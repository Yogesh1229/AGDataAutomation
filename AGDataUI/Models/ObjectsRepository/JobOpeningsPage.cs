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
        private By _managerLink = By.XPath("//a[contains(text(), 'Manager')]");
        private By _frameId = By.Id("HBIFRAME");
        private By _applyBtn = By.XPath("//a[text()='Apply']");

        public JobOpeningsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JobOpeningsPage ClickOnSecondManagerLink()
        {
            SeleniumHelper.SwitchToFrame(driver, _frameId);
            IReadOnlyCollection<IWebElement> managersList = 
                SeleniumHelper.FindElements(driver, _managerLink, TimeSpan.FromSeconds(60), "All Managers List");

            SeleniumHelper.ClickUsingJSExecutor(driver, managersList.ElementAt(1));

            return this;
        }

        public void VerifyIfApplyButtonIsDisplayed()
        {
            bool isApplyBtnDisplayed = SeleniumHelper.IsElementDisplayed(driver, _applyBtn, TimeSpan.FromSeconds(60), "Apply Button");
            Assert.True(isApplyBtnDisplayed, "Manager openings description page is not opened.");
        }
    }
}
