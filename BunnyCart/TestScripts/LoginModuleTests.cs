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
    internal class LoginModuleTests:CoreCodes
    {
        [Test]
        public void CreateAccountTest()
        {
            BunnyCartHomePage bchp = new(driver);
            bchp.ClickCreateAccountLink();
            Thread.Sleep(2000);

            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                test = extent.CreateTest("Create Account Link test - Passed");
                test.Pass("Create Account Link Success");
            }
            catch
            {
                test = extent.CreateTest("Create Account Link test - Failed");
                test.Fail("Create Account Link Failed");

            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";
            List<CreateAccount> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach(var excelData in excelDataList)
            {
                string? firstName=excelData.FirstName;
                string? lastName=excelData.LastName;
                string? email=excelData.Email;
                string? password=excelData.Password;
                string? confirmPassword=excelData.ConfirmPassword;
                string? mobileNumber=excelData.MobileNumber;
                bchp.SignUp(firstName, lastName, email, password, confirmPassword, mobileNumber);
            }
        }
    }
}
