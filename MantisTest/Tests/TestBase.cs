using NUnit.Framework;

namespace MantisTest
{
    [SetUpFixture]
    class TestBase
    {
        protected AppManager appManager = AppManager.GetAppManager();

        [SetUp]
        public void SetupTest()
        {
            appManager.Navigator.OpenHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Auth.Logout();
            appManager.Stop();
        }
    }
}
