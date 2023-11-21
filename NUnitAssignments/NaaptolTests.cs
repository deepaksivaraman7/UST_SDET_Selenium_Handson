using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitAssignments
{
    internal class NaaptolTests : CoreCodes
    {
        string url = "";
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
            IWebElement searchInputTextBox = driver.FindElement(By.Id("header_search_text"));
            searchInputTextBox.SendKeys("eyewear");
            IWebElement searchButton = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='header_search_text']//following::div")));
            searchButton.Click();
            Assert.AreEqual("Welcome to naaptol :- Search Result for eyewear",driver.Title);
        }
        [Test]
        [Author("Deepak", "ust.com")]
        [Description("Check for product select")]
        [TestCaseSource(nameof(PositionData))]
        [Order(2)]
        public void ProductSelectTest(string position)
        {
            driver.FindElement(By.Id("productItem"+position)).Click();
            List<string> listWindows = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(listWindows[1]);
            url = driver.Url;
            Assert.AreEqual(listWindows[1],driver.CurrentWindowHandle);
        }
        [Test]
        [Author("Deepak", "ust.com")]
        [Description("Check for product add")]
        [Order(3)]
        public void ProductAddTest()
        {
            driver.FindElement(By.LinkText("Black-2.50")).Click();
            driver.FindElement(By.Id("cart-panel-button-0")).Click();
            Assert.AreEqual("block",driver.FindElement(By.XPath("//div[@id='ShoppingCartBox']")).GetCssValue("display"));
        }
        [Test]
        [Author("Deepak", "ust.com")]
        [Description("Check for cart view")]
        [Order(4)]
        public void ProductViewTest()
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            string productUrl=fluentWait.Until(d => d.FindElement(By.XPath("//*[@id=\"cartData\"]/li[1]/div[2]/h2/a")).GetAttribute("href"));
            Assert.AreEqual(url,productUrl);
        }
        static object[] PositionData()
        {
            return new object[] {
                new object[] { "5" }
                };
        }
    }
}
