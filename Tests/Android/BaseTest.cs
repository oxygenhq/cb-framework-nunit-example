using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace nunit_mobile.Tests.Android
{
	public class BaseTest
    {
		protected AndroidDriver<AndroidElement> driver;
		protected string application;
		protected string device;

		public BaseTest(string application, string device)
		{
			this.application = application;
			this.device = device;
		}

		[SetUp]
		public void Init()
		{
			NameValueCollection caps = ConfigurationManager.GetSection("capabilities/android/" + application) as NameValueCollection;
			NameValueCollection devices = ConfigurationManager.GetSection("devices/android/" + device) as NameValueCollection;

			AppiumOptions options = new AppiumOptions();

			foreach (string key in caps.AllKeys)
			{
				options.AddAdditionalCapability(key, caps[key]);
			}

			foreach (string key in devices.AllKeys)
			{
				options.AddAdditionalCapability(key, devices[key]);
			}

			Uri appiumUri = new Uri(ConfigurationManager.AppSettings["appiumUrl"]);
			driver = new AndroidDriver<AndroidElement>(appiumUri, options);
		}

		[TearDown]
		public void Cleanup()
		{
			if (driver != null)
			{
				driver.Quit();
			}
		}
	}
}
