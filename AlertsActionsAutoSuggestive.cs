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
    public class AlertsActionsAutoSuggestive
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
        public void test_ALert() {
            String name = "shafaat";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onClick *='displayConfirm']")).Click();
            String alertText=driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            //Below are the method which we use to dismiss the alert and write text
            //driver.SwitchTo().Alert().Dismiss();
            //driver.SwitchTo().Alert().SendKeys(alertText);
            StringAssert.Contains(name,alertText);
        }
    }
}
