using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.LinkText, Using = "Black-2.50")]
        public IWebElement? Size { get; set; }

        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement? ClickBuyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnchkavail')]")]
        public IWebElement? CheckAvailabilityButton { get; set; }

        [FindsBy(How = How.Id, Using = "Register")]
        public IWebElement? CreateAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cartData']/li[1]/div[2]/h2/a")]
        public IWebElement? CartItem { get; set; }

        //Act
        public void SelectSize()
        {
            Size?.Click();
        }
        public void BuyButtonClick()
        {
            ClickBuyButton?.Click();
        }
        public string? GetCartItemUrl()
        {
            return CartItem?.GetAttribute("href");
        }
        public string GetCurrentUrl()
        {
            return driver.Url;
        }
    }
}
