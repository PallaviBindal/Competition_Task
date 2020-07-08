//using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using MarsFramework.Pages;
using MarsFramework.Helpers;

namespace MarsFramework
{
    public class Profile
    {


        public Profile()
        {

            PageFactory.InitElements(Driver.driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        public IWebElement Shareskillbutton { get; set; }


        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement manageListingsLink { get; set; }




        public ShareSkill NavigateToshareSkillpage()
        {
            Driver.TurnOnWait();
            Shareskillbutton.Click();
            return new ShareSkill();
        }


        public ManageListings ClickManageListing()
        {
            manageListingsLink.Click();
            return new ManageListings();

        }
    }
}



