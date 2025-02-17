using auto.browser.webdriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto.browser.Tests
{
    public class OpenRegistration(WebDriverFactory driverFactory)
    {
        private readonly By _openRegisterPageButton = By.XPath("//a[@href = '/account/register']");

       
        public async Task Run()
        {
            using var browser = driverFactory.CreateDriver();
            browser.Navigate().GoToUrl("https://uniru.test046.local/");
            browser.FindElement(_openRegisterPageButton).Click();
        }
    }
}
