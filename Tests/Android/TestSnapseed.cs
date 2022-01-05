﻿using NUnit.Framework;

namespace nunit_mobile.Tests.Android
{
    [TestFixture("test-snapseed", "sony-xperia-5")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestSnapseed : BaseTest
    {
        public TestSnapseed(string application, string device) : base(application, device) { }

        [Test(Description = "Open new photo using center + icon"), Category("Open Photo")]
        public void OpenPhotoByIcon()
        {
            StartStep("this a snapseed step");
            var logo = driver.FindElementById("com.niksoftware.snapseed:id/logo_view");
            logo.Click();
            EndStep("this a snapseed step");
        }

        [Test(Description = "Open new photo using the top-left button"), Category("Open Photo")]
        public void OpenPhotoByButton()
        {
            var logo = driver.FindElementByAccessibilityId("Open photo");
            logo.Click();
        }
    }
}
