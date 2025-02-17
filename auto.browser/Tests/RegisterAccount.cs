using auto.browser.webdriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using System.Text.Json;
using System.ComponentModel;

namespace auto.browser.Tests
{
    public class RegisterAccount(WebDriverFactory driverFactory)
    {
        private readonly By _openRegisterPageButton = By.XPath("//a[@href = '/account/register']");
        private readonly By _noPromoButton = By.XPath("//button[text()='Продолжить без промокода']");
        private readonly By _phoneNumber = By.XPath("//input[@type='tel']");
        private readonly By _nextStep = By.XPath("//button[text()='ДАЛЕЕ']");
        private readonly By _baltBetSmsCode = By.XPath("//input[@class='registration-form__input input-text']");

        public async Task Run()
        {
            var browser = driverFactory.CreateDriver();
            browser.Navigate().GoToUrl("https://uniru.test046.local/");
            browser.FindElement(_openRegisterPageButton).Click();
            browser.FindElement(_noPromoButton).Click();
            browser.FindElement(_phoneNumber).SendKeys(new Bogus.Faker().Phone.PhoneNumber("+7 (###) ###-##-##"));
            browser.FindElement(_nextStep).Click();
            Thread.Sleep(5000);
            string code = await GetResponse.GetJsonResponseAsync("http://winagent.test046.local:44368/sms/reg");
            browser.FindElement(_baltBetSmsCode).SendKeys(code);
            browser.FindElement(_nextStep).Click();
        }

    }
}

