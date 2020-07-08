using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Helpers
{
    public class Driver
    {
        //Initialize the browser
        public static IWebDriver driver { get; set; }

        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();
            TurnOnWait();
            driver.Manage().Window.Maximize();
        }

        //Url Method
        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }


        public string title
        {
            get { return driver.Title; }

        }
        public static string BaseUrl
        {
            get { return ConstantHelpers.Url; }
        }



        //explicit wait until element is clickable
        public static void waitClickableElement(string locatorValue)
        {
            try
            {
                var wait = new WebDriverWait(Driver.driver, new TimeSpan(0, 0, 20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));

            }
            catch (Exception ex)
            {
                Assert.Fail("Exception at waitClickableElement", ex.Message);
            }

        }

        ////explicit wait until element is visible
        public static void waitElementIsVisible(string locatorValue)
        {
            try
            {
                var wait = new WebDriverWait(Driver.driver, new TimeSpan(0, 0, 20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));

            }
            catch (Exception ex)
            {
                Assert.Fail("Exception at waitElementIsVisible", ex.Message);
            }

        }

        public static void waitElement(string locatorValue)
        {
            try
            {
                var wait = new WebDriverWait(Driver.driver, new TimeSpan(0, 0, 30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locatorValue)));

            }
            catch
            {

            }
        }

        // generic method that allows driver to wait until element is clickable
        public void waitClickableElement(IWebDriver driver, string locator, string locatorValue)
        {
            try
            {
                if (locator == "Id")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
                }
                if (locator == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                }
                if (locator == "CSSSelector")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Excetion at waitClickableElement", ex.Message);
            }

        }


        //Implicit Wait
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }




    }
}

