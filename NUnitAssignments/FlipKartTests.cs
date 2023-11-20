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
        [Author("Deepak", "ust.com")]
        [Description("Check for product search")]
        [Order(1)]
        public void ProductSearchTest()
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            CLoseLoginDialog();
            IWebElement searchInputTextBox = driver.FindElement(By.ClassName("Pke_EE"));
            searchInputTextBox.SendKeys("hp laptop");
            IWebElement searchButton = fluentWait.Until(d => d.FindElement(By.ClassName("_2iLD__")));
            searchButton.Click();
            Assert.That(driver.Title.ToLower().Contains("hp laptop"));
        }
        [Test]
        [Author("Deepak", "ust.com")]
        [Description("Check for product select")]
        [Order(2)]
        public void SelectProductTest()
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            driver.FindElement(By.XPath("//a[@class='_1fQZEK'][1]")).Click();
            List<string> listWindows = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(listWindows[1]);
            Assert.AreEqual(driver.CurrentWindowHandle, listWindows[1]);
        }
        [Test]
        [Author("Deepak", "ust.com")]
        [Description("Check for add to cart")]
        [Order(3)]
        public void AddToCartTest()
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@class='_2KpZ6l _2U9uOA _3v1-ww']")).Click();
            driver.FindElement(By.ClassName("_3SkBxJ")).Click();
            List<IWebElement> cartItems = driver.FindElements(By.ClassName("_2nQDXZ")).ToList();
            Assert.NotNull(cartItems);
        }
        void CLoseLoginDialog()
        {
            driver.FindElement(By.ClassName("_30XB9F")).Click(); //Closing the login window that pops up
        }
    }
}
