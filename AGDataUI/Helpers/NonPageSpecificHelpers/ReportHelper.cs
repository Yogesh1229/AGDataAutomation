using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Globalization;
using System.IO;

namespace AGDataUI.Helpers.NonPageSpecificHelpers
{
    public class ReportHelper
    {
        public static ExtentHtmlReporter htmlReporter;
        private static ExtentReports extent;

        private ReportHelper()
        {

        }

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                DateTime date = new DateTime();
                string actualDate = date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                string reportPath = @"C:\TestReports\index.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("UserName", "Yogesh");

                string appPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                string extentConfigPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\extent-config.xml";
                htmlReporter.LoadConfig(extentConfigPath);
            }

            return extent;
        }
    }
}
