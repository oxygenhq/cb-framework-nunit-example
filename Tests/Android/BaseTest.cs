using CloudBeat.Frameworks.NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;

namespace nunit_mobile.Tests.Android
{
    public class BaseTest : CBTest
    {
		protected string application;
		protected string device;

		public BaseTest(string application, string device)
		{
			this.application = application;
			this.device = device;
		}

		[OneTimeSetUp]
		public void Init()
		{
			//Debugger.Launch();

			if (!IsRunningFromCB())
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
				_driver = new EventFiringWebDriver(new AndroidDriver<AppiumWebElement>(appiumUri, options));
			} 
			else
            {
				var options = GetDeviceOptions();

				// FIXME:
				NameValueCollection caps = ConfigurationManager.GetSection("capabilities/android/" + application) as NameValueCollection;
				foreach (string key in caps.AllKeys)
				{
					options.AddAdditionalCapability(key, caps[key]);
				}

				Uri appiumUri = new Uri(ConfigurationManager.AppSettings["appiumUrl"]);
				_driver = new EventFiringWebDriver(new AndroidDriver<AppiumWebElement>(appiumUri, options));
				SubscribeToEvents();
			}
		}

		[OneTimeTearDown]
		public void Cleanup()
		{
			if (_driver != null)
			{
				_driver.Quit();
			}
		}
	}
}
