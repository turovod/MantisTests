using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
