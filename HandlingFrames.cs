using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1
{
    public class HandlingFrames
    {
        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
            this.driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void test_HandleFrame() {
            //Frame where we need to operate
            IWebElement framescroll=driver.FindElement(By.Id("courses-iframe"));

            //scroll to frame by javascriptexecutor
            IJavaScriptExecutor js=(IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",framescroll);

            //id,name,index
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            //Switch to the parent window
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        }
    }
}
