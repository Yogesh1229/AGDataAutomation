using OpenQA.Selenium;

namespace AGDataUI.Models.ObjectsRepository
{
    public class HomePage
    {
        private IWebDriver driver;
        private By company = By.XPath("//nav[@id='site-navigation']//ul[@id='primary-menu']//a[text() = 'Company']");
        private By careers = By.XPath("//nav[@id='site-navigation']//ul[@id='primary-menu']//a[text() = 'Careers']");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
