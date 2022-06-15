using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Globalization;

namespace AGDataUI.Helpers.NonPageSpecificHelpers
{
    public class ReportHelper
    {
        static ExtentReports extent;

        public static ExtentReports SetupExtentReport()
        {
            DateTime date = new DateTime();
            string actualDate = date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string reportPath = @"C:\Others\Reports\AutomationReports.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("OS", "Windows");
            extent.AddSystemInfo("UserName", "Yogesh");

            return extent;
        }
    }
}
