using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace ZenView.Tests.Selenium
{
    [TestClass]
    public class SeleniumTests
    {
        private IWebDriver driver;
        private string appURL;


        [TestMethod]
        public void SeleniumNavigateAbout()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.LinkText("About")).Click();
            Assert.AreEqual(driver.Title, "About - ZenView");
        }
        
        [TestMethod]
        public void SeleniumNavigateContact()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.LinkText("Contact")).Click();
            Assert.AreEqual(driver.Title, "Contact - ZenView");
        }

        [TestMethod]
        public void SeleniumNavigateRegister()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.LinkText("Register")).Click();
            Assert.AreEqual(driver.Title, "Register - ZenView");
        }

        [TestMethod]
        public void SeleniumNavigateLogin()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.LinkText("Log in")).Click();
            Assert.AreEqual(driver.Title, "Log in - ZenView");
        }

        [TestMethod]
        public void SeleniumExecuteMainInit()
        {
            driver.Navigate().GoToUrl(appURL);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("return console.log(Main.Init())");
        }
        
        [TestInitialize()]
        public void Selenium()
        {
            appURL = "https://zenview.azurewebsites.net/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "Chrome":
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }


        [TestCleanup()]
        public void SeleniumCleanUp()
        {
            driver.Quit();
        }

    }
}