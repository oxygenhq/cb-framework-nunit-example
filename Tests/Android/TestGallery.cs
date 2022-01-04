using NUnit.Framework;

namespace nunit_mobile.Tests.Android
{
    [TestFixture("test-gallery", "emulator-v11")]
    [TestFixture("test-gallery", "sony-xperia-5")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestGallery : BaseTest
    {
        public TestGallery(string application, string device) : base(application, device) { }

        [Test(Description = "Open the menu"), Category("Menu")]
        public void OpenMoreOptions()
        {
            var logo = driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        [Test(Description = "Open the menu + MULTIPLE TEST CASES"), Category("Menu")]
        [TestCase("param1", Description = "OpenMoreOptions2 with param1"), Category("Menu")]
        [TestCase("param2", Description = "OpenMoreOptions2 with param2"), Category("Menu")]
        public void OpenMoreOptions2()
        {
            var logo = driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        [Test(Description = "Ordered tests 1"), Category("Ordered"), Order(1)]
        public void OpenMoreOptions3()
        {
            var logo = driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        [Test(Description = "Ordered tests 2"), Category("Ordered"), Order(2)]
        public void OpenMoreOptions4()
        {
            var logo = driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }
    }
}
