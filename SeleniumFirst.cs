using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using WebDriverManager.Helpers;
using WebDriverManager.DriverConfigs;
using OpenQA.Selenium.Edge;

namespace TestProject1
{
    public class SeleniumFirst
        
    {
        public IWebDriver driver;
        [SetUp]
        public void startBrowser() {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void test()
        {
            this.driver.Url = "https://rahulshettyacademy.com/";
            TestContext.Progress.WriteLine(this.driver.Title);
            TestContext.Progress.WriteLine(this.driver.Url);
            //TestContext.Progress.WriteLine(this.driver.PageSource); 
            this.driver.Close();

        }
        [TearDown] 
        public void tearDownBrowser() { 
        
        }
    }
}
