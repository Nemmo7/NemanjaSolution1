using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NemanjaTest1
{
    public class SearchForBgList
    {
        public static string SearchImageOnGoogle(string SearchParam, int n)
        {

            string message = "",
                imageMessage = "";

            try
            {
                //Go On Google


                //Click on Param
                

                string param = SearchParam;
                //click on two params and download n pictures

                foreach (string singleParam in param.Split(','))
                {
                   
                    var FindText = Driver.Instance.FindElement(By.Name("q"));
                    FindText.Clear();
                    FindText.SendKeys(singleParam);
                    Thread.Sleep(1000);


                    Actions builder = new Actions(Driver.Instance);
                    builder.SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(1000);

                    //Click on Images
                    var bgImage = Driver.Instance.FindElement(By.CssSelector("#hdtb-msb-vis div:nth-child(2)"));
                    bgImage.Click();
                    Thread.Sleep(1000);

                    //Download Pictures
                    imageMessage = DownloadPicture(n, singleParam);
                    Thread.Sleep(1000);
                    

                }

            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            message += imageMessage;

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

                DirectoryInfo d = new DirectoryInfo(@"C:/Screenshot/" + TestName + "/");
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

        public static void CreateFolder(string folderpath)
        {
            System.IO.Directory.CreateDirectory(folderpath);
        }

        private static string DownloadPicture(int n, string singleParam)
        {
            string message = "",
                TestName = "SearchForBg",
                filename = "",
                selector = "",
                url = "";



            int         k = 1,
                        m = 2,
                        p = 1, 
                        h = 0; //h brojac za listu


            List<string> imgUrls = new List<string>();

            try
            {
                for (int i = 1; i <= n; i++)
                {
                    int j = i + 1;

                    var imagesrc = Driver.Instance.FindElement(By.CssSelector("#rg div:nth-child(" + j + ") a:nth-child(1)"));
                    imagesrc.Click();

                    h = 0;

                    for (int f = 1; f <= 3; f++)
                    {
                        var imgUrl = Driver.Instance.FindElement(By.CssSelector("#irc_cc div:nth-child(" + f + ") .irc_t .irc_mic .irc_mimg a img"));

                        try
                        {
                            url = imgUrl.GetAttribute("src");
                        }
                        catch
                        {
                            continue;
                        }

                        if (url != null)
                        {
                           
                            if (url.Contains(".jpg") || url.Contains(".jpeg") || url.Contains(".png") || url.Contains(".bmp") || url.Contains(".gif"))
                            {
                                //if ( (!imgUrls.Any()) )
                                if (imgUrls.Count != 0)
                                {
                                    //prolazi kroz listu i poredi clanove liste sa novim imgURL src elementom
                                    //da li on vec postoji u listi.
                                    for (int z = 0; z < imgUrls.Count; z++)
                                    {
                                        if (url == imgUrls[z])
                                        {
                                            h = 0;
                                            break;
                                        }
                                        else
                                        {
                                            h++;
                                            continue;
                                        }

                                        // if (z == imgUrls.Count - 1)
                                        // {
                                        //     imgUrls.Add(imgUrl);
                                        // }
                                    }

                                    if (h == imgUrls.Count)
                                    {
                                        imgUrls.Add(url);
                                        h = 0;
                                        break;
                                    }
                                }
                                else
                                {
                                    imgUrls.Add(url);
                                    h = 0;
                                    break;
                                }
                            }
                            else
                            {
                                message = singleParam + "_Picture" + i + "_can not be downloads because it does not have a direct link to it";
                                h = 0;
                                if (i == n)
                                {
                                    break;
                                }

                            }
                        }
                    }

                }

                for (int i = 0; i < imgUrls.Count; i++)
                {

                    filename = "C:\\Screenshot\\" + TestName + "\\" + singleParam + "-" + "Slika" + (i + 1) + ".jpeg";

                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead(imgUrls[i]);
                    Bitmap bitmap; bitmap = new Bitmap(stream);

                    if (bitmap != null)
                        bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);


                    stream.Flush();
                    stream.Close();
                    client.Dispose();
                }

                

                //else if (i == 1)
                // {
                //     WebClient client = new WebClient();
                //     Stream stream = client.OpenRead("https://www.popustplus.hr/upload/groupbuydeal/92284/thumb/beograd-popustplus-5af2c1a859505_5b223ecb58ff4_700xr.jpg");
                //     Bitmap bitmap; bitmap = new Bitmap(stream);

                //     if (bitmap != null)
                //         bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);


                //     stream.Flush();
                //     stream.Close();
                //     client.Dispose();
                // }

                //else if (i == 2)
                // {
                //     WebClient client = new WebClient();
                //     Stream stream = client.OpenRead("http://www.mondotravel.hr/files/images/ponuda/beograd/beograd_zima_2014.jpg");
                //     Bitmap bitmap; bitmap = new Bitmap(stream);

                //     if (bitmap != null)
                //         bitmap.Save(FileName, System.Drawing.Imaging.ImageFormat.Jpeg);


                //     stream.Flush();
                //     stream.Close();
                //     client.Dispose();
                // }
                // }

                //count = j;


            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            return message;
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
    }
    
}
