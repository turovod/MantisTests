using NUnit.Framework;
using System.IO;
// connect the library System.Net.FtpClient
namespace MantisTest
{
    [TestFixture]
    class AccountCreationTests : TestBase
    {
        //[TestFixtureSetUp]
        //public void SetUpConfig()
        //{
        //    appManager.Ftp.BeckupFile("/config_inc.php");
        //    // using will open the stream will read the file will transfer the stream to localFile and close the stream
        //    using (Stream localFile = File.OpenRead("config_inc.php"))
        //    {
        //        appManager.Ftp.Upload("/config_inc.php", localFile);
        //    }
        //}

        [Test]
        public void AccountRegistrationTest()
        {
            AccountData accountData = new AccountData() 
            { 
                Name = "testUser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            appManager.Registration.Register(accountData);
        }

        //[TestFixtureTearDown]
        //public void RestoreConfig()
        //{
        //    appManager.Ftp.RestoreBeckupFile("");
        //}
    }
}
