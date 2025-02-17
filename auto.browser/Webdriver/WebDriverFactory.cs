using auto.browser.Configuration;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto.browser.webdriver
{
    public class WebDriverFactory
    {
        private readonly WebBrowserOptions _webBrowserOptions;
        public WebDriverFactory(IOptions<WebBrowserOptions> options)
        {
            _webBrowserOptions = options.Value;
        }
        public ChromeDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.BinaryLocation = _webBrowserOptions.BrowserPath;
         //   options.AddArgument($"user-data-dir={Environment.ExpandEnvironmentVariables(_webBrowserOptions.ProfilePath)}");
            options.AddArgument("verbose");
            options.AddArgument("start-maximized");
            options.AddArgument("profile-directory=Default");
            options.AddArgument("enable-automation");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-browser-side-navigation");
            options.AddArgument("--disable-gpu");
            return new ChromeDriver(options);
        }
    }
}
