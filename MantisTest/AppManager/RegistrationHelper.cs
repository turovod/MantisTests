using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MantisTest
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(AppManager appManager) : base(appManager) { }

        public void Register(AccountData accountData)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(accountData);
            SubmitRegistration();

            // ---
            string url = GetConfirmationUrl(accountData);
            FillPasswordForm(url, accountData);
            SubmitPasseordForm();
        }

        private void SubmitPasseordForm()
        {
            appManager.Driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillPasswordForm(string url, AccountData accountData)
        {
            driver.Url = url;
            appManager.Driver.FindElement(By.Name("password")).SendKeys(accountData.Password);
            appManager.Driver.FindElement(By.Name("password_confirm")).SendKeys(accountData.Password);
        }

        private string GetConfirmationUrl(AccountData accountData)
        {
            string message = appManager.Mail.GetLastMail(accountData);

            // Extracting a link from the text using regular expressions
            // Connect usung text.regularExpression
                                                // no space pattern
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void OpenRegistrationForm()
        {
            //driver.FindElement(By.CssSelector("a.back-to-login-link.pull-left")).Click();
            driver.FindElement(By.ClassName("pull-left")).Click();
        }

        private void SubmitRegistration()
        { 
            appManager.Driver.FindElement(By.ClassName("width-40")).Click();
        }

        private void FillRegistrationForm(AccountData accountData)
        {
            appManager.Driver.FindElement(By.Id("username")).SendKeys(accountData.Name);
            appManager.Driver.FindElement(By.Id("email-field")).SendKeys(accountData.Email);
        }

        private void OpenMainPage()
        {
            appManager.Driver.Url = appManager.BaseURL;
        }
    }
}
