using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAppAutomation.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver) 
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; set; }


        public void ClickElement(By locator, int timeoutInSeconds = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator)).Click();
            }
            catch
            {
                throw new TimeoutException($"WaaitForElementClickable timed out after {timeoutInSeconds} seconds. ");
            }
        }

        public void EnterText(By locator, string value, int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator)).SendKeys(value);
        }

        public string GetText(By locator, int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Text;
        }

        public List<string> ReturnListofItems(By locator, int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return Driver.FindElements(locator)
                         .Select(el => el.Text.Trim())
                         .ToList();
        }
    }
}
