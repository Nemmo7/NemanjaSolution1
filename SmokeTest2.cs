using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    [TestClass]
    public class SmokeTest2
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize(1);
        }

        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            LoginPage.GoTo("https://trebevic.net/wp-login.php?itsec-hb-token=treblogin");
            LoginPage.LoginAs("trebevic_admin").WithPassword("baG!Rf7yp6jWhkl&wP").Login();

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title")
                .WithBody("Hi, this is the body")
                .Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match new post");
        }
        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
