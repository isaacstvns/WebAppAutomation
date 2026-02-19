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
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME");
            string password = Environment.GetEnvironmentVariable("VALID_PASSWORD");
            LoginPage.ValidUserLogin(username, password);
        }

        [TestMethod]
        public void Login_InValidLogin()
        {
            LoginPage = new LoginPage(Driver);
            string username = Environment.GetEnvironmentVariable("VALID_USERNAME");
            string invalidPassword = Environment.GetEnvironmentVariable("INVALID_PASSWORD");
            LoginPage.InValidUserLogin(username, invalidPassword);
        }
    }
}
