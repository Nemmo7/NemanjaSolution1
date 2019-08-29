using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace NemanjaTest1
{
    public class SearchListPage
    {

        public static void CreateFolder(string folderpath)
        {
            System.IO.Directory.CreateDirectory(folderpath);
        }


        public static IWebElement MenuText { get; private set; }

        public static void GoTo(ListType listType)
        {
            switch (listType)
            {
                case ListType.Page:
                    Driver.Instance.FindElement(By.Id("hdtb-msb-vis")).Click();
                    break;
                    
            }
        }

        public static string SelectImage(string Title, string TestName)
        {
            string message = "",
                   resultsImage = "";

            try
            {
                var imageLink = Driver.Instance.FindElement(By.LinkText(Title));
                Thread.Sleep(2500);
                imageLink.Click();

                for (int second = 0; ; second++)
                {
                    if (second >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (IsElementPresent(By.CssSelector("#rg_s div:nth-child(2) a:nth-child(2)"))) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }


                MenuText = Driver.Instance.FindElement(By.CssSelector("#rg_s div:nth-child(2) a:nth-child(2)"));
                resultsImage = MenuText.Text;
                Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                message +="ERROR!!!" + e.Message;

                TakeScreenShot(TestName);

            }


            message += resultsImage;


            return message;

        }

        public static void TakeScreenShot(string TestName)
        {
            Random r = new Random();

            ((ITakesScreenshot)Driver.Instance).GetScreenshot().SaveAsFile("C:/ScreenShot/" + TestName + "/Screenshot" + r.Next(0, 100000) + DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt)") + ".jpeg", ScreenshotImageFormat.Jpeg);
        }

        public static void WriteInto(string readText)
        {

            string filePath = @"C:\TestConfiguration\LogFile.txt";

            File.AppendAllText(filePath, readText + Environment.NewLine);

        }


        public static void JavascriptExecutor(string Script, object Arguments)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) Driver.Instance;
            js.ExecuteScript(Script, Arguments);
        }

        public static string JSExecuteCode(string JSCode)
        {

            string message = "";

            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.Instance;
                js.ExecuteScript(JSCode);
            }

            catch (Exception e)
            {
                message = e.Message;

                TakeScreenShot("");

            }


            return message;
        }

        public static string SelectBooks(string More, string Title, string TestName)
        {
            string message = "",
                   resultsBooks = "";

            int i = 0;

            
            try
            {
               Thread.Sleep(2000);

                if (IsElementPresent(By.LinkText(Title)))
                {
                    i = 1;
                        
                }
                else
                {
                    i = 2;
                       
                }

                Thread.Sleep(2000);

                if (i == 1)
                {
                    var booksLink = Driver.Instance.FindElement(By.LinkText(Title));
                    booksLink.Click();
                }
                else 
                {
                    var linkMore = Driver.Instance.FindElement(By.LinkText(More));
                    linkMore.Click();
                    Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles.ToList().Last());
                    Thread.Sleep(1000);
                    var booksLink = Driver.Instance.FindElement(By.LinkText(Title));
                    booksLink.Click();

                }

                Thread.Sleep(1000);

                for (int second = 0; ; second++)
                {
                    if (second >= 10) Assert.Fail("timeout");

                    if (IsElementPresent(By.CssSelector("#ires div:nth-child(1) a:nth-child(1)"))) break;


                    Thread.Sleep(1000);
                }

                MenuText = Driver.Instance.FindElement(By.CssSelector("#ires div:nth-child(1) a:nth-child(1)"));
                resultsBooks = MenuText.Text;
                Thread.Sleep(1000);


            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;

                TakeScreenShot(TestName);

            }


            message += resultsBooks;


            return message;
        }

        public static string SelectVideo(string Title, string TestName)
        {
            string message = "",
                resultsVideo = "";
               

            try
            {
                var videoLink = Driver.Instance.FindElement(By.LinkText(Title));
                videoLink.Click();

                for (int second = 0; ; second++)
                {
                    if (second >= 10)
                    {
                        Assert.Fail("timeout");
                    }
                    try
                    {
                        if (IsElementPresent(By.CssSelector("#sbfrm_l div:nth-child(1)"))) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }

                MenuText = Driver.Instance.FindElement(By.CssSelector("#sbfrm_l div:nth-child(1)"));
                resultsVideo = MenuText.Text;
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message + "\n";

                TakeScreenShot(TestName);

            }


            message += resultsVideo;

            return message;
        }

        public static string SelectAll(string Title, string TestName)
        {
            string message = "",
                resultsAll = "";

            try
            {
                var allLink = Driver.Instance.FindElement(By.LinkText(Title));
                allLink.Click();

                for (int second = 0; ; second++)
                {
                    if (second >= 10) Assert.Fail("timeout");
                    try
                    {
                        if (IsElementPresent(By.CssSelector("#sbfrm_l div:nth-child(1)"))) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }

                MenuText = Driver.Instance.FindElement(By.CssSelector("#sbfrm_l div:nth-child(1)"));
                resultsAll = MenuText.Text;
                Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                message +=  "ERROR!!!" + e.Message;

                TakeScreenShot(TestName);

            }


            message += resultsAll;


            return message;

        }

        #region click functions

        public static string ClickOnElementByID(string IDSelector)
        {
            string message = "";

            try
            {

                for (int second = 0; ; second++)
                {
                    if (second >= 10)
                    {
                        Assert.Fail("timeout");
                    }
                    try
                    {
                        if (IsElementPresent(By.Id(IDSelector))) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }

                var elementID = Driver.Instance.FindElement(By.Id(IDSelector));
                elementID.Click();
            }

            catch (Exception e)
            {
                message = e.Message;
            }

            return message;
        }

        public static string ClickOnElementByCSSSelector(string CSSSelector)
        {
            string message = "";

            try
            {

                for (int second = 0; ; second++)
                {
                    if (second >= 10)
                    {
                        Assert.Fail("timeout");
                    }
                    try
                    {
                        if (IsElementPresent(By.CssSelector(CSSSelector))) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }

                var elementCSS = Driver.Instance.FindElement(By.CssSelector(CSSSelector));
                elementCSS.Click();
            }

            catch (Exception e)
            {
                message = e.Message;
            }

            return message;
            
        }

        public static string ClickOnElementByClassName(string ClassNameSelector)
        {
            string message = "";

            try
            {

                for (int second = 0; ; second++)
                {
                    if (second >= 10)
                    {
                        Assert.Fail("timeout");
                    }
                    try
                    {
                        if (IsElementPresent(By.ClassName(ClassNameSelector))) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }

                var elementClass = Driver.Instance.FindElement(By.ClassName(ClassNameSelector));
                elementClass.Click();
            }

            catch (Exception e)
            {
                message = e.Message;
            }

            return message;
        }

        public static string ClickOnElementByLinkText (string LinkTextSelector)
        {
            string message = "";

            try
            {

                for (int second = 0; ; second++)
                {
                    if (second >= 10)
                    {
                        Assert.Fail("timeout");
                    }
                    try
                    {
                        if (IsElementPresent(By.ClassName(LinkTextSelector))) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }

                var elementClass = Driver.Instance.FindElement(By.ClassName(LinkTextSelector));
                elementClass.Click();
            }

            catch (Exception e)
            {
                message = e.Message;
            }

            return message;
        }

        public static string ClickOnElementByXPath (string XPathSelector)
        {
            string message = "";

            try
            {

                for (int second = 0; ; second++)
                {
                    if (second >= 10)
                    {
                        Assert.Fail("timeout");
                    }
                    try
                    {
                        if (IsElementPresent(By.ClassName(XPathSelector))) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }

                var elementClass = Driver.Instance.FindElement(By.ClassName(XPathSelector));
                elementClass.Click();
            }

            catch (Exception e)
            {
                message = e.Message;
            }

            return message;
        }


        #endregion


        public static int CountMoreItems(string menu)

        {

            int count = 0, j = 0;

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    var item = Driver.Instance.FindElement(By.CssSelector("#lb div a:nth-child(" + i + ")"));

                    if(IsElementPresent(By.CssSelector("#lb div a:nth-child(" + i + ")")))
                    {
                        j++;
                    }
                }

                count = j;
                
            }
            catch (Exception e)
            {
              //  string message = e.Message;
            }

            return count;
        }

        public static void SelectPost(string Title)
        {

            //var listLink = Driver.Instance.FindElement(By.LinkText(Title));
            //listLink.Click();

            //string resultsAll = "",
            //       resultsVideo = "",
            //       resultsBooks = "";

            //Thread.Sleep(1000);

            //var sveLink = Driver.Instance.FindElement(By.LinkText("Sve"));
            //sveLink.Click();

            //for (int second = 0; ; second++)
            //{
            //    if (second >= 60) Assert.Fail("timeout");
            //    try
            //    {
            //        if (IsElementPresent(By.Id("resultStats"))) break;
            //    }
            //    catch (Exception)
            //    { }
            //    Thread.Sleep(1000);
            //}
            //MenuText = Driver.Instance.FindElement(By.Id("resultStats"));
            //resultsAll = MenuText.Text;
            //Thread.Sleep(1000);

            //var videoLink = Driver.Instance.FindElement(By.LinkText("Videozapisi"));
            //videoLink.Click();
            //Thread.Sleep(1000);
            //for (int second = 0; ; second++)
            //{
            //    if (second >= 60) Assert.Fail("timeout");
            //    try
            //    {
            //        if (IsElementPresent(By.Id("resultStats"))) break;
            //    }
            //    catch (Exception)
            //    { }
            //    Thread.Sleep(1000);
            //}
            //MenuText = Driver.Instance.FindElement(By.Id("resultStats"));
            //resultsVideo = MenuText.Text;

            //var knjigeLink = Driver.Instance.FindElement(By.LinkText("Knjige"));
            //knjigeLink.Click();
            //Thread.Sleep(1000);

            //var viseLink = Driver.Instance.FindElement(By.LinkText("Više"));
            //viseLink.Click();



            //



            Thread.Sleep(1000);
            Driver.Instance.Navigate().GoToUrl("https://www.google.com/search?client=firefox-b-d&q=jugoslavija");
        }

        private static bool IsElementPresent(By by)
        {
            try
            {
                Driver.Instance.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static string SendEmail(string subject, string body)
        {
            string message = "";

            try
            {
                

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("nemanja.pusara91@gmail.com");
                mail.To.Add("nemanja.pusara91@gmail.com");
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("nemanja.pusara91@gmail.com", "20.fudbal.14");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            return message;
        }

        public static string SendEmailAttachment(string subject, string body, string TestName)
        {
            string message = "";
            
                   

            try
            {


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("nemanja.pusara91@gmail.com");
                mail.To.Add("nemanja.pusara91@gmail.com");
                mail.Subject = subject;
                mail.Body = body;

                System.Net.Mail.Attachment attachment;

                DirectoryInfo d = new DirectoryInfo(@"C:/Screenshot/"+ TestName + "/");
                FileInfo[] Files = d.GetFiles("*.jpeg", SearchOption.AllDirectories); 
                
                foreach (FileInfo file in Files)
                {
                    attachment = new System.Net.Mail.Attachment(file.FullName);
                    mail.Attachments.Add(attachment);
                }

                             

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("nemanja.pusara91@gmail.com", "20.fudbal.14");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            return message;
        }

        public static string DeleteFolder(string folderpath)
        {

            string message = "";

            try
            {
                if (Directory.Exists(folderpath))
                {
                    Directory.Delete(folderpath, true);
                }               
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return message;
        }

    }

    public enum ListType
    {
        Page
    }
}