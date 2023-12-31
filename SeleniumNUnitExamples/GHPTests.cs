﻿using OpenQA.Selenium.Chrome;
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
        //[Ignore("Other")]
        [Test]
        [Order(2)]
        public void GSTest()
        {
            string currDir = Directory.GetParent(@"../../../")?.FullName;
            string excelFilePath = currDir + "\\InputData.xlsx";
            Console.WriteLine(excelFilePath);
            List<ExcelData>excelDataList=ExcelUtils.ReadExcelData(excelFilePath);
            foreach (var excelData in excelDataList)
            {
                Console.WriteLine($"Text: {excelData.SearchText}");

                IWebElement searchInputTextBox = driver.FindElement(By.Id("APjFqb"));
                searchInputTextBox.SendKeys(excelData.SearchText);
                Thread.Sleep(2000);
                IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));
                googleSearchButton.Click();
                Assert.That(driver.Title, Is.EqualTo(excelData.SearchText+" - Google Search"));
                driver.Navigate().GoToUrl("https://www.google.com/");
            }
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
