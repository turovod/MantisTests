using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Connect SimpleBrouser.WebDriver (NuGet Install-Package SimpleBrowser.WebDriver)

namespace MantisTest
{
    public class AdminHelper : HelperBase
    {
        public AdminHelper(AppManager manager) : base(manager) { }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();

            IWebDriver driver = OpenAppAndLogin();
            driver.Url = "http://localhost/mantisbt-2.24.3/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("td a"));

            foreach (var row in rows)
            {
                string href = row.GetAttribute("href");
                Match m = Regex.Match(href, @"\d +$");
                string id = m.Value;
                System.Console.WriteLine(id);

                accounts.Add(new AccountData() { Id = id });
            }

            return accounts;
        }

        public string GetIdSecondElement()
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = "http://localhost/mantisbt-2.24.3/manage_user_page.php";
            IWebElement el = driver.FindElement(By.LinkText("testUser"));
            string href = el.GetAttribute("href");

            Match m = Regex.Match(href, @"\d+$");

            return m.Value;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = "http://localhost/mantisbt-2.24.3/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input[value ='Удалить учётную запись']")).Click();
            driver.FindElement(By.CssSelector("input[value ='Удалить учётную запись']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = appManager.BaseURL;
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.ClassName("btn")).Click();
            driver.FindElement(By.Name("username")).SendKeys("root");
            driver.FindElement(By.ClassName("btn")).Click();
            return driver;
        }
    }
}
