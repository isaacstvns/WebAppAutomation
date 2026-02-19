using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppAutomation.Pages;

namespace WebAppAutomation.Tests
{
    [TestClass]
    [TestCategory("HomePageTest")]
    public class HomePageTest : BaseTest
    {
        LoginPage LoginPage;
        HomePage HomePage;

        [TestMethod]
        public void VerifyQuickLaunchItems()
        {
            LoginPage = new LoginPage(Driver);
            HomePage = new HomePage(Driver);
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME");
            string password = Environment.GetEnvironmentVariable("VALID_PASSWORD");
            LoginPage.ValidUserLogin(username, password);
            HomePage.TestContext = TestContext;
            HomePage.VerifyQuickLaunchItems();
        }
    }
}
