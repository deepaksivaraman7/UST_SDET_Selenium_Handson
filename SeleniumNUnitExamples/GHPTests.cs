using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture]
    internal class GHPTests:CoreCodes
    {
        [Ignore("Other")]
        [Test]
        [Order(1)]
        public void TitleTest()
        {
            Thread.Sleep(5000);
            string title = driver.Title;
            Assert.AreEqual("Google", title);
        }
        [Ignore("Other")]
        [Test]
        [Order(2)]
        public void GSTest()
        {
            IWebElement searchInputTextBox = driver.FindElement(By.Id("APjFqb"));
            searchInputTextBox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));
            googleSearchButton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
        }
        [Ignore("Other")]
        [Test]
        public void ALlLinksStatusTest()
        {
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
            foreach(var link in allLinks)
            {
                string url=link.GetAttribute("href");
                if (url == null)
                {
                    Console.WriteLine("Url is null");
                    continue;
                }
                else
                {
                    bool isWorking = CheckLinkStatus(url);
                    if (isWorking)
                    {
                        Console.WriteLine(url + " is working");
                    }
                    else
                    {
                        Console.WriteLine(url + " is not working");
                    }
                }
            }
        }
    }
}
