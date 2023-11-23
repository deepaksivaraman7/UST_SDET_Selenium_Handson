using BunnyCart.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BunnyCartHomePage
    {
        IWebDriver driver;
        public BunnyCartHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement? FirstNameField { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastNameField { get; set; }

        [FindsBy(How = How.Id, Using = "popup-is_subscribed")]
        private IWebElement? NewsLetterCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "popup-email_address")]
        private IWebElement? EmailInputField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInputField { get; set; }

        [FindsBy(How = How.Id, Using = "password-confirmation")]
        private IWebElement? PasswordConfirmationInputField { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='action submit primary']")]
        private IWebElement? CreateAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign In']")]
        [CacheLookup]
        private IWebElement? SignInLink { get; set; }

        //Act
        public void ClickCreateAccountLink()
        {
            CreateAccountLink?.Click();
        }
        public void SignUp(string firstName,string lastName,string email, string password,string confpassword,string mob)
        {
            //IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));
            FirstNameField?.SendKeys(firstName);
            LastNameField?.SendKeys(lastName);
            EmailInputField?.SendKeys(email);
            CoreCodes.ScrollIntoView(driver, PasswordInputField);
            PasswordInputField?.SendKeys(password);
            PasswordConfirmationInputField?.SendKeys(confpassword);
            CoreCodes.ScrollIntoView(driver, MobileNumberField);
            MobileNumberField?.SendKeys(mob);
            CreateAccountButton?.Click();
        }
        
        public SearchResultsPage TypeSearchInput(string searchText)
        {
            if (SearchInput == null)
            {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput?.SendKeys(searchText);
            SearchInput?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
