using NUnit.Framework;
using System;

namespace nunit_mobile.Tests.Android
{
    [TestFixture("test-snapseed", "sony-xperia-5")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestSnapseed : BaseTest
    {
        public TestSnapseed(string application, string device) : base(application, device) { }

        [Test(Description = "Open new photo using center + icon"), Category("Open Photo"), Order(1)]
        [TestCase("paramA", Description = "Open new photo using center + icon with paramA"), Category("Open Photo")]
        [TestCase("paramB", Description = "Open new photo using center + icon with paramB"), Category("Open Photo")]
        public void OpenPhotoByIcon(string param)
        {
            Console.Out.WriteLine("parameter: " + param);
            StartStep("this a snapseed step");
            var logo = _driver.FindElementById("com.niksoftware.snapseed:id/logo_view");
            logo.Click();
            EndStep("this a snapseed step");
        }

        [Test(Description = "Open new photo using the top-left button"), Category("Open Photo")]
        public void OpenPhotoByButton()
        {
            StartStep("open photo step");
            var logo = _driver.FindElementByAccessibilityId("Open photo");
            logo.Click();
            EndStep("open photo step");
        }

        [Test(Description = "Failing test"), Category("Open Photo")]
        public void FailingTest()
        {
            StartStep("empty step");
            Console.Out.WriteLine("This is an empty step");
            EndStep("empty step");

            StartStep("nested step - outer");
            Console.Out.WriteLine("This is an outer nested step");
            StartStep("nested step - inner");
            Console.Out.WriteLine("This is an inner nested step");
            EndStep("nested step - inner");
            EndStep("nested step - outer");

            StartStep("failing step");
            var logo = _driver.FindElementByAccessibilityId("doesnt exist");
            logo.Click();
            EndStep("failing step");
        }
    }
}
