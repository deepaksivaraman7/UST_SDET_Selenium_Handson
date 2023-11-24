﻿using Naaptol.PageObjects;
using Naaptol.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.TestScripts
{
    [TestFixture]
    internal class ProductPurchaseTests:CoreCodes
    {
        //Asserts
        [Test, Order(1), Category("Regression Test")]
        public void AddToCartTests()
        {
            
            var homePage = new NaaptolHomePage(driver);
            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com");
            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "ProductSearch";
            List<SearchProduct> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            {
                try
                {
                    string? searchText = excelData.SearchText;
                    string? productposition = excelData.ProductPosition;
                    homePage.ClearSearchBar();
                    homePage.SearchProductType(searchText);

                    var productsPage = homePage.SearchButtonClick();
                    productsPage.ProductSelect(productposition);
                    List<string> listWindows = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(listWindows[1]);
                    var productPage = new ProductPage(driver);
                    productPage.SelectSize();
                    productPage.BuyButtonClick();
                    Thread.Sleep(2000);
                    TakeScreenshot();
                    Assert.That(productPage.GetCartItemUrl(), Is.EqualTo(productPage.GetCurrentUrl()));
                    int prevquantity = productPage.GetQuantity();
                    productPage.QuantityIncrease();
                    TakeScreenshot();
                    Assert.That(prevquantity + 1 == productPage.GetQuantity());
                    productPage.RemoveProductLinkClick();
                    TakeScreenshot();
                    Assert.That(productPage.GetCartItemUrl(), Is.Null);
                    productPage.CloseButtonClick();
                    test = extent.CreateTest("Add to cart test - Passed");
                    test.Pass("Add to cart Success");
                }
                catch
                {
                    TakeScreenshot();
                    test = extent.CreateTest("Add to cart test - Failed");
                    test.Fail("Add to cart Failed");
                    
                }
                finally
                {
                    List<string> listWindows = driver.WindowHandles.ToList();
                    if (listWindows.Count > 1)
                    {
                        driver.Close();
                        driver.SwitchTo().Window(listWindows[0]);
                    }
                }
            }
        }
    }
}