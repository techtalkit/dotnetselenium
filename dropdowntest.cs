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
  
    internal class dropdowntest
    {
        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            this.driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void dropdown() {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByText("Teacher");
            Thread.Sleep(3000);
            select.SelectByValue("consult");
            Thread.Sleep(3000);
            select.SelectByIndex(2);
            Thread.Sleep(3000);
            IList<IWebElement> rdos=driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement rd in rdos)
            {
                if (rd.GetAttribute("value").Equals("user")) {
                    rd.Click();
                    break;
                }
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn"))).Click();
            Boolean result = driver.FindElement(By.Id("usertype")).Selected;
            Assert.That(result, Is.True);

        }
    }
}
