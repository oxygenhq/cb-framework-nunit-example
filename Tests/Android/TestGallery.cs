using NUnit.Framework;
using System;

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
            StartStep("this a step");
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
            EndStep("this a step");
        }

        [Test(Description = "Open the menu + MULTIPLE TEST CASES"), Category("Menu")]
        [TestCase("param1", Description = "OpenMoreOptions2 with param1")]
        [TestCase("param2", Description = "OpenMoreOptions2 with param2", Category = "testcase cat")]
        public void OpenMoreOptions2(string param)
        {
            Console.Out.WriteLine("parameter: " + param);
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        static object[] Source()
        {
            return new object[0];
        }
        [Test(Description = "Test - testcasesource"), Category("Menu")]
        [TestCaseSource("Source", Category = "test case source category")]
        public void TestCaseSource(object[] Source)
        {
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        [Test(Description = "Ordered tests 1"), Category("Ordered"), Order(1)]
        public void OpenMoreOptions3()
        {
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        [Test(Description = "Ordered tests 2"), Category("Ordered"), Order(2)]
        public void OpenMoreOptions4()
        {
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }
    }
}
