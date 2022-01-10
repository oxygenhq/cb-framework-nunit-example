using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System.Reflection;

namespace nunit_mobile.Tests.Android
{
    [TestFixture("test-gallery", "emulator-v11")]
    [TestFixture("test-gallery", "sony-xperia-5")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Gallery : BaseTest
    {
        public Gallery() : base() { }

        public Gallery(string application, string device) : base(application, device) { }

        [Test(Description = "Open new photo using center + icon"), Category("Open Photo"), Order(1)]
        [TestCase("paramA", Description = "Open new photo using center + icon with paramA"), Category("Open Photo")]
        [TestCase("paramB", Description = "Open new photo using center + icon with paramB"), Category("Open Photo")]
        public void OpenPhotoByIcon(string param)
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            StartStep("this a snapseed step");
            var logo = _driver.FindElement(MobileBy.AccessibilityId("More options"));
            logo.Click();
            EndStep("this a snapseed step");
        }

        [Test(Description = "Open new photo using the top-left button"), Category("Open Photo")]
        public void OpenPhotoByButton()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            StartStep("open photo step");
            var logo = _driver.FindElement(MobileBy.AccessibilityId("More options"));
            logo.Click();
            EndStep("open photo step");
        }

        [Test(Description = "Failing test"), Category("Open Photo")]
        public void FailingTest()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            StartStep("empty step");
            TestContext.Progress.WriteLine("This is an empty step");
            EndStep("empty step");

            StartStep("nested step - outer");
            TestContext.Progress.WriteLine("This is an outer nested step");
            StartStep("nested step - inner");
            TestContext.Progress.WriteLine("This is an inner nested step");
            EndStep("nested step - inner");
            EndStep("nested step - outer");

            StartStep("failing step");
            var logo = _driver.FindElement(MobileBy.AccessibilityId("More options"));
            logo.Click();
            EndStep("failing step");
        }
    }
}
