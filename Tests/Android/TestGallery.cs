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

        [Test(Description = "Test"), Category("Menu")]
        public void OpenMoreOptions()
        {
            StartStep("this a step");
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
            EndStep("this a step");
        }

        [Test(Description = "Test: Test + 2 TestCase single param"), Category("Menu")]
        [TestCase("param1", Description = "TestCase: Test + 2 TestCase single param: 1")]
        [TestCase("param2", Description = "TestCase: Test + 2 TestCase single param and cat: 2", Category = "testcase cat")]
        public void OpenMoreOptions2(string param)
        {
            Console.Out.WriteLine("parameter: " + param);
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        public enum Test_Type
        {
            Identified,
            NotIdentified,
        }
        [Test(Description = "Test: Test + 2 TestCase mult params"), Category("Menu")]
        [TestCase("param1", 4, Test_Type.Identified, Description = "TestCase: Test + 2 TestCase mult params: 1")]
        [TestCase("param2", 6, Test_Type.NotIdentified, Description = "TestCase: Test + 2 TestCase mult params: 2")]
        public void MultParams(string param, int param2, Test_Type testType)
        {
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        static object[] Source()
        {
            return new object[0];
        }
        [Test(Description = "Test: Test + TestCaseSource"), Category("test case source main cat")]
        [TestCaseSource("Source", Category = "test case source category")]
        public void TestCaseSource(object[] Source)
        {
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        [Test(Description = "Test ordered 1"), Category("Ordered"), Order(1)]
        public void OpenMoreOptions3()
        {
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }

        [Test(Description = "Test ordered 2"), Category("Ordered"), Order(2)]
        public void OpenMoreOptions4()
        {
            var logo = _driver.FindElementByAccessibilityId("More options");
            logo.Click();
        }
    }
}
