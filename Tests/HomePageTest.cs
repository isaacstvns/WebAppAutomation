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
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME") ?? "Admin";
            string password = Environment.GetEnvironmentVariable("VALID_PASSWORD") ?? "admin123";
            LoginPage.ValidUserLogin(username, password);
            HomePage.TestContext = TestContext;
            HomePage.VerifyQuickLaunchItems();
        }

        [TestMethod]
        public void VerifyAdminPageTitle()
        {
            LoginPage = new LoginPage(Driver);
            HomePage = new HomePage(Driver);
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME") ?? "Admin";
            string password = Environment.GetEnvironmentVariable("VALID_PASSWORD") ?? "admin123";
            LoginPage.ValidUserLogin(username, password);
            HomePage.navigateToAdmin();
            HomePage.validateAdminPageTitle();
        }

        [TestMethod]
        public void VerifyPIMPageTitle()
        {
            LoginPage = new LoginPage(Driver);
            HomePage = new HomePage(Driver);
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME") ?? "Admin";
            string password = Environment.GetEnvironmentVariable("VALID_PASSWORD") ?? "admin123";
            LoginPage.ValidUserLogin(username, password);
            HomePage.navigateToPIM();
            HomePage.validatePIMPageTitle();
        }

        [TestMethod]
        public void VerifyLeavePageTitle()
        {
            LoginPage = new LoginPage(Driver);
            HomePage = new HomePage(Driver);
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME") ?? "Admin";
            string password = Environment.GetEnvironmentVariable("VALID_PASSWORD") ?? "admin123";
            LoginPage.ValidUserLogin(username, password);
            HomePage.navigateToLeave();
            HomePage.validateLeavePageTitle();
        }
    }
}
