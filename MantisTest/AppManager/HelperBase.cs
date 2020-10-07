using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTest
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected AppManager appManager;

        public HelperBase(AppManager appManager)
        {
            this.driver = appManager.Driver;
            this.appManager = appManager;
        }

        protected void ClickSelectClick(By locatorName, By locatorXPath, string testData)
        {
            if (testData != null)
            {
                driver.FindElement(locatorName).Click();
                new SelectElement(driver.FindElement(locatorName)).SelectByText(testData);
                driver.FindElement(locatorXPath).Click();
            }
        }

        protected void ClicClearSendKeys(string testData, By locator)
        {
            if (testData != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(testData);
            }
        }
    }
}
