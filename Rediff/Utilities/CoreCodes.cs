﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.Utilities
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties; //Declaring
        public IWebDriver? driver;
        public void ReadConfigSettings()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            properties = new(); //Initializing
            string fileName = currDir + "/configsettings/config.properties";
            string[] lines=File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using(var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public void TakeScreenshot()
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot ss = ts.GetScreenshot();
            string currDir = Directory.GetParent("../../../").FullName;
            string filePath = currDir + "/Screenshots/Screenshot_" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".png";
            ss.SaveAsFile(filePath);
        }
        [OneTimeSetUp]
        public void InitializeBrowser() 
        {
            ReadConfigSettings();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown] 
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
