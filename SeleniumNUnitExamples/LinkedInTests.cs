using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    [TestFixture]
    internal class LinkedInTests : CoreCodes
    {
        [Test, Category("Regression testing"), Author("Deepak", "ust1.com"), Description("Check for valid login")]
        public void Login1Test()
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //WebDriverWait wait=new(driver,TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            //IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            //IWebElement emailInput = wait.Until(d=>d.FindElement(By.Id("session_key")));
            //IWebElement passwordInput = wait.Until(d => d.FindElement(By.Id("session_password")));
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys("email@ust.com");
            passwordInput.SendKeys("password");

        }
        //[Test]
        //[Author("Deepak", "ust2.com")]
        //[Description("Check for invalid login")]
        //[Category("Smoke testing")]
        //public void LoginTestWithInvalidCred()
        //{
        //DefaultWait<IWebDriver> fluentWait = new(driver);
        //fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element not found";

        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
        //IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

        //    emailInput.SendKeys("email@ust.com");
        //    passwordInput.SendKeys("password");
        //    Thread.Sleep(2000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);

        //    emailInput.SendKeys("second@ust.com");
        //    passwordInput.SendKeys("password2");
        //    Thread.Sleep(2000);
        //ClearForm(emailInput);
        //ClearForm(passwordInput);
        ////}
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }

        //[Test]
        //[Author("Deepak3", "ust3.com")]
        //[Description("Check for invalid login")]
        //[Category("Regression testing")]
        //[TestCase("zero@ust.com","password")]
        //[TestCase("second@ust.com","password2")]
        //[TestCase("third@ust.com","password3")]
        //public void LoginWithInvalidCred(string email,string password)
        //{
        //    DefaultWait<IWebDriver> fluentWait = new(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element not found";

        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
        //    IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

        //    emailInput.SendKeys(email);
        //    passwordInput.SendKeys(password);
        //    Thread.Sleep(3000);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);
        //    Thread.Sleep(3000);
        //}

        [Test]
        [Author("Deepak3", "ust3.com")]
        [Description("Check for invalid login")]
        [Category("Regression testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void LoginWithInvalidCred(string email, string password)
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);

            TakeScreenshot();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", driver.FindElement(By.XPath("//button[@type='submit']")));

            js.ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//button[@type='submit']")));

            //ClearForm(emailInput);
            //ClearForm(passwordInput);
            Thread.Sleep(5000);
        }
        static object[] InvalidLoginData()
        {
            return new object[] { 
                new object[] { "zero@ust.com", "password" },
                //new object[] { "first@ust.com", "password1" }
                };
        }
        
    }
}
