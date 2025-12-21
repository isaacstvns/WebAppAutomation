using OpenQA.Selenium;
using WebAppAutomation.Resource;

namespace WebAppAutomation.Tests
{
    [TestClass]
    [TestCategory("BaseTest")]
    public class BaseTest
    {
        protected static IWebDriver Driver => DriverContext.GetDriver();
        public TestContext TestContext { get;  set; }

        [TestInitialize]
        public void SetUpBrowser()
        {
            var factory = new WebDriverFactory();

            IWebDriver intance = factory.Create(BrowserType.Chrome);

            DriverContext.SetDriver(intance);

            // --- VERIFICATION LOGGING ---
            int threadId = Thread.CurrentThread.ManagedThreadId;
            int driverHash = Driver.GetHashCode(); // Unique ID for this specific driver object

            TestContext.WriteLine("***********************************************");
            TestContext.WriteLine($"TEST NAME: {TestContext.TestName}");
            TestContext.WriteLine($"THREAD ID: {threadId}");
            TestContext.WriteLine($"DRIVER HASH: {driverHash}");
            TestContext.WriteLine("***********************************************");

            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }

        [TestCleanup]
        public void TearDown()
        {
            DriverContext.QuitDriver();
        }
    }
}
