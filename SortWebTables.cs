using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace TestProject1
{
    public class SortWebTables
    {
        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
            this.driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void SortTable() {
            ArrayList a=new ArrayList();
            IWebElement dropdown = driver.FindElement(By.Id("page-menu"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue("20");
            //Step 1: Select all the colum elements in the ArrayList
            IList<IWebElement> veggies=driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }
            //Step 2: Sort this array list in expected arraylist
            TestContext.Progress.WriteLine("**********Before Sorting**********");
            foreach (String elem in a)
            {
                TestContext.Progress.WriteLine(elem);
            }
            a.Sort();
            TestContext.Progress.WriteLine("**********After Sorting**********");
            foreach (String elem in a)
            {
                TestContext.Progress.WriteLine(elem);
            }
            //Step 3: Go and Click the cloumn header
            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();
            //Steap 4: Grab all the elements in actualList
            ArrayList b = new ArrayList();
            IList<IWebElement> SortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in SortedVeggies)
            {
                b.Add(veggie.Text);
            }
            //Step 5: Compare the expectedList and actualList if they are equal
            Assert.AreEqual(a,b);
        }
    }
}
