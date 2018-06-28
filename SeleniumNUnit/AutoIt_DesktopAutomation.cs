using AutoItX3Lib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumNUnit
{
    [TestFixture]
    public class AutoIt_DesktopAutomation
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupForEveryTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
        }

        [Test, Description("Open an Image from local file system")]
        public void OpenImageFromLocalFileSystem()
        {
            //Navigates the browser to given URL
            driver.Navigate().GoToUrl("https://images.google.com/");

            string fullFilePath = @"C:\AutomationImages\Actual.jpg";
            Console.WriteLine("Open File: " + fullFilePath);

            IWebElement searchByImageButton = driver.FindElement(By.XPath("//span[@id='qbi']"));
            searchByImageButton.Click();
            IWebElement searchByImageWindow = driver.FindElement(By.XPath("//div[@id='qbp']"));

            IWebElement tabUploadImage = searchByImageWindow.FindElement(By.XPath("//div[@Class='qbtbha sl']"));
            tabUploadImage.Click();

            IWebElement btnChoosefile  = searchByImageWindow.FindElement(By.XPath("//input[@id='qbfile']"));

            btnChoosefile.Click();
            System.Threading.Thread.Sleep(2000);

            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinWait("Open");
            autoIT.WinActivate("Open");
            autoIT.ControlFocus("Open", "", "[CLASS:Edit]");
            autoIT.ControlSetText("Open", "", "[CLASS:Edit]", fullFilePath);
            //autoIT.Send(@"Actual.jpg");
            autoIT.ControlClick("Open", "", "[CLASS:Button; Text: Open]");
             
        }
    }
}
