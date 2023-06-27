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
    public class AutoSuggestDropDown
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
        public void test_Dropdowns()
        {
            driver.FindElement(By.XPath("//input[@id='autocomplete']")).SendKeys("ind");
            IList<IWebElement> options=driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India")) { 
                      option.Click();
                      break;
                }
            }
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("#autocomplete")).GetAttribute("value"));
        }
    }
}
