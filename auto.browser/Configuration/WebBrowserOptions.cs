using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto.browser.Configuration
{
   public class WebBrowserOptions
    {
        public const string Position = "WebBrowser";
        public string BrowserPath { get; set; }
        public string ProfilePath { get; set; }
    }
}
