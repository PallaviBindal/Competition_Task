using AventStack.ExtentReports;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using MarsFramework.Helpers;
using NUnit.Framework;
using System;
using System.Drawing.Drawing2D;
using static MarsFramework.Helpers.CommonMethods;

namespace MarsQA_1.Utils
{

    public class Start : Driver
    {
        [OneTimeSetUp]
       // initaialse  extent report
        public static void BeforeTestFixture()
        {
            ExtentReport.getInstance();
        }

       
       [SetUp]
        public void Setup()
        {
            //launch the browser
            Initialize();

        }

        [TearDown]
        public void TearDown()
        {
           //Screenshot 
            SaveScreenShotClass save = new SaveScreenShotClass();
            string img = save.SaveScreenshot(driver, "this");
            
        }


        [OneTimeTearDown]
        public void afterTestFixture() { 
            //Flush the extent report
            ExtentReport.EndReport1();
            //Close the browser
            driver.Close();
        }

        
       
       



        
    }

}






  

