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
    }
}
