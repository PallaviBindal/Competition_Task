using AventStack.ExtentReports;
using MarsFramework.Helpers;
using MarsFramework.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework
{

    [TestFixture]
    public class Program : Start
    {
        public ExtentTest test;

        ExtentReports Extent = ExtentReport.getInstance();

        [Test, Category("Unit Testing")]
        public void TestAddShareSkill()
        {
            //create Extent Report
            test = Extent.CreateTest("Report 1");

            //test log
            test.Log(Status.Info, "start test");

            //instance of signin page
            var signinpage = new SignIn();

            //click login 
            var profilepage = signinpage.LoginSteps();

            //Navigate to share skill page
            var shareSkillPage = profilepage.NavigateToshareSkillpage();

            //enter share skill record on share skill page
            var ManageListtingPage = shareSkillPage.AddShareSkills();

            //Validate enter skills 
            ManageListtingPage.ValidateManageListing();



            //Logs
            test.Log(Status.Pass, "Title has been successfully entered");
            test.Log(Status.Pass, "Description has been added");
            test.Log(Status.Pass, "Category has been successfully entered");
            test.Log(Status.Pass, "SubCategory has been successfully added");
            test.Log(Status.Pass, "Tags has been added");
            test.Log(Status.Pass, "Service type has been successfully added");
            test.Log(Status.Pass, "Location type has been added");
            test.Log(Status.Pass, "Available Days has been successfully entered");
            test.Log(Status.Pass, "Skill-Exchange Tag name has been succesfully enetered");
            test.Log(Status.Pass, "Work Sample has been added");
            test.Log(Status.Pass, "Services option has been succesfully selected");



        }


        [Test, Category("Unit Testing")]
        public void TestEditManageLisiting()
        {
            test = Extent.CreateTest("Report 3");

            var signinpage = new SignIn();

            var profilepage = signinpage.LoginSteps();

            //click manage listing on Profile page
            var manageListingPage = profilepage.ClickManageListing();

            //update share skill
            manageListingPage.EditManageListing();

            ManageListings manage = new ManageListings();

            //validate update record 
            manage.ValidateManageListing();

            //logs
            test.Log(Status.Info, "Title has been successfully updated");
            test.Log(Status.Pass, "Description has been updated");
            test.Log(Status.Pass, "Category has been successfully updated");
            test.Log(Status.Pass, "SubCategory has been successfully updated");
            test.Log(Status.Pass, "Tags has been updated");
            test.Log(Status.Pass, "Service type has been successfully updated");
            test.Log(Status.Pass, "Location type has been added");
            test.Log(Status.Pass, "Time has been successfully updated");
            test.Log(Status.Pass, "Work sample has been successfully updated");
            test.Log(Status.Pass, "Service option has been updated");

        }


        
        [Test, Category("Unit Testing")]
        public void TestRemoveManageListing()
        {
            test = Extent.CreateTest("Report 2");
            test.Log(Status.Info, "start test");
            var signinpage = new SignIn();
            var profilepage = signinpage.LoginSteps();
            var ManageListtingPage = profilepage.ClickManageListing();

            ManageListtingPage.RemoveManageListing();

            //logs
            test.Log(Status.Info, "Title has been successfully deleted");
            test.Log(Status.Pass, "Description has been deleted");
            test.Log(Status.Pass, "Category has been successfully deleted");
            test.Log(Status.Pass, "SubCategory has been successfully deleted");
            test.Log(Status.Pass, "Tags has been deleted");
            test.Log(Status.Pass, "Service type has been successfully deleted");
            test.Log(Status.Pass, "Location type has been deleted");
            test.Log(Status.Pass, "Time has been successfully deleted");
            test.Log(Status.Pass, "Work sample has been successfully deleted");
            test.Log(Status.Pass, "Service option has been deleted");

        }




    }




}




