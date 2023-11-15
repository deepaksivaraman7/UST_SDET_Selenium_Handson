using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExamples
{
    internal class AmazonTests
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title test - Passed");
        }
        public void LogoClickTest()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logo Click test - Passed");
        }
        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That("Amazon.com : mobiles".Equals(driver.Title)&&driver.Url.Contains("mobiles"));
            Console.WriteLine("Search Product test - Passed");
        }
        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(3000);

        }
        public void TodaysDealsTest()
        {
            IWebElement todaysdeals=driver.FindElement(By.LinkText("Today's Deals"));
            if (todaysdeals == null)
            {
                throw new NoSuchElementException("Today's Deals link not present");
            }
            else
            {
                todaysdeals.Click();
                Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
                Console.WriteLine("Todays deals test - Passed");
            }
        }
        public void SignInAccListTest()
        {
            IWebElement helloSignIn = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(helloSignIn == null)
            {
                throw new NoSuchElementException("Hello, Signin not present");
            }
            IWebElement accountandlists = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if (accountandlists == null)
            {
                throw new NoSuchElementException("Hello, Account and lists not present");
            }
            Assert.That(helloSignIn.Text.Equals("Hello, sign in"));
            Console.WriteLine("Hello, Signin present - Passed");
            Assert.That(accountandlists.Text.Equals("Account & Lists"));
            Console.WriteLine("Hello, Account and lists - Passed");
        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That("Amazon.com : mobile phones".Equals(driver.Title));
            Thread.Sleep(2000);
            IWebElement motoCheckBox = driver.FindElement(By.XPath("//*[@id='p_89/Motorola']/span/a/div/label/i"));
            motoCheckBox.Click();
            Thread.Sleep(2000);
            IWebElement mcheckbox = driver.FindElement(By.XPath("//*[@id='p_89/Motorola']/span/a/div/label/input"));
            Assert.True(mcheckbox.Selected);
            Console.WriteLine("Motorola is selected");
            driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            Thread.Sleep(2000);

            IWebElement appleCheckBox = driver.FindElement(By.XPath("//*[@id='p_89/Apple']/span/a/div/label/i"));
            appleCheckBox.Click();
            Thread.Sleep(2000);
            IWebElement acheckbox = driver.FindElement(By.XPath("//*[@id='p_89/Apple']/span/a/div/label/input"));

            Assert.True(acheckbox.Selected);
            Console.WriteLine("Apple is selected");
        }
        public void SortBySelectTest()
        {
            IWebElement sortby = driver.FindElement(By.ClassName("a-native-dropdown"));
            SelectElement sortbyselect = (SelectElement)sortby;
            sortbyselect.SelectByValue("1");
            Thread.Sleep(2000);
            Console.WriteLine(sortbyselect.SelectedOption);
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
