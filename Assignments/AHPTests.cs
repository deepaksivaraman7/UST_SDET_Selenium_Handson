using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignments
{
    internal class AHPTests
    {
        IWebDriver? driver; //Initializing web driver 
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //Initializing chrome driver
            driver.Url = "https://www.amazon.com/"; //Setting URL for driver
            driver.Manage().Window.Maximize(); //Maximizing the browser window
        }
        public void AmazonTitleTest()
        {
            Assert.That(driver.Title.Contains("Amazon")); //Checking whether the title contains required parameter
            Console.WriteLine("Amazon title test - Passed");
        }
        public void OrgTypeTest()
        {
            Assert.That(driver.Url.Contains(".coom")); //Checking whether the URL contains required parameter
            Console.WriteLine("Amazon organization test - Passed");
        }
        public void Destruct()
        {
            driver.Close(); //Closing the driver after tests
        }
    }
}
