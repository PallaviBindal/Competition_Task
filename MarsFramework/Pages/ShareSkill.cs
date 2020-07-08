using MarsFramework.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using AutoItX3Lib;
using System;
using System.IO;
using RazorEngine.Compilation.VisualBasic;
using DocumentFormat.OpenXml.Presentation;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using FluentAssertions.AssertMultiple;
using Assert = NUnit.Framework.Assert;
using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium.Support.UI;

namespace MarsFramework.Pages
{

    public class ShareSkill
    {

        //Constructor
        public ShareSkill()
        {

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "ShareSkill");
            PageFactory.InitElements(Driver.driver, this);
        }

        //WebElements
        // Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "(//input[contains(@placeholder,'Add new tag')])[1]")]
        private IWebElement Tags { get; set; }

        //Select the hourly based Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field'][1]")]
        private IWebElement ServiceTypeHourly { get; set; }

        //Select the One-off Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field'][2]")]
        private IWebElement ServiceTypeOneOf { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field'][1]")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //clik on worksample button
        [FindsBy(How = How.XPath, Using = "//i[contains(@class,'huge plus circle icon padding-25')]")]
        private IWebElement Worksample { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field'][1]")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }


        //Click on Monday Check box 
        [FindsBy(How = How.Name, Using = "//input[@name='Available'][2]")]
        private IWebElement Monday { get; set; }

        //Enter start time
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input")]
        private IWebElement Starttime { get; set; }

        //Enter end time
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input")]
        private IWebElement Endtime { get; set; }

        //ENTER SHARE SKILL 
        public ManageListings AddShareSkills()
        {
            //Enter text in title
            EnterText(Title, ExcelLibHelper.ReadData(2, "Title"));

            //Enter text in description
            EnterText(Description, ExcelLibHelper.ReadData(2, "Description"));

            //impplicit wait
            Driver.TurnOnWait();

            //select Category
            SelectDropDown(CategoryDropDown, ExcelLibHelper.ReadData(2, "Category"));

            //select SubCategory
            SelectDropDown(SubCategoryDropDown, ExcelLibHelper.ReadData(2, "SubCategory"));

            //Select Tags and press enter
            Tags.SendKeys(ExcelLibHelper.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //explicit wait
            Driver.waitClickableElement("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field'][2]");

            //click on Service Type
            selectServiceType();

            //Click on Location type
            Clickoperation(LocationTypeOption);
            Driver.TurnOnWait();

            //Enter details in dynamic table
            SelectDaytime();

            //Clcik on Skill exchange option
            Clickoperation(SkillTradeOption);

            //enter tag in skill exchange 
            SkillExchange.SendKeys(ExcelLibHelper.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);

            //implicit wait
            Driver.TurnOnWait();

            // Add Work Sample
            worksample();

            //click on active option button
            Clickoperation(ActiveOption);

            //Click on Save Button
            Clickoperation(Save);

            return new ManageListings();


        }

        //Custom Method- Enter Text 
        public void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        //Custom Method- Select Drop Down
        public void SelectDropDown(IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        //Custom Method- Click Operation
        public void Clickoperation(IWebElement element)
        {
            element.Click();
        }

        //Custom Method- Select Service Type 
        public void selectServiceType()
        {
            if (ExcelLibHelper.ReadData(2, "ServiceType") == "Hourly basis service")

            {
                ServiceTypeHourly.Click();
            }
            else
                ServiceTypeOneOf.Click();


        }

        //Custom Method - Dynamic Table
        public void SelectDaytime()
        {
            StartDateDropDown.SendKeys(ExcelLibHelper.ReadData(2, "Startdate"));
            EndDateDropDown.SendKeys(ExcelLibHelper.ReadData(2, "Enddate"));
            for (int i = 0; i <= 6; i++)
            {


                var day = Driver.driver.FindElement(By.CssSelector("input[name='Available'][index='" + i + "']"));
                var starttime = Driver.driver.FindElement(By.CssSelector("input[name='StartTime'][index='" + i + "']"));
                var endtime = Driver.driver.FindElement(By.CssSelector("input[name='EndTime'][index='" + i + "']"));
                var label = Driver.driver.FindElement(By.XPath("//div[@class='fields'][" + (2 + i) + "]/div/div//label"));

                if (ExcelLibHelper.ReadData(2, "Selectday") == label.Text)
                {
                    day.Click();
                    starttime.SendKeys(ExcelLibHelper.ReadData(2, "Starttime"));
                    endtime.SendKeys(ExcelLibHelper.ReadData(2, "Endtime"));

                }

            }

        }

        //Custom Method - WorkSample
        public void worksample()
        {

            Clickoperation(Worksample);
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Driver.TurnOnWait();
            autoIt.Send(ConstantHelpers.FilePath);
            autoIt.Send("{ENTER}");
        }


    }






}



































