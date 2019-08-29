using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    [TestClass]
    public class SearchForBg
    {

        [TestInitialize]
        public void Init()
        {
            SearchListPage.WriteInto("Start of init");

            TestParametar parameters = new TestParametar();
            int n = int.Parse(parameters.browser);

            Driver.Initialize(n);
            SearchListPage.WriteInto("End of init");
        }

        [TestMethod]
         public void TEST_SearcForBg()
         {
            string subject = "",
                      body = "";

           string url = "";

            SearchListPage.WriteInto("TEST_SearcForBg" + "_Start of Test_" + DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)"));
            SearchListPage.WriteInto("Start of Login");
            TestParametar parameters = new TestParametar();
            url = parameters.url;

            LoginPage.GoTo(url);
            
            string TestName = "SearchForBg";
            string folderpath = @"C:/ScreenShot/" + TestName + "/";

            SearchListPage.WriteInto("Start of DeleteFolder");
            SearchForBgList.DeleteFolder(folderpath);

            SearchListPage.WriteInto("Start of CreateFolder");
            SearchForBgList.CreateFolder(folderpath);

            SearchListPage.WriteInto("Start of Searching Image");
            string imageMessage = SearchForBgList.SearchImageOnGoogle("Beograd", 4);
            SearchListPage.WriteInto("End of Searching");

            subject = "Moj treci test";
           
            if (!imageMessage.Contains("ERROR"))
            {
                subject = "Passed!!! " + subject;
                body = "Google image upload option works properly" + "\n" + imageMessage;
            }
            else
            {
                subject = "Failed!!! " + subject;
                body = imageMessage;
            }

            SearchListPage.WriteInto("Start of Attachment");
            SearchForBgList.SendEmailAttachment(subject, body, TestName);
            SearchListPage.WriteInto("End of Attachment");

            
            Assert.IsTrue(subject.Contains("Passed"));
            Assert.IsFalse(subject.Contains("Failed"));

            SearchListPage.WriteInto(TestName + "_End of Test_" + DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)"));

        }


        [TestCleanup]
        public void Cleanup()
        {
            SearchListPage.WriteInto("Start of Driver");
            Driver.Close();
            SearchListPage.WriteInto("End of Driver");
        }
    }
}
