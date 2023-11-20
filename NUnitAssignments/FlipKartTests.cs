using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAssignments
{
    [TestFixture]
    internal class FlipKartTests : CoreCodes
    {
        [Test]
        public void ProductSearchTest()
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            driver.FindElement(By.ClassName("_30XB9F")).Click(); //Closing the login window that pops up
            IWebElement searchInputTextBox = driver.FindElement(By.ClassName("Pke_EE"));
            searchInputTextBox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            IWebElement searchButton = fluentWait.Until(d => d.FindElement(By.ClassName("_2iLD__")));
            searchButton.Click();
            Assert.That(driver.Title.ToLower().Contains("hp laptop"));
        }
    }
}
