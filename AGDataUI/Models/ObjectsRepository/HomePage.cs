using AGDataUI.Helpers.NonPageSpecificHelpers;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;

namespace AGDataUI.Models.ObjectsRepository
{
    public class HomePage
    {
        private IWebDriver driver;
        private readonly By _company = By.XPath("//nav[@id='site-navigation']//ul[@id='primary-menu']//a[text() = 'Company']");
        private readonly By _careers = By.XPath("//nav[@id='site-navigation']//ul[@id='primary-menu']//a[text() = 'Careers']");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage HoverCompanyLink(ExtentTest test)
        {
            SeleniumHelper.MoveToElement(driver, _company, TimeSpan.FromSeconds(60), test, "Company", "Home Page");
            return this;
        }

        public CareersPage ClickOnCareersLink(ExtentTest test)
        {
            HoverCompanyLink(test);
            SeleniumHelper.MoveToElementAndClick(driver, _careers, TimeSpan.FromSeconds(60), test, "Careers", "Home Page");

            test.Log(Status.Pass, "Clicked on careers link successfully");
            return new CareersPage(driver);
        }
    }
}
