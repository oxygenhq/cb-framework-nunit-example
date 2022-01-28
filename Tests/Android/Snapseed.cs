using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace nunit_mobile.Tests.Android
{
    //[TestFixture("test-snapseed", "emulator-v11")]
    //[TestFixture("test-snapseed", "sony-xperia-5")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class Snapseed : BaseTest
    {
        public Snapseed() : base() { }

        public Snapseed(string application, string device) : base(application, device) { }

        [Test(Description = "Test"), Category("Menu")]
        [Property("Foo", "Bar")]
        [Property("NotFoo", "Bar")]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            StartStep("this a step");
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            EndStep("this a step");
        }

        [Test(Description = "Category test 1"), Category("Category Test")]
        public void TestCat1()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            StartStep("this a step");
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            EndStep("this a step");
        }

        [Test(Description = "Category test 2"), Category("Category Test")]
        public void TestCat2()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            StartStep("this a step");
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            EndStep("this a step");
        }

        [Test(Description = "Test: Test + 2 TestCase single param"), Category("Menu")]
        [TestCase("param1", Description = "TestCase: Test + 2 TestCase single param: 1")]
        [TestCase("param2", Description = "TestCase: Test + 2 TestCase single param and cat: 2", Category = "testcase cat")]
        public void Test2(string param)
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
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
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
        }

        /*static object[] Source =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 }
        };
        [Test(Description = "Test: Test + TestCaseSource initialized array"), Category("test case source main cat")]
        [TestCaseSource(nameof(Source), Category = "test case source category")]
        public void Test4a(int a, int b, int c)
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
        }

        static List<string> ExampleSource()
        {
            return new List<string>();
        }
        [Test(Description = "Test: Test + TestCaseSource LIST"),]
        [TestCaseSource(nameof(ExampleSource))]
        public void Test4b(string ExampleSource)
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
        }*/

        [Test(Description = "Test ordered 1"), Category("Ordered"), Order(1)]
        public void Test5()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
        }

        [Test(Description = "Test ordered 2"), Category("Ordered"), Order(2)]
        public void Test6()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
        }

        [Test(Description = "Test Failing"), Category("Ordered"), Order(2)]
        public void Test7()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("doesnt exist"));
        }

        [Test(Description = "Nested steps")]
        public void Test8()
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

            StartStep("click step");
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
            EndStep("click step");
        }

        [Test]
        [TestCase("paramA", 4, Test_Type.Identified)]
        [TestCase("paramB", 6, Test_Type.NotIdentified)]
        public void TestNoDescription(string param, int param2, Test_Type testType)
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = _driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
        }
    }
}
