using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class ProductsPage
    {
        IWebDriver driver;
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        //[FindsBy(How = How.Id, Using = "productItem5")]
        //public IWebElement? Product { get; set; }



        //Act
        public void ProductSelect(string position)
        {
            driver.FindElement(By.Id("productItem" + position)).Click();
        }
        

    }
}
