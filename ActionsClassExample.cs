using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace TestProject1
{
    public class ActionsClassExample
    {
        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
            this.driver.Url = "https://demoqa.com/droppable";
        }
        [Test]
        public void test_DragAndDrop() {
            Actions a = new Actions(driver);
            IWebElement draggable = driver.FindElement(By.XPath("//div[@id='draggable']"));
            IWebElement droppable = driver.FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='droppable']"));
            Thread.Sleep(3000);
            a.DragAndDrop(draggable, droppable).Perform();
            Thread.Sleep(3000);
        }
        [TearDown]
        public void tearDownBrowser()
        {
            driver.Quit();
        }
    }
}
