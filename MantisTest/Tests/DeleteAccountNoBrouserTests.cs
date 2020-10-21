using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTest
{
    [TestFixture]
    public class DeleteAccountNoBrouserTests : TestBase
    {
        [Test]
        public void DeleteAccountNoBrouserTest()
        {
            string id = appManager.Admin.GetIdSecondElement();
            AccountData account = new AccountData()
            {
                Id = id
            };

            //List<AccountData> accounts = appManager.Admin.GetAllAccounts();

            //foreach (var item in accounts)
            //{
            //    Console.WriteLine(item.Id);
            //}



            appManager.Admin.DeleteAccount(account);
        }
    }
}
