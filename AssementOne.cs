using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Assessment
{
	[TestClass]
	public class Assessment
	{

		IWebDriver Driver;

		[TestInitialize]
		public void start_Browser()
		{
			/* Local Selenium WebDriver */
			Driver = new ChromeDriver();
			Driver.Manage().Window.Maximize();
		}
		[TestMethod]
		public void test_Case_One()
		{

			Driver.Url = "http://www.crawco.co.uk";
			Driver.FindElement(By.XPath("//a[starts-with(@href,'https://www.facebook.com/')]")).Click();
			var newWindowHandle = Driver.WindowHandles[1];
			Assert.IsTrue(!string.IsNullOrEmpty(newWindowHandle));
			string expectedUrl = "https://www.facebook.com/crawfordandco";
			Assert.AreEqual(Driver.SwitchTo().Window(newWindowHandle).Url, expectedUrl);
			
		}
		
		[TestCleanup]
		public void close_Browser()
		{
			Driver.Quit();
		}



	}
}
