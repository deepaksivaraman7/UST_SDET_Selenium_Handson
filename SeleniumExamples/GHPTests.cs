using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExamples
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com";
        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Title - "+driver.Title);
            Console.WriteLine("Title length - "+driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Passed");
        }
        public void PageSourceAndUrlTest()
        {
            Console.WriteLine("Page source length - " +driver.PageSource.Length);
            Console.WriteLine("URL - " + driver.Url);
            Console.WriteLine("URL length - " + driver.Url.Length);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("Url test - Passed");
        }
        public void GoogleSearchTest()
        {
            IWebElement searchInputTextBox = driver.FindElement(By.Id("APjFqb"));
            searchInputTextBox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));
            googleSearchButton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine("Google search test - Passed");
        }
        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            Thread.Sleep(2000);
            //driver.FindElement(By.LinkText("Gmail")).Click();
            driver.FindElement(By.PartialLinkText("ma")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.Title.Contains("Gmail"));
            Console.WriteLine("Gmail link test - Passed");
        }
        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            Thread.Sleep(2000);
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(2000);
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("Images link test - Passed");
        }
        public void LocalizationTest()
        {
            driver.Navigate().Back();
            Thread.Sleep(2000);
            string local=driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(2000);
            Assert.AreEqual(local,"India");
            Console.WriteLine("Localization test - Passed");
        }
        public void GAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div/c-wiz/div/div/c-wiz/div/div/div[2]/div[2]/div[1]/ul/li[4]")).Click();
            Thread.Sleep(2000);
            Assert.AreEqual(driver.Title,"YouTube");
            Console.WriteLine("Youtube App test - Passed");
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
