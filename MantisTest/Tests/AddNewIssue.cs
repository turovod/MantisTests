using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTest
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddToNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            IssueDataModel issueData = new IssueDataModel()
            {
                Category = "1",
                Summary = "short text",
                Description = "long text",
                ProjectId = "General"
            };

            appManager.API.CreateNewIssue(account, issueData);
        }
    }
}
