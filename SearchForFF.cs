using System;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NemanjaTest1
{
    [TestClass]
    public class SearchForFF
    {
       
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize(1);
        }

        [TestMethod]
        public void TEST_SearchForFF()
        {
            string subject = "", 
                      body = "";


            string testName = "SearchForFF";

            string folderpath = @"C:/ScreenShot/" + testName + "/";
            SearchListPage.DeleteFolder(folderpath);
            SearchListPage.CreateFolder(folderpath);
            

            LoginPage.GoTo("https://www.google.com/");
            SearchPage.FindText("Jugoslavija");

           // SearchListPage.GoTo(ListType.Page);
            
            string imageMessage = SearchListPage.SelectImage("Slike", testName);
            string allMessage = SearchListPage.SelectAll("Sve", testName);
            string videoMessage = SearchListPage.SelectVideo("Videozapisi", testName);
            string booksMessage = SearchListPage.SelectBooks("Više", "Knjige", testName);
            string idMessage = SearchListPage.ClickOnElementByID("hdtb-tls");
            
            subject = "Ovo je naslov email-a mog prvog testa!";
            body = imageMessage + "\n" + allMessage + "\n" + videoMessage + "\n" + booksMessage;

            if (!imageMessage.Contains("ERROR") && !allMessage.Contains("ERROR") && !videoMessage.Contains("ERROR") && !booksMessage.Contains("ERROR"))
            {
                subject = "Passed!!! " + subject;             
            }
            else
            {
                subject = "Failed!!! " + subject;
            }

            SearchListPage.JSExecuteCode("");
            
            SearchListPage.SendEmailAttachment(subject, body, testName);
        
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
