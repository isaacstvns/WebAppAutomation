using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebAppAutomation.Resource;

namespace WebAppAutomation.Tests
{
    [TestClass]
    [TestCategory("BaseTest")]
    public class BaseTest
    {
        protected IWebDriver Driver {  get;  set; }
        public TestContext TestContext { get;  set; }

        [TestInitialize]
        public void SetUpBrowser()
        {
            var factory = new WebDriverFactory();

            Driver = factory.Create(BrowserType.Chrome);

            //var url = TestContext.Properties["webAppUrl"].ToString();
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }
        
        [TestCleanup]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
