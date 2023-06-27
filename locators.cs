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
    public class locators
    {
        public IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            this.driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void LocatorsIdentification()
        {

            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("123456");
            driver.FindElement(By.XPath("//input[@type='radio' and @value='admin']")).Click();
            driver.FindElement(By.XPath("//div[@class='form-group']//child::label[@for='terms']//child::span//child::input")).Click();
            driver.FindElement(By.Name("signin")).Click();
            Thread.Sleep(3000);
            IWebElement SigninBtn = driver.FindElement(By.Name("signin"));
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(SigninBtn,"Sign In"));
            String errorMessage=driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);
            //Thread.Sleep(3000);
            IWebElement link=driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String linkattribute=link.GetAttribute("href");
            String expectedurl = "https://rahulshettyacademy.com/documentsrequest";
            Assert.AreEqual(expectedurl, linkattribute);
            TestContext.Progress.WriteLine(linkattribute);
        }
        [TearDown]
        public void tearDownBrowser()
        {
            this.driver.Close();
        }
    }
}
