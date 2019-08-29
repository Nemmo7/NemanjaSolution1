using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    [TestClass]
    public class SmokeTest3
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize(1);
        }

        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            LoginPage.GoTo("");
            LoginPage.LoginAs("trebevic_admin").WithPassword("baG!Rf7yp6jWhkl&wP").Login();

            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("Sample Page");

            Assert.IsTrue(
                NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");
        }
        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
