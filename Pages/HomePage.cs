using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAppAutomation.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }
        public TestContext TestContext { get; set; }

        /* Elments Starts Here */
        private By quick_launch_items => By.XPath("//div[@class='orangehrm-quick-launch-heading']");

        /* Elments Ends Here */

        internal void VerifyQuickLaunchItems()
        {
            var actualLabels = ReturnListofItems(quick_launch_items);
            Assert.IsTrue(actualLabels.Count > 0, "Quick Launch Items are not displayed");
            //string labelsCsv = TestContext?.Properties["quickLaunchLabels"]?.ToString();
            string labelsCsv = "Assign Leave,Leave List,Timesheets,Apply Leave,My Leave,My Timesheetxxx";
            string[] expectedLabels = labelsCsv?.Split(',') ?? Array.Empty<string>();
            CollectionAssert.AreEqual(expectedLabels, actualLabels, "Quick Launch labels do not match");
        }
    }
}
