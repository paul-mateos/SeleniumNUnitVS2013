using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumNUnitVS2013
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();    
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }
        
        [Test]
        public void GoogleSearch()
        {

            driver.Navigate().GoToUrl("http://www.google.com.au");
            
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Selenium");
            query.Submit();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until((d) => { return d.Title.StartsWith("Selenium"); });

            Assert.AreEqual("Selenium - Google Search", driver.Title);

        }
    }
}
