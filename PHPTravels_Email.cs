using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    
    [TestClass]
    public class PHPTravels_Email
    {
          [TestInitialize]
        public void Init()
        {
          TestParametar parameters = new TestParametar();
           int n = int.Parse(parameters.browser);

          Driver.Initialize(n);
        }

       [TestMethod]
       public void TEST_PHPTravels_Email()
       {
                string subject = "",
                          body = "";

                TestParametar parameters = new TestParametar();
                string url = parameters.url;

                LoginPage.GoTo(url);

                string TestName = "PHPTravels_Email";
                string folderpath = @"C:/ScreenShot/" + TestName + "/";

                SearchForBgList.DeleteFolder(folderpath);

                SearchForBgList.CreateFolder(folderpath);

                string phpMessage = PHPTravelsFunction.SearchPHPTravelsOnGoogle("PHP Travels");
                string emailMessage = PHPTravelsFunction.EmailPHPTravels();

                subject = "Moj deseti test";

                if (!phpMessage.Contains("ERROR") && (!emailMessage.Contains("ERROR")))
                {
                    subject = "Passed!!! " + subject;
                    body = "The test has passed" + "\n" + phpMessage + emailMessage;
                }
                else
                {
                    subject = "Failed!!! " + subject;
                    body = phpMessage + emailMessage;
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
