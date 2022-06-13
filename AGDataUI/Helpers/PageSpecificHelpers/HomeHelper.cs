using OpenQA.Selenium;

namespace AGDataUI.Helpers.PageSpecificHelpers
{
    public class HomeHelper
    {
        private IWebDriver driver;

        public HomeHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
