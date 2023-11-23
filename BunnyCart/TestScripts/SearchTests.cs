using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class SearchTests:CoreCodes
    {
        [Test]
        [TestCase("water poppy")]
        public void SearchProductAndAddToCartTest(string searchText)
        {
            BunnyCartHomePage bchp = new(driver);
            SearchResultsPage srp = bchp.TypeSearchInput(searchText);
            ProductPage pp = srp.ProductClick();
            Assert.That(pp.GetUrl().Contains("water-poppy"));
            pp.QuantityIncreaseClick();
            pp.AddToCartCLick();
        }
    }
}
