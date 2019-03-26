using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZenView;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZenView.Tests.Selenium
{
    [TestClass]
    public class SeleniumTests
    {
        [TestMethod]
        public void SeleniumTrial()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://zenview.azurewebsites.net/");
            driver.FindElement(By.Id("signalRbtn")).Click();
        }

    }
}