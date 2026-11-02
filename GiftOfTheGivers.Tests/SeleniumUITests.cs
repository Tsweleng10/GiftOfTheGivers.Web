using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System;
using System.Threading;

namespace GiftOfTheGivers.Tests
{
    public class SeleniumUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        private const string BaseUrl = "https://localhost:7148"; // Make sure this matches your VS port!

        public SeleniumUITests()
        {
            var options = new ChromeOptions();
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--allow-insecure-localhost");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Fact]
        public void Test1_Employee_Can_Login_Successfully()
        {
            _driver.Navigate().GoToUrl($"{BaseUrl}/Identity/Account/Login");
            _driver.FindElement(By.Id("Input_Email")).SendKeys("employee@giftofgivers.org");
            _driver.FindElement(By.Id("Input_Password")).SendKeys("Employee@123");
            _driver.FindElement(By.Id("login-submit")).Click();

            Thread.Sleep(2000);
            var navLinks = _driver.FindElements(By.ClassName("nav-link"));
            bool dashboardFound = false;

            foreach (var link in navLinks)
            {
                if (link.Text.Trim() == "Dashboard")
                {
                    dashboardFound = true;
                    break;
                }
            }
            Assert.True(dashboardFound, "Dashboard link did not appear. Login might have failed.");
        }

        [Fact]
        public void Test2_Anonymous_Donation_Works()
        {
            _driver.Navigate().GoToUrl($"{BaseUrl}/Donations/Create");
            var amountBox = _driver.FindElement(By.Id("Amount"));
            amountBox.Clear();
            amountBox.SendKeys("250");

            var anonymousCheckbox = _driver.FindElement(By.Id("IsAnonymous"));
            if (!anonymousCheckbox.Selected)
            {
                anonymousCheckbox.Click();
            }

            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(2000);

            var pageHeading = _driver.FindElement(By.TagName("h2")).Text;
            Assert.Equal("Thank You for Your Donation!", pageHeading);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}