using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NemanjaTest1
{
    public class PHPTravelsFunction
    {
        public static string SearchPHPTravelsOnGoogle(string SearchParam)
        {
            string message = "",
               phpMessage = "";

            try
            {
                   //Open browser
                    var FindText = Driver.Instance.FindElement(By.Name("q"));
                    FindText.Clear();
                    FindText.SendKeys(SearchParam);
                    Thread.Sleep(1000);

                   //Send keys PHP PHP Travels
                    Actions builder = new Actions(Driver.Instance);
                    builder.SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(1000);

                   //Click on PHPTRAVELS | Travel Technology Partner
                    var phpTravels = Driver.Instance.FindElement(By.CssSelector("#rso div:nth-child(2) div:nth-child(1) div div .r a:nth-child(1) h3"));
                    phpTravels.Click();
                    Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            message += phpMessage;

            return message;
        }

        public static string Featured_ToolsPHPTravels()
        {
            string message = "",
               toolsMessage = "";

            try
            {
                var tools = Driver.Instance.FindElement(By.XPath("//div[5]//div[3]//div[2]//div//div[3]//article//figure/a"));
                tools.Click();
                Thread.Sleep(1000);

                var bookingTools = Driver.Instance.FindElement(By.CssSelector("#body-section div:nth-child(7) .panel.panel-default .panel-body form .panel-body input"));
                bookingTools.Clear();
                bookingTools = Driver.Instance.FindElement(By.CssSelector(".datepicker.dropdown-menu .datepicker-days table tbody tr:nth-child(4) td:nth-child(5)"));
                bookingTools.Click();
                bookingTools = Driver.Instance.FindElement(By.CssSelector("#body-section div:nth-child(7) .panel.panel-default .panel-body form .panel-body button"));
                bookingTools.Click();
                bookingTools = Driver.Instance.FindElement(By.CssSelector("#body-section div:nth-child(7) .panel.panel-default .panel-body form div:nth-child(5) button"));
                bookingTools.Click();
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            message += toolsMessage;

            return message;
        }

        public static string HotelsPHPTravels(string City)
        {
            string message = "",
               hotelsMessage = "";

            try
            {
                var cityHotels = Driver.Instance.FindElement(By.XPath("//div[5]//div[4]//div[2]//a"));
                cityHotels.Click();
                cityHotels.SendKeys(City);
                //.Xpath("//body-section//div(3)//div(2)//div//div(3)//article//figure//a")

                Actions builder = new Actions(Driver.Instance);
                builder.SendKeys(Keys.Enter).Perform();
                Thread.Sleep(1000);

                var checkHotels = Driver.Instance.FindElement(By.CssSelector("body .select2-drop.select2-display-none.select2-with-searchbox.select2-drop-active input"));
                checkHotels.Click();
                checkHotels = Driver.Instance.FindElement(By.CssSelector("body div:nth-child(19) .datepicker-days table tbody tr:nth-child(4) td:nth-child(4)"));
                checkHotels.Click();
                Thread.Sleep(1000);

                checkHotels = Driver.Instance.FindElement(By.CssSelector("#dpd2 input"));
                checkHotels.Click();
                checkHotels = Driver.Instance.FindElement(By.CssSelector("body div:nth-child(20) .datepicker-days table tbody tr:nth-child(5) td.day.active"));
                checkHotels.Click();
                Thread.Sleep(1000);

                var adultHotels = Driver.Instance.FindElement(By.Id("#htravellersInput"));
                adultHotels.Click();
                adultHotels = Driver.Instance.FindElement(By.Id("#hadultPlusBtn"));
                adultHotels.Click();
                adultHotels = Driver.Instance.FindElement(By.CssSelector("#hchildPlusBtn i"));
                adultHotels.Click();
                Thread.Sleep(1000);

                var searchHotels = Driver.Instance.FindElement(By.CssSelector("#thhotels form .col-md-2.form-group.go-right.col-xs-12.search-button button"));
                searchHotels.Click();
                Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            message += hotelsMessage;

            return message;
        }

        public static string EmailPHPTravels()
        {
            string message = "",
              emailMessage = "";

            try
            {
                var email = Driver.Instance.FindElement(By.CssSelector("body .tbar-top.hidden-sm.hidden-xs ul li:nth-child(2) span.tp-mail a"));
                email.Click();
                Thread.Sleep(1000);
                
            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            message += emailMessage;

            return message;
        }

        public static string NewsletterPHPTravels(string Email)
        {
            string message = "",
              newsletterMessage = "";

            try
            {
                //Click on Newsletter and send email
                var newsletter = Driver.Instance.FindElement(By.CssSelector("#exampleInputEmail1"));
                //newsletter.Click();
                newsletter.SendKeys(Email);
                Thread.Sleep(1000);
                //Click on Subscribe
                newsletter = Driver.Instance.FindElement(By.CssSelector("body .theme-hero-area.mobside.visible-lg .theme-hero-area-body .container .sc-1t1b6dh-2.joxZVq.sc-VigVT.fIhGog.col-md-4.go-left .row button"));
                newsletter.Click();

            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }

            message += newsletterMessage;

            return message;
        }

        public static string OffersPHPTravels(string Name, string Phone, string Message)
        {
            string message = "",
             offersMessage = "";

            try
            {
                //Click on Offers
                var offers = Driver.Instance.FindElement(By.CssSelector("nav div .collapse.navbar-collapse ul.nav.navbar-nav.go-right li:nth-child(2) a"));
                offers.Click();
                //Click on Read More for Lunch Discount
                offers = Driver.Instance.FindElement(By.CssSelector("#body-section .listingbg .col-md-9.col-xs-12 div:nth-child(2) a.btn.btn-primary.go-right.loader"));
                offers.Click();
                //Click on field Name
                offers = Driver.Instance.FindElement(By.CssSelector("#body-section div:nth-child(9) form fieldset .col-md-12.go-right.form-group input"));
                offers.Click();
                offers.SendKeys(Name);
                Thread.Sleep(1000);
                //Click on field Phone
                offers = Driver.Instance.FindElement(By.CssSelector("#body-section div:nth-child(9) form fieldset .col-md-12.go-left.form-group input"));
                offers.Click();
                offers.SendKeys(Phone);
                Thread.Sleep(1000);
                //Click on field Message
                offers = Driver.Instance.FindElement(By.CssSelector("#body-section div:nth-child(9) form fieldset div:nth-child(5) textarea"));
                offers.Click();
                offers.SendKeys(Message);
                Thread.Sleep(1000);
                //Click on Contact
                offers = Driver.Instance.FindElement(By.CssSelector("#body-section div:nth-child(9) form fieldset div:nth-child(7) input.btn.btn-success.btn-success.btn-block.btn-lg"));
                offers.Click();

            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message + "\n";
            }

            message += offersMessage;

            return message;
        }

        public static string BlogPHPTravels()
        {
            string message = "",
              blogMessage = "";

            try
            {
                //Click on Blog
                var blog = Driver.Instance.FindElement(By.CssSelector(".collapse.navbar-collapse ul.nav.navbar-nav.go-right li:nth-child(1) a"));
                blog.Click();
                //Click on second page
                blog = Driver.Instance.FindElement(By.CssSelector("#body-section div div .col-md-8.go-right ul li:nth-child(6) a"));
                blog.Click();
                Thread.Sleep(1000);
                //Click on third page
                blog = Driver.Instance.FindElement(By.CssSelector("#body-section div div .col-md-8.go-right ul li:nth-child(6) a"));
                blog.Click();
                Thread.Sleep(1000);
                //Click on Trapizzino, Rome’s OG Street Food
                blog = Driver.Instance.FindElement(By.CssSelector("#body-section div.col-md-8.go-right div.panel-body div:nth-child(6) a"));
                blog.Click();
            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message + "\n";
            }

            message += blogMessage;

            return message;
        }

        public static string LoginOnPHPTravels(string Email,string Password)
        {
            string message = "",
               loginMessage = "";

            try
            {
              //Clcik on My Account
               var login = Driver.Instance.FindElement(By.CssSelector(".hidden-sm #li_myaccount a.dropdown-toggle"));
               login.Click();
                //Click on Login
               login = Driver.Instance.FindElement(By.CssSelector(".hidden-sm #li_myaccount ul.dropdown-menu li:nth-child(1) a"));
               login.Click();
                //Send keys for email
                var loginEmail = Driver.Instance.FindElement(By.CssSelector("#loginfrm .panel.panel-default .wow.fadeIn.animated div div:nth-child(1) input"));
               loginEmail.Click();
               loginEmail.SendKeys(Email);
               Thread.Sleep(1000);
              //Send keys for password
               var loginPassword = Driver.Instance.FindElement(By.CssSelector("#loginfrm .panel.panel-default .wow.fadeIn.animated div div:nth-child(2) input"));
               loginPassword.Click();
               loginPassword.SendKeys(Password);
               Thread.Sleep(1000);
                //Click Login button
                login = Driver.Instance.FindElement(By.CssSelector("#loginfrm button"));
                login.Click();


            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message + "\n";
            }

            message += loginMessage;

            return message;
        }
    }
    
}