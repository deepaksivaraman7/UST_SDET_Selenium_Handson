using Rediff.PageObjects;
using Rediff.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTests:CoreCodes
    {
        //Asserts
        //[Test,Order(1),Category("Smoke Test")]
        //public void CreateAccountLinkTest()
        //{
        //    var homePage = new RediffHomePage(driver);
        //    driver.Navigate().GoToUrl("https://www.rediff.com");
        //    homePage.CreateAccountLinkClick();
        //    Assert.That(driver.Url.Contains("register"));
        //}
        //[Test,Order(2),Category("Smoke Test")]
        //public void SignInLinkTest()
        //{
        //    var homePage = new RediffHomePage(driver);
        //    driver.Navigate().GoToUrl("https://www.rediff.com");
        //    homePage.SignInLinkClick();
        //    Assert.That(driver.Url.Contains("login"));
        //}
        [Test, Order(1), Category("Regression Test")]
        public void CreateAccountTest()
        {
            var homePage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/")) ;
            {
                driver.Navigate().GoToUrl("https://www.rediff.com");
            }
            Thread.Sleep(3000);
            var createAccountPage=homePage.CreateAccountClick();
            Thread.Sleep(2000);
            createAccountPage.FullNameType("aaaggdd");
            createAccountPage.RediffMailType("aaaggdd");
            createAccountPage.CheckAvailabilityClick();
            Thread.Sleep(2000);
            createAccountPage.CreateAccountButtonClick();
        }
        [Test, Order(2), Category("Regression Test")]
        public void SignInTest()
        {
            var homePage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/")) ;
            {
                driver.Navigate().GoToUrl("https://www.rediff.com");
            }
            Thread.Sleep(3000);
            var signInPage = homePage.SignInClick();
            Thread.Sleep(2000);
            signInPage.UserNameType("aaaggdd");
            signInPage.PasswordType("aaaggdd");
            signInPage.RememberMeClick();
            Assert.False(signInPage.RememberMeCheckBox.Selected);
            signInPage.SignInClick();
            Thread.Sleep(2000);
        }
    }
}
