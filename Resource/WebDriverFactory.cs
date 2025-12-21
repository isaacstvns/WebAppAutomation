using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace WebAppAutomation.Resource
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.Edge:
                    return GetEdgeDriver();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), "No such browser exist");
            }
        }
        private IWebDriver GetChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), "MatchingBrowser");

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-dev-shm-usage");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless=new");
            //bool headless = string.Equals(System.Environment.GetEnvironmentVariable("headless_mode"), "true", System.StringComparison.OrdinalIgnoreCase);

            //if (headless)
            //{
            //    options.AddArgument("--headless=new");
            //}
            return new ChromeDriver(options);
        }

        private IWebDriver GetEdgeDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig(), "MatchingBrowser");

            EdgeOptions options = new EdgeOptions();
            options.AddArgument("--disable-dev-shm-usage");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddArgument("--start-maximized");

            bool headless = string.Equals(System.Environment.GetEnvironmentVariable("headless_mode"), "true", System.StringComparison.OrdinalIgnoreCase);

            if (headless)
            {
                options.AddArgument("--headless=new");
            }
            return new EdgeDriver(options);
        }
    }
}
