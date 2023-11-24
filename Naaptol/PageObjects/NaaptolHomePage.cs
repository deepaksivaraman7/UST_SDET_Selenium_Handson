using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class NaaptolHomePage
    {
        IWebDriver driver;
        public NaaptolHomePage(IWebDriver? driver) 
        { 
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How=How.Id,Using= "header_search_text")]
        public IWebElement? SearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='header_search_text']//following::div")]
        public IWebElement? SearchButton { get; set; }

        //Act
        
        public void SearchProductType(string product)
        {
            SearchBar?.SendKeys(product);
        }
        public ProductsPage SearchButtonClick()
        {
            SearchButton?.Click();
            return new ProductsPage(driver);
        }
        public void ProductSelect(string position)
        {
            driver.FindElement(By.Id("productItem" + position)).Click();
        }
        public void ClearSearchBar()
        {
            SearchBar?.Clear();
        }
    }
}
