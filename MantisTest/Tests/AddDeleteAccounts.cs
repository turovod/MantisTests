using System;
using NUnit.Framework;

namespace MantisTest
{
    [TestFixture]
    public class AddDeleteAccounts : TestBase
    {
        [Test]
        public void AddDeleteAccount()
        {
            AccountData accountData = new AccountData()
            {
                Name = "xxx",
                Password = "yyy"
            };

            Assert.IsFalse(appManager.James.Verify(accountData));
            appManager.James.Add(accountData);
            Assert.IsTrue(appManager.James.Verify(accountData));
            appManager.James.Delete(accountData);
            Assert.IsFalse(appManager.James.Verify(accountData));
        }
    }
}
