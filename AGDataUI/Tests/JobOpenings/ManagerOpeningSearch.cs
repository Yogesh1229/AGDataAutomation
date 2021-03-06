using AGDataUI.Models.ObjectsRepository;
using AGDataUI.Tests.Base;
using AventStack.ExtentReports;
using Xunit;

namespace AGDataUI.Tests.JobOpenings
{
    public class ManagerOpeningSearch : TestCaseSetup
    {
        ExtentTest test;

        [Fact]
        [Trait("UI", "ManagerOpeningSearch")]
        public void AGData_UI_ManagerOpeningSearch_SuccessfulRequests_01_01_ClickOnSecondLinkContainsManagerFromAllAvailableJobs()
        {
            test = extentReports.CreateTest("ManagerOpeningSearch");
            test.Log(Status.Info, "Starting the test");

            HomePage homePage = new HomePage(driver);
            homePage
                .ClickOnCareersLink(test)
                .ClickOnViewOpenPositionsLink(test)
                .ClickOnSecondManagerLink(test)
                .VerifyIfApplyButtonIsDisplayed(test);

            test.Log(Status.Pass, "Test Case Passed");
        }
    }
}
