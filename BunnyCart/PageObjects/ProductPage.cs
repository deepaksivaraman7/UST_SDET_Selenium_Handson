using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "product-addtocart-button")]
        private IWebElement AddToCartButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "qty-inc")]
        private IWebElement QuantityIncreaseButton { get; set; }
        public string GetUrl()
        {
            return driver.Url;
        }
        public void AddToCartCLick()
        {
            AddToCartButton?.Click();
        }
        public void QuantityIncreaseClick()
        {
            QuantityIncreaseButton?.Click();
        }
    }
}
