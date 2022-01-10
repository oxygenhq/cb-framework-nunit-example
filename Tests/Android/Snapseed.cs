using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Reflection;

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
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
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
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
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
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
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
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
        }

        [Test(Description = "Test ordered 1"), Category("Ordered"), Order(1)]
        public void Test5()
        {
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
        }

        [Test(Description = "Test ordered 2"), Category("Ordered"), Order(2)]
        public void Test6()
        {
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
        }

        [Test(Description = "Test Failing"), Category("Ordered"), Order(2)]
        public void Test7()
        {
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("doesnt exist"));
            logo.Click();
        }

        [Test(Description = "Nested steps")]
        public void Test8()
        {
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            StartStep("empty step");
            Console.Out.WriteLine("This is an empty step");
            EndStep("empty step");

            StartStep("nested step - outer");
            Console.Out.WriteLine("This is an outer nested step");
            StartStep("nested step - inner");
            Console.Out.WriteLine("This is an inner nested step");
            EndStep("nested step - inner");
            EndStep("nested step - outer");

            StartStep("click step");
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
            EndStep("click step");
        }

        [Test]
        [TestCase("paramA", 4, Test_Type.Identified)]
        [TestCase("paramB", 6, Test_Type.NotIdentified)]
        public void TestNoDescription(string param, int param2, Test_Type testType)
        {
            Console.Out.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            logo.Click();
        }
    }
}
