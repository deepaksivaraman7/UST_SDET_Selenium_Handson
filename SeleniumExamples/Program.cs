using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver=new ChromeDriver();
driver.Url = "https://www.google.com/";
Thread.Sleep(5000);
string title = "Google";
try
{
    Assert.AreEqual("Google", title);
    Console.WriteLine("Test passed");
}
catch (AssertionException ex)
{
    Console.WriteLine(ex.Message);
}
driver.Close();