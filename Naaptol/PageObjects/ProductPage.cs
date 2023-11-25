using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'2.50')][1]")]
        public IWebElement? Size { get; set; }

        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement? ClickBuyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnchkavail')]")]
        public IWebElement? CheckAvailabilityButton { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='cartData']/li[1]/div[2]/h2/a")]
        //public IWebElement? CartItem { get; set; }

        [FindsBy(How = How.LinkText, Using = "Remove")]
        public IWebElement? RemoveProductLink { get; set; }

        [FindsBy(How = How.ClassName, Using = "input_Special_2")]
        public IWebElement? Quantity { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        public IWebElement? CloseButton { get; set; }

        //Act
        public bool SelectSize()
        {
            try
            {
                Size?.Click();
                return true;
            }
            
            catch
            {
                return false;
            }

        }
        public void BuyButtonClick()
        {
            ClickBuyButton?.Click();
        }
        public string? GetCartItemUrl()
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            try
            {
                IWebElement cartItem=fluentWait.Until(d => d.FindElement(By.XPath("//*[@id='cartData']/li[1]/div[2]/h2/a")));
                return cartItem.GetAttribute("href");
            }
            catch
            {
                return null;
            }
        }
        public string GetCurrentUrl()
        {
            return driver.Url;
        }
        public void QuantityIncrease()
        {
            int quantity = Convert.ToInt32(Quantity?.GetAttribute("qty")) + 1;
            Quantity?.Click();
            Quantity?.SendKeys(Keys.Delete);
            Quantity?.SendKeys(quantity.ToString());
        }
        public int GetQuantity()
        {
            return Convert.ToInt32(Quantity?.GetAttribute("qty"));
        }
        public void RemoveProductLinkClick()
        {
            RemoveProductLink?.Click();
        }
        public void CloseButtonClick()
        {
            CloseButton?.Click();
        }
    }
}
