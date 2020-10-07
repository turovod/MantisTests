using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTest
{
    public class AppManager
    {
        private IWebDriver driver;
        private string baseURL;

        private static AppManager appManager;

        public IWebDriver Driver { get { return driver; } }
        public string BaseURL { get { return baseURL; } }

        private AppManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
        }

        public static AppManager GetAppManager()
        {
            if (appManager == null)
            {
                appManager = new AppManager();
            }

            return appManager;
        }

        public void Stop()
        {

            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
