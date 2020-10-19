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

        public RegistrationHelper Registration { get; private set; }
        public FtpHalper Ftp { get; private set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public AdminHelper Admin { get; private set; }

        private AppManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.24.3/login_page.php";

            Registration = new RegistrationHelper(this);
            Ftp = new FtpHalper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Admin = new AdminHelper(this);
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
