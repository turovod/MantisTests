using MantisTest.Mantis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTest
{
    class APIHelper : HelperBase
    {
        public APIHelper(AppManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, IssueDataModel issueData)
        {
            // An instance of the class through which we will refer to the Mantis
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            Mantis.IssueData issue = new Mantis.IssueData();

            issue.category = issueData.Category;
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.project = new ObjectRef() { id = issueData.ProjectId};


            client.mc_issue_add(account.Name, account.Password, issue);
        }
    }
}
