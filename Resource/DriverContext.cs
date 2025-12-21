using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAppAutomation.Resource
{
    public class DriverContext
    {
        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();


        public static IWebDriver GetDriver() => _driver.Value;

        public static void SetDriver(IWebDriver driver) => _driver.Value = driver;

        public static void QuitDriver()
        {
            if (_driver.Value != null)
            {
                _driver.Value.Quit();
                _driver.Value.Dispose();
                _driver.Value = null;
            }
        }
    }
}
