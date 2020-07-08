using AventStack.ExtentReports;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;


namespace MarsFramework.Helpers
{

    [TestFixture]
    public  class ExtentReport
    {
        public static ExtentTest test;
        public static ExtentReports extent;
       private static ExtentHtmlReporter htmlReporter;

        private ExtentReport()
        { 
        }
        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(ConstantHelpers.ReportPath);
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("HostName", "SkillSwap");
                extent.AddSystemInfo("Environment", "QC");
                extent.AddSystemInfo("Username", "Pallavi");
                // string extentConfigPath = @"C:\git\MyOnBoarding_Project\marsframework\MarsFramework\Config\XMLFile.xml";  
                //htmlReporter.LoadConfig(extentConfigPath);
            }
            return extent;
            
        }
        public static void afterTest()
        {
            //ExtentReports Extent = ExtentReport.getInstance();
          // test.Log(Status.Info, "test passed");

        }
        public static void EndReport1()
        {

            extent.Flush();
        }

        }
}










              
                    




              



             
            
            
            
        