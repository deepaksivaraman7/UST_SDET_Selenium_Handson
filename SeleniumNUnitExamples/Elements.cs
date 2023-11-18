using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExamples
{
    internal class Elements : CoreCodes
    {
        [Test]
        public void FormElements()
        {
            Thread.Sleep(2000);
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("John");
            Thread.Sleep(2000);
            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Doe");
            Thread.Sleep(2000);
            IWebElement email = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            email.SendKeys("johndoe@gmail.com");
            Thread.Sleep(2000);
            IWebElement gender = driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            gender.Click();
            Thread.Sleep(2000);
            IWebElement mobileNumber = driver.FindElement(By.Id("userNumber"));
            mobileNumber.SendKeys("8765432145");
            Thread.Sleep(2000);
            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(2000);
            IWebElement dobMonth = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            SelectElement selectMonth = new(dobMonth);
            selectMonth.SelectByValue("5");
            Thread.Sleep(2000);
            IWebElement dobYear = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement selectYear = new(dobYear);
            selectYear.SelectByValue("1998");
            Thread.Sleep(2000);
            IWebElement dobDay = driver.FindElement(By.XPath("//div[@class='react-datepicker__day react-datepicker__day--019']"));
            dobDay.Click();
            Thread.Sleep(2000);
            IWebElement subjectsField = driver.FindElement(By.Id("subjectsInput"));
            subjectsField.SendKeys("Maths");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            subjectsField.SendKeys("Chemi");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement hobbiesRadioButton = driver.FindElement(By.XPath("//label[text()='Sports']"));
            hobbiesRadioButton.Click();
            Thread.Sleep(2000);
            IWebElement uploadPicture = driver.FindElement(By.Id("uploadPicture"));
            uploadPicture.SendKeys("C:\\Users\\Administrator\\Documents\\My Web Sites\\WebSite1\\iis.png");
            Thread.Sleep(2000);
            //IWebElement submitButton = driver.FindElement(By.Id("submit"));
            //submitButton.Click();
            //Thread.Sleep(2000);
        }
        [Test]
        public void TestWindow()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle: " + parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for (int i = 0; i < 3; i++)
            {
                clickElement.Click();
                Thread.Sleep(3000);
            }
            List<string> listWindows = driver.WindowHandles.ToList();
            foreach (string windowHandle in listWindows)
            {
                Console.WriteLine("Switching to window: " + windowHandle);
                driver.SwitchTo().Window(windowHandle);
                Thread.Sleep(2000);
                Console.WriteLine("Navigating to google.com");
                driver.Navigate().GoToUrl("https://www.google.com");
                Thread.Sleep(2000);
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();
        }
        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement element = driver.FindElement(By.Id("alertButton"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text is " + simpleAlert.Text);
            Thread.Sleep(3000);
            simpleAlert.Accept();

            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(3000);
            IAlert confirmationAlert =driver.SwitchTo().Alert();
            Console.WriteLine("Alert text is " + confirmationAlert.Text);
            Thread.Sleep(3000);
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(3000);
            IAlert promptAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text is " + promptAlert.Text);
            Thread.Sleep(3000);
            promptAlert.Accept();

        }
    }
}
