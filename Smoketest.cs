using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    [TestClass]
    public class Smoketest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize(1);
        }

        [TestMethod]
        public void Admin_User_Can_Login()
        {
            LoginPage.GoTo("https://trebevic.net/wp-login.php?itsec-hb-token=treblogin");
            LoginPage.LoginAs("trebevic_admin").WithPassword("baG!Rf7yp6jWhkl&wP").Login();

            Assert.IsTrue(DashboardPage.IsAt, "Failed to login.");
        }
        [TestCleanup]
        public void Cleanup()
        {
          Driver.Close();
        }
    }
}
