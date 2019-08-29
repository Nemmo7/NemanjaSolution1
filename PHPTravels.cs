using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    [TestClass]
    public class PHPTravels
    {
        [TestInitialize]
        public void Init()
        {
            TestParametar parameters = new TestParametar();
            int n = int.Parse(parameters.browser);

            Driver.Initialize(n);
        }

        [TestMethod]
        public void TEST_PHPTravels()
        {
            string subject = "",
                      body = "";

            TestParametar parameters = new TestParametar();
            string url = parameters.url;

            LoginPage.GoTo(url);

            string TestName = "PHPTravels";
            string folderpath = @"C:/ScreenShot/" + TestName + "/";

            SearchForBgList.DeleteFolder(folderpath);

            SearchForBgList.CreateFolder(folderpath);

            string phpMessage = PHPTravelsFunction.SearchPHPTravelsOnGoogle("PHP Travels");
            string loginMessage = PHPTravelsFunction.LoginOnPHPTravels("mikaherrabe-2460@yopmail.com", "monzza");
          

            subject = "Moj peti test";

            if (!phpMessage.Contains("ERROR") && (!loginMessage.Contains("ERROR")))
            {
                subject = "Passed!!! " + subject;
                body = "Test have error" + "\n" + phpMessage + loginMessage;
            }
            else
            {
                subject = "Failed!!! " + subject;
                body = phpMessage + loginMessage;
            }

            SearchForBgList.SendEmailAttachment(subject, body, TestName);
           
            Assert.IsTrue(subject.Contains("Passed"));
            Assert.IsFalse(subject.Contains("Failed"));

        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}

