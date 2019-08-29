using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    [TestClass]
    public class PHPTravels_HOTELS
    {
        [TestInitialize]
        public void Init()
        {
            TestParametar parameters = new TestParametar();
            int n = int.Parse(parameters.browser);

            Driver.Initialize(n);
        }

        [TestMethod]
        public void TEST_PHPTravels_HOTELS()
        {
            string subject = "",
                      body = "";

            TestParametar parameters = new TestParametar();
            string url = parameters.url;

            LoginPage.GoTo(url);

            string TestName = "PHPTravels_HOTELS";
            string folderpath = @"C:/ScreenShot/" + TestName + "/";

            SearchForBgList.DeleteFolder(folderpath);

            SearchForBgList.CreateFolder(folderpath);

            string phpMessage = PHPTravelsFunction.SearchPHPTravelsOnGoogle("PHP Travels");
            string hotelsMessage = PHPTravelsFunction.HotelsPHPTravels("Amsterdam");

            subject = "Moj deseti test";

            if (!phpMessage.Contains("ERROR") && (!hotelsMessage.Contains("ERROR")))
            {
                subject = "Passed!!! " + subject;
                body = "The test has passed" + "\n" + phpMessage + hotelsMessage;
            }
            else
            {
                subject = "Failed!!! " + subject;
                body = phpMessage + hotelsMessage;
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
