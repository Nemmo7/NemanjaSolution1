using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    [TestClass]
    public class PHPTravels_Offers
    {
        [TestInitialize]
        public void Init()
        {
            TestParametar parameters = new TestParametar();
            int n = int.Parse(parameters.browser);

            Driver.Initialize(n);
        }

        [TestMethod]
        public void TEST_PHPTravels_Offers()
        {
            string subject = "",
                      body = "";

            TestParametar parameters = new TestParametar();
            string url = parameters.url;

            LoginPage.GoTo(url);

            string TestName = "PHPTravels_Offers";
            string folderpath = @"C:/ScreenShot/" + TestName + "/";

            SearchForBgList.DeleteFolder(folderpath);

            SearchForBgList.CreateFolder(folderpath);

            string phpMessage = PHPTravelsFunction.SearchPHPTravelsOnGoogle("PHP Travels");
            string offersMessage = PHPTravelsFunction.OffersPHPTravels("Zivko", "065-444-555", "Super ste!");

            subject = "Moj deveti test";

            if (!phpMessage.Contains("ERROR") && (!offersMessage.Contains("ERROR")))
            {
                subject = "Passed!!! " + subject;
                body = "The test has passed" + "\n" + phpMessage + offersMessage;
            }
            else
            {
                subject = "Failed!!! " + subject;
                body = phpMessage + offersMessage;
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
