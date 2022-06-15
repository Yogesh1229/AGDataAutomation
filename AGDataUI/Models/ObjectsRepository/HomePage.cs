﻿using AGDataUI.Helpers.NonPageSpecificHelpers;
using AGDataUI.Helpers.PageSpecificHelpers;
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

        public HomePage HoverCompanyLink()
        {
            SeleniumHelper.MoveToElement(driver, _company, TimeSpan.FromSeconds(60), "Company");
            return this;
        }

        public CareersPage ClickOnCareersLink()
        {
            HoverCompanyLink();
            SeleniumHelper.MoveToElementAndClick(driver, _careers, TimeSpan.FromSeconds(60), "Careers");
            return new CareersPage(driver);
        }
    }
}
