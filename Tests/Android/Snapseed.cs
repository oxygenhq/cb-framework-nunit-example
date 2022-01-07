using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;

namespace nunit_mobile.Tests.Android
{
    [TestFixture("test-snapseed", "sony-xperia-5")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Snapseed : BaseTest
    {
        public Snapseed(string application, string device) : base(application, device) { }

        [Test(Description = "Test"), Category("Menu")]
        public void Test1()
        {
            StartStep("this a step");
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
            EndStep("this a step");
        }

        [Test(Description = "Test: Test + 2 TestCase single param"), Category("Menu")]
        [TestCase("param1", Description = "TestCase: Test + 2 TestCase single param: 1")]
        [TestCase("param2", Description = "TestCase: Test + 2 TestCase single param and cat: 2", Category = "testcase cat")]
        public void Test2(string param)
        {
            Console.Out.WriteLine("parameter: " + param);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
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
        public void Test3(string param, int param2, Test_Type testType)
        {
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
        }

        static object[] Source()
        {
            return new object[0];
        }
        [Test(Description = "Test: Test + TestCaseSource"), Category("test case source main cat")]
        [TestCaseSource("Source", Category = "test case source category")]
        public void Test4(object[] Source)
        {
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
        }

        [Test(Description = "Test ordered 1"), Category("Ordered"), Order(1)]
        public void Test5()
        {
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
        }

        [Test(Description = "Test ordered 2"), Category("Ordered"), Order(2)]
        public void Test6()
        {
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
        }

        [Test(Description = "Test Failing"), Category("Ordered"), Order(2)]
        public void Test7()
        {
            var logo = _driver.FindElement(MobileBy.Id("doesnt exist"));
            logo.Click();
        }
    }
}
