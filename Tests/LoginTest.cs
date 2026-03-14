using WebAppAutomation.Pages;

namespace WebAppAutomation.Tests
{
	[TestClass]
	[TestCategory("LoginTests")]
	public class LoginTest : BaseTest
	{
		LoginPage LoginPage;

		[TestMethod]
		public void Login_ValidLogin()
		{
			LoginPage = new LoginPage(Driver);
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME") ?? "Admin";
            string password = Environment.GetEnvironmentVariable("VALID_PASSWORD") ?? "admin123";
            LoginPage.ValidUserLogin(username, password);
        }

        [TestMethod]
        public void Login_InValidLogin()
        {
            LoginPage = new LoginPage(Driver);
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME") ?? "Admin";
            string invalidPassword = Environment.GetEnvironmentVariable("INVALID_PASSWORD") ?? "admin125";
            LoginPage.InValidUserLogin(username, invalidPassword);
        }
    }
}
