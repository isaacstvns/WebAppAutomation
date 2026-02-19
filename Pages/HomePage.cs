using OpenQA.Selenium;

namespace WebAppAutomation.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }
        public TestContext TestContext { get; set; }

        /* Elments Starts Here */
        private By quick_launch_items => By.XPath("//div[@class='orangehrm-quick-launch-heading']");

        private By menu_item_admin => By.XPath("(//a[@class='oxd-main-menu-item'])[1]");

        private By menu_item_PIM => By.XPath("(//a[@class='oxd-main-menu-item'])[2]");

        private By menu_item_leave => By.XPath("(//a[@class='oxd-main-menu-item'])[3]");

        private By admin_page_title => By.XPath("//h6[@class='oxd-text oxd-text--h6 oxd-topbar-header-breadcrumb-module']");

        private By pim_page_title => By.XPath("//span[@class='oxd-topbar-header-breadcrumb']");

        private By leave_page_title => By.XPath("//span[@class='oxd-topbar-header-breadcrumb']");
        /* Elments Ends Here */

        internal void VerifyQuickLaunchItems()
        {
            var actualLabels = ReturnListofItems(quick_launch_items);
            Assert.IsTrue(actualLabels.Count > 0, "Quick Launch Items are not displayed");
            //string labelsCsv = TestContext?.Properties["quickLaunchLabels"]?.ToString();
            string labelsCsv = "Assign Leave,Leave List,Timesheets,Apply Leave,My Leave,My Timesheet";
            string[] expectedLabels = labelsCsv?.Split(',') ?? Array.Empty<string>();
            CollectionAssert.AreEqual(expectedLabels, actualLabels, "Quick Launch labels do not match");
        }

        internal void navigateToAdmin()
        {
            ClickElement(menu_item_admin);
        }

        internal void navigateToPIM()
        {
            ClickElement(menu_item_PIM);
        }

        internal void navigateToLeave()
        {
            ClickElement(menu_item_leave);
        }

        internal void validateAdminPageTitle()
        {
            Assert.AreEqual(GetText(admin_page_title), "Admin", "Admin Page Title Not Macthing");
        }

        internal void validatePIMPageTitle()
        {
            Assert.AreEqual(GetText(pim_page_title), "PIM", "Admin Page Title Not Macthing");
        }

        internal void validateLeavePageTitle()
        {
            Assert.AreEqual(GetText(leave_page_title), "Leave", "Admin Page Title Not Macthing");
        }
    }
}
