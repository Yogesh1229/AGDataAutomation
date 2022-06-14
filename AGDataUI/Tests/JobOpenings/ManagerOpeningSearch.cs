using AGDataUI.Models.ObjectsRepository;
using AGDataUI.Tests.Base;
using Xunit;

namespace AGDataUI.Tests.JobOpenings
{
    public class ManagerOpeningSearch : TestCaseSetup
    {
        [Fact]
        [Trait("UI", "ManagerOpeningSearch")]
        public void AGData_UI_ManagerOpeningSearch_SuccessfulRequests_01_01_ClickOnSecondLinkContainsManagerFromAllAvailableJobs()
        {
            HomePage homePage = new HomePage(driver);
            homePage
                .ClickOnCareersLink()
                .ClickOnViewOpenPositionsLink()
                .ClickOnSecondManagerLink()
                .VerifyIfApplyButtonIsDisplayed();
        }
    }
}
