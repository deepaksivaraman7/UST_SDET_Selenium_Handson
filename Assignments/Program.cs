using Assignments;
using NUnit.Framework;
//1

//AHPTests aHPTests = new(); //Creating object for AHPTests
//    try
//    {
//      aHPTests.InitializeChromeDriver(); //Initializing chrome driver using method
//      aHPTests.AmazonTitleTest(); //Testing the title of the webpage after loading
//      aHPTests.OrgTypeTest(); //Testing the organization type from the URL of the webpage after loading
//    }
//    catch (AssertionException ex)
//    {
//        Console.WriteLine("Test failed");
//        Console.WriteLine(ex.Message); //Errors are displayed here
//    }
//aHPTests.Destruct(); //Closing the webdriver

//2

NavigateTests navigateTests = new(); //Creating object for AHPTests
try
{
    navigateTests.InitializeChromeDriver(); //Initializing chrome driver using method
    navigateTests.NavigateTest(); //Testing the navigation between pages and search in google
}
catch (AssertionException ex)
{
    Console.WriteLine("Test failed");
    Console.WriteLine(ex.Message); //Errors are displayed here
}
navigateTests.Destruct(); //Closing the webdriver