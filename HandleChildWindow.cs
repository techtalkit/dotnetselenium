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
    public class HandleChildWindow
    {
        public IWebDriver driver;
        static String[] trimmedString;
        static String[] splittedtext;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
            this.driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void testHandleChildWindow()
        {
            String email = "mentor@rahulshettyacademy.com";
            String parentWindowId = driver.CurrentWindowHandle;
            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.AreEqual(2,driver.WindowHandles.Count);
            IList<String> allwindows = driver.WindowHandles;
            foreach (String window in allwindows)
            {
                driver.SwitchTo().Window(window);
                if (driver.Title == "RS Academy") {
                    TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
                    String text = driver.FindElement(By.CssSelector(".red")).Text;
                    splittedtext=text.Split("at");
                    trimmedString=splittedtext[1].Trim().Split(' ');
                    Assert.AreEqual(email, trimmedString[0]);
                    break;
                }
            }
            driver.SwitchTo().Window(parentWindowId);
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeys(trimmedString[0]);


        }
        [TearDown]
        public void tearDownBrowser()
        {
            driver.Quit();
        }
    }
}
