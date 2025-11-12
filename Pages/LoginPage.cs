using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebAppAutomation.Pages;

namespace WebAppAutomation.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public TestContext TestContext { get; set; }

        /* Elments Starts Here */
        private By usernmame_box => By.XPath("//input[@name='username']");
        private By password_box => By.XPath("//input[@name='password']");
        private By login_btn => By.XPath("//button[text()=' Login ']");
        private By os_version => By.XPath("//p[text()='OrangeHRM OS 5.7']");
        private By dashboard_text => By.XPath("//h6[text()='Dashboard']");
        private By invalid_cred_msg => By.XPath("//p[text()='Invalid credentials']");
        /* Elments Ends Here */

        internal void UserLoginFlow(string username, string password){
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(90));
            wait.Until(ExpectedConditions.ElementIsVisible(usernmame_box));
            wait.Until(ExpectedConditions.ElementIsVisible(os_version));

            EnterText(usernmame_box, username);
            EnterText(password_box, password);
            ClickElement(login_btn);
        }
        internal void ValidUserLogin(string username, string password)
        {
            UserLoginFlow(username, password);
            Assert.AreEqual(GetText(dashboard_text), "Dashboard", "Dashboard Title Not Macthing");
        }

        internal void InValidUserLogin(string username, string password)
        {
            UserLoginFlow(username, password);
            Assert.AreEqual(GetText(invalid_cred_msg), "Invalid credentials", "Incorrect Invalid Credentials Error Message");
        }

    }
}