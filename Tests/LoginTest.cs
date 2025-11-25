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
			//LoginPage.ValidUserLogin(TestContext.Properties["username"].ToString(), TestContext.Properties["password"].ToString());
            LoginPage.ValidUserLogin("Admin", "admin123");
        }

        [TestMethod]
        public void Login_InValidLogin()
        {
            LoginPage = new LoginPage(Driver);
           // LoginPage.InValidUserLogin(TestContext.Properties["username"].ToString(), TestContext.Properties["invalidpassword"].ToString());
            LoginPage.InValidUserLogin("Admin", "admin1234");
        }
    }
}
