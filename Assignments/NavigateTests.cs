using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class NavigateTests
    {
        IWebDriver? driver; //Initializing web driver 
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //Initializing chrome driver
            driver.Url = "https://www.google.com/"; //Setting URL for driver as www.google.com
            driver.Manage().Window.Maximize(); //Maximizing the browser window
        }
        public void NavigateTest()
        {
            driver.Navigate().GoToUrl("https://www.yahoo.com"); //Navigating to www.yahoo.com
            driver.Navigate().Back(); //Going back to google.com
            driver.Navigate().Forward(); //Forwarding to yahoo.com
            driver.Navigate().Back(); //Going back to google.com
            driver.FindElement(By.Id("APjFqb")).SendKeys("what's new for Diwali 2023?"); //Entering search text in search box
            Thread.Sleep(1000); //Delaying the process for 1 second
            driver.FindElement(By.ClassName("gNO89b")).Click(); //Clicking the search button
            Assert.AreEqual("what's new for Diwali 2023? - Google Search", driver.Title); //Comparing the title of the loaded webpage with the required title
            driver.Navigate().Refresh(); //Refreshing the webpage
            Console.WriteLine("Navigate test - Passed");
        }
        public void Destruct()
        {
            driver.Close(); //Closing the driver after tests
        }
    }
}
