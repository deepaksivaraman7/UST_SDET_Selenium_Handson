using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNUnitExamples
{
    internal class ActionEvents:CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homeLink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdHomeLink = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]"));
            Actions actions = new(driver);
            Action mouseOverHomeLink = ()=>actions.MoveToElement(homeLink).Build().Perform();

            Console.WriteLine("Before: " + tdHomeLink.GetCssValue("background-color"));
            mouseOverHomeLink.Invoke();
            Thread.Sleep(3000);
            Console.WriteLine("After: " + tdHomeLink.GetCssValue("background-color"));

        }
        [Test]
        public void MultipleActionsTest()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com");
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

            Actions actions = new(driver);
            Action upperCaseInput = () => actions.KeyDown(Keys.Shift).SendKeys(emailInput,"hiii").KeyUp(Keys.Shift).Build().Perform();
            upperCaseInput.Invoke();
            Thread.Sleep(3000);

        }
    }
}
