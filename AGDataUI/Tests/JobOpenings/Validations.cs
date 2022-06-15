using AGDataUI.Models.ObjectsRepository;
using AGDataUI.Tests.Base;
using AventStack.ExtentReports;
using Xunit;

namespace AGDataUI.Tests.JobOpenings
{
    public class Validations : TestCaseSetup
    {
        ExtentTest test;

        //This test case is failed intentionally just to verify the reporting logs

        [Fact]
        [Trait("UI", "Validations")]
        public void AGData_UI_ManagerOpeningSearch_Validations_02_01_NegativeTestingToVerifyTheReportLogs()
        {
            test = extentReports.CreateTest("Validations");
            test.Log(Status.Info, "Starting the test");

            HomePage homePage = new HomePage(driver);
            homePage
                .ClickOnCareersLink(test)
                .ClickOnViewOpenPositionsLink(test)
                .ClickOnSecondManagerLink(test)
                .VerifyIfApplyButtonIsDisplayed_Validations(test);
        }
    }
}
