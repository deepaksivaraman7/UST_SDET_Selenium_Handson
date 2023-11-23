using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class SearchResultsPage
    {
        IWebDriver driver;
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Water Poppy")]
        private IWebElement ProductLink {  get; set; }
        public ProductPage ProductClick()
        {
            ProductLink.Click();
            return new ProductPage(driver);
        }
    }
}
