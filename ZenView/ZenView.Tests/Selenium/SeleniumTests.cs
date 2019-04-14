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

        //[TestMethod]
        //public void SeleniumExecuteMainInit()
        //{
        //    driver.Navigate().GoToUrl(appURL);
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    js.ExecuteScript("return console.log(Main.Init())");
        //}
        
        [TestInitialize()]
        public void Selenium()
        {
            appURL = "https://zenview-staging.azurewebsites.net/";

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