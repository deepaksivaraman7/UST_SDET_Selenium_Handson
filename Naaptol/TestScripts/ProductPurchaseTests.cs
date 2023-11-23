using Naaptol.PageObjects;
using Naaptol.Utilities;
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
            homePage.SearchProductType("eyewear");
            var productsPage=homePage.SearchButtonClick();
            productsPage.ProductSelect();
            List<string> listWindows = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(listWindows[1]);
            var productPage = new ProductPage(driver);
            productPage.SelectSize();
            productPage.BuyButtonClick();
            Thread.Sleep(3000);
            Assert.AreEqual(productPage.GetCurrentUrl(), productPage.GetCartItemUrl());
            
        }
    }
}
