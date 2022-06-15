using AGDataUI.Helpers.NonPageSpecificHelpers;
using AventStack.ExtentReports;
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
        private readonly By _managerLink = By.XPath("//a[contains(text(), 'Manager')]");
        private readonly By _frameId = By.Id("HBIFRAME");
        private readonly By _applyBtn = By.XPath("//a[text()='Apply']");
        private readonly By _applyBtnValidation = By.XPath("//a[text()='Ap']");

        public JobOpeningsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public JobOpeningsPage ClickOnSecondManagerLink(ExtentTest test)
        {
            SeleniumHelper.SwitchToFrame(driver, _frameId);
            IReadOnlyCollection<IWebElement> managersList = 
                SeleniumHelper.FindElements(driver, _managerLink, TimeSpan.FromSeconds(60), test, "All Managers List", "Jobs Opening Page");

            test.Log(Status.Pass, "Retrieved the list of all managers successfully");
            SeleniumHelper.ClickUsingJSExecutor(driver, managersList.ElementAt(1), TimeSpan.FromSeconds(10), test, "Second Manager Link", "Jobs Opening Page");

            return this;
        }

        public void VerifyIfApplyButtonIsDisplayed(ExtentTest test)
        {
            bool isApplyBtnDisplayed = SeleniumHelper.IsElementDisplayed(driver, _applyBtn, TimeSpan.FromSeconds(30), test, "Apply Button", "Jobs Opening Page");
            test.Log(Status.Pass, "Job description page opened successfully");
            Assert.True(isApplyBtnDisplayed, "Manager openings description page is not opened.");
        }

        public void VerifyIfApplyButtonIsDisplayed_Validations(ExtentTest test)
        {
            bool isApplyBtnDisplayed = SeleniumHelper.IsElementDisplayed(driver, _applyBtnValidation, TimeSpan.FromSeconds(30), test, "Apply Button", "Jobs Opening Page");
            test.Log(Status.Pass, "Job description page opened successfully");
            Assert.True(isApplyBtnDisplayed, "Manager openings description page is not opened.");
        }
    }
}
