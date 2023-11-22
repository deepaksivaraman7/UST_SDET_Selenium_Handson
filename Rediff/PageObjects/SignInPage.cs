using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class SignInPage
    {
        IWebDriver driver;
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.Id, Using = "login1")]
        public IWebElement? UserName { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement? Password { get; set; }

        [FindsBy(How = How.Id, Using = "remember")]
        public IWebElement? RememberMeCheckBox { get; set; }

        [FindsBy(How = How.Name, Using = "proceed")]
        public IWebElement? SignInButton { get; set; }

        //Act
        public void UserNameType(string name)
        {
            UserName?.SendKeys(name);
        }
        public void PasswordType(string name)
        {
            Password?.SendKeys(name);
        }
        public void RememberMeClick()
        {
            RememberMeCheckBox?.Click();
        }
        public void SignInClick()
        {
            SignInButton?.Click();
        }

    }
}
