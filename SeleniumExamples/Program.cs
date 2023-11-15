using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExamples;

//GHPTests gHPTests=new GHPTests();
//List<string> drivers = new()
//{
//    "Edge","Chrome"
//};
//foreach (string driver in drivers)
//{
//    switch (driver)
//    {
//        case "Edge":
//            gHPTests.InitializeEdgeDriver();
//            break;
//        case "Chrome":
//            gHPTests.InitializeChromeDriver();
//            break;
//    }
//    try
//    {
//        gHPTests.TitleTest();
//        gHPTests.PageSourceAndUrlTest();
//        gHPTests.GoogleSearchTest();
//        gHPTests.GmailLinkTest();
//        gHPTests.ImagesLinkTest();
//        gHPTests.LocalizationTest();
//        gHPTests.GAppYoutubeTest();
//    }
//    catch (AssertionException ex)
//    {
//        Console.WriteLine("Test failed");
//        Console.WriteLine(ex.Message);
//    }
//    gHPTests.Destruct();
//}

//15-11-2023

AmazonTests amazonTests = new();
amazonTests.InitializeChromeDriver();
try
{
    amazonTests.TitleTest();
    amazonTests.LogoClickTest();
    amazonTests.SearchProductTest();
    amazonTests.ReloadHomePage();
    amazonTests.TodaysDealsTest();
    amazonTests.SignInAccListTest();
    amazonTests.ReloadHomePage();
    amazonTests.SearchAndFilterProductByBrandTest();
    amazonTests.SortBySelectTest();
}
catch (AssertionException ex)
{
    Console.WriteLine("Test failed");
    Console.WriteLine(ex.Message);
}
amazonTests.Destruct();
