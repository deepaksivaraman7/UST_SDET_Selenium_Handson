using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class CreateAccountPage
    {
        IWebDriver driver;
        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'name')]")]
        public IWebElement? FullNameText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'login')]")]
        public IWebElement? RediffMailText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnchkavail')]")]
        public IWebElement? CheckAvailabilityButton { get; set; }

        [FindsBy(How = How.Id, Using = "Register")]
        public IWebElement? CreateAccountButton { get; set; }

        //Act
        public void FullNameType(string name)
        {
            FullNameText?.SendKeys(name);
        }
        public void FullNameClear(string name)
        {
            FullNameText?.Clear();
        }
        public void RediffMailType(string mail)
        {
            RediffMailText?.SendKeys(mail);
        }
        public void RediffMailClear(string name)
        {
            RediffMailText?.Clear();
        }
        public void CheckAvailabilityClick() 
        { 
            CheckAvailabilityButton?.Click();
        }
        public void CreateAccountButtonClick()
        {
            CreateAccountButton?.Click();
        }
    }
}
