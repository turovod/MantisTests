using NUnit.Framework;
using System.IO;
// connect the library System.Net.FtpClient
namespace MantisTest
{
    [TestFixture]
    class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            appManager.Ftp.BackupFile("/config_inc.php");
            // using  allows will open the stream will read the file will transfer the stream to localFile and close the stream
            using (Stream localFile = File.OpenRead("config_inc.php"))
            {
                appManager.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void AccountRegistrationTest()
        {
            AccountData accountData = new AccountData() 
            { 
                Name = "testUser1",
                Password = "password1",
                Email = "testuser1@localhost.localdomain"
            };

            // ---------------------------------- Create an account to receive a confirmation email          
            appManager.James.Delete(accountData); // We check that there is definitely no such account
            appManager.James.Add(accountData);

            appManager.Registration.Register(accountData);
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            appManager.Ftp.RestoreBackupFile("");
        }
    }
}
