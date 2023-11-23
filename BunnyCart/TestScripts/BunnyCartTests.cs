using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTests : CoreCodes
    {
        [Test]
        public void SignUpTest()
        {
            BunnyCartHomePage bchp = new(driver);
            bchp.ClickCreateAccountLink();
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                bchp.SignUp("John", "Doe", "johndoe@gmail.com", "12345678", "12345678", "9876543210");
            }
            catch (AssertionException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //[Test]
        //public void SignInTest()
        //{
        //    BunnyCartHomePage bchp = new(driver);
        //    bchp.ClickCreateAccountLink();
        //    try
        //    {
        //        bchp.SignUp("John", "Doe", "johndoe@gmail.com", "12345678", "12345678", "9876543210");
        //    }
        //    catch (AssertionException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}
