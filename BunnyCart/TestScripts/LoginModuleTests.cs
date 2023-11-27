using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class LoginModuleTests:CoreCodes
    {
        //[Test]
        //public void CreateAccountTest()
        //{
        //    string currDir = Directory.GetParent("../../../").FullName;
        //    string logFileilePath = currDir + "/Logs/Log_" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".txt";
        //    Log.Logger = new LoggerConfiguration()
        //        .WriteTo.Console()
        //        .WriteTo.File(logFileilePath, rollingInterval: RollingInterval.Day)
        //        .CreateLogger();
        //    BunnyCartHomePage bchp = new(driver);
        //    Log.Information("Create account test started");
        //    bchp.ClickCreateAccountLink();
        //    Log.Information("Create account link clicked");

        //    Thread.Sleep(2000);

        //    try
        //    {
        //        //Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
        //        Assert.IsTrue(driver?.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text == "Create an account", $"Test failed for Create Account");
        //        Log.Information("Test passed for Create Account");
        //        test = extent.CreateTest("Create Account Link test - Passed");
        //        test.Pass("Create Account Link Success");
        //    }
        //    catch(Exception ex)
        //    {
        //        Log.Error($"Test failed for Create Account.\nException:{ex.Message}");
        //        test = extent.CreateTest("Create Account Link test - Failed");
        //        test.Fail("Create Account Link Failed");

        //    }
        //    string? excelFilePath = currDir + "/TestData/InputData.xlsx";
        //    string? sheetName = "CreateAccount";
        //    List<CreateAccount> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
        //    foreach(var excelData in excelDataList)
        //    {
        //        string? firstName=excelData.FirstName;
        //        string? lastName=excelData.LastName;
        //        string? email=excelData.Email;
        //        string? password=excelData.Password;
        //        string? confirmPassword=excelData.ConfirmPassword;
        //        string? mobileNumber=excelData.MobileNumber;
        //        bchp.SignUp(firstName, lastName, email, password, confirmPassword, mobileNumber);
        //    }
        //    Log.CloseAndFlush();
        //}
        [Test]
        public void CreateAccountTest()
        {
            string currDir = Directory.GetParent("../../../").FullName;
            string logFileilePath = currDir + "/Logs/Log_" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logFileilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            BunnyCartHomePage bchp = new(driver);
            Log.Information("Create account test started");
            bchp.ClickCreateAccountLink();
            Log.Information("Create account link clicked");

            Thread.Sleep(2000);

            try
            {
                //Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                Assert.IsTrue(driver?.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text == "Create an account", $"Test failed for Create Account");
                LogTestResult("Create Account Link Test","Create Account Link success");
            }
            catch (Exception ex)
            {
                LogTestResult("Create Account Link Test", "Create Account Link failed",ex.Message);

            }
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";
            List<CreateAccount> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            {
                string? firstName = excelData.FirstName;
                string? lastName = excelData.LastName;
                string? email = excelData.Email;
                string? password = excelData.Password;
                string? confirmPassword = excelData.ConfirmPassword;
                string? mobileNumber = excelData.MobileNumber;
                bchp.SignUp(firstName, lastName, email, password, confirmPassword, mobileNumber);
            }
            Log.CloseAndFlush();
        }
    }
}
