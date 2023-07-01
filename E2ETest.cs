using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class E2ETest
    {
        public IWebDriver driver;

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
        public void EndToEndFlow() {
            String[] expectedproducts = {"iphone X","Nokia Edge"};
            String[] actualproducts = new string[2];
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group']//child::label[@for='terms']//child::span//child::input")).Click();
            driver.FindElement(By.Name("signin")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            IList<IWebElement> products=  driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {
                if (expectedproducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text)) {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }
            Thread.Sleep(3000);
            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            IList<IWebElement> checkoutelem=driver.FindElements(By.CssSelector("h4 a"));
            for(int i=0;i<checkoutelem.Count;i++)
            {
                actualproducts[i] = checkoutelem[i].Text;
            }
            Assert.AreEqual(expectedproducts, actualproducts);

        }
    }
}
